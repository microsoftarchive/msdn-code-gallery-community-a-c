//----------------------------------------------------------------------------------------------
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml;

namespace ClaimsAuthorizationLibrary
{
    public class PolicyReader
    {
        static Expression<Func<ClaimsPrincipal, bool>> DefaultPolicy = (icp) => false;
        static Expression<Func<ClaimsPrincipal, bool>> AllowAccessForDefaultPagePolicy = (icp) => true;

        delegate bool HasClaimDelegate(ClaimsPrincipal p, string claimType, string claimValue);

        /// <summary>
        /// Delegate that checks if the associated claimsPrincipal has the claim specified
        /// </summary>
        static HasClaimDelegate HasClaim = delegate(ClaimsPrincipal p, string claimType, string claimValue)
        {
            return p.Claims.Any(c => c.Type == claimType &&
                                c.ValueType == ClaimValueTypes.String &&
                                c.Value == claimValue);
        };

        /// <summary>
        /// Creates an instance of the policy reader
        /// </summary>
        public PolicyReader()
        {
        }

        /// <summary>
        /// Read the policy as a LINQ expression
        /// </summary>
        /// <param name="rdr">XmlDictionaryReader for the policy Xml</param>
        /// <returns></returns>
        public Expression<Func<ClaimsPrincipal, bool>> ReadPolicy(XmlDictionaryReader rdr)
        {
            if (rdr.Name != "policy")
            {
                throw new InvalidOperationException("Invalid policy document");
            }

            rdr.Read();

            if (!rdr.IsStartElement())
            {
                rdr.ReadEndElement();
                // There are no claims inside this policy which means allow access to the page.
                return AllowAccessForDefaultPagePolicy;
            }
            //
            // Instantiate a parameter for the ClaimsPrincipal so it can be evaluated against
            // each claim constraint.
            // 
            ParameterExpression subject = Expression.Parameter(typeof(ClaimsPrincipal), "subject");
            Expression<Func<ClaimsPrincipal, bool>> result = ReadNode(rdr, subject);

            rdr.ReadEndElement();

            return result;
        }

        /// <summary>
        /// Read the policy node
        /// </summary>
        /// <param name="rdr">XmlDictionaryReader for the policy Xml</param>
        /// <param name="subject">ClaimsPrincipal subject</param>
        /// <returns>A LINQ expression created from the policy</returns>
        private Expression<Func<ClaimsPrincipal, bool>> ReadNode(XmlDictionaryReader rdr, ParameterExpression subject)
        {
            Expression<Func<ClaimsPrincipal, bool>> policyExpression;

            if (!rdr.IsStartElement())
            {
                throw new InvalidOperationException("Invalid Policy format.");
            }

            switch (rdr.Name)
            {
                case "and":
                    policyExpression = ReadAnd(rdr, subject);
                    break;
                case "or":
                    policyExpression = ReadOr(rdr, subject);
                    break;
                case "claim":
                    policyExpression = ReadClaim(rdr);
                    break;
                default:
                    policyExpression = DefaultPolicy;
                    break;
            }

            return policyExpression;
        }

        /// <summary>
        /// Read the claim node
        /// </summary>
        /// <param name="rdr">XmlDictionaryReader of the policy Xml</param>
        /// <returns>A LINQ expression created from the claim node</returns>
        private Expression<Func<ClaimsPrincipal, bool>> ReadClaim(XmlDictionaryReader rdr)
        {
            string claimType = rdr.GetAttribute("claimType");
            string claimValue = rdr.GetAttribute("claimValue");

            Expression<Func<ClaimsPrincipal, bool>> hasClaim = (icp) => HasClaim(icp, claimType, claimValue);

            rdr.Read();

            return hasClaim;
        }

        /// <summary>
        /// Read the Or Node
        /// </summary>
        /// <param name="rdr">XmlDictionaryReader of the policy Xml</param>
        /// <param name="subject">ClaimsPrincipal subject</param>
        /// <returns>A LINQ expression created from the Or node</returns>
        private Expression<Func<ClaimsPrincipal, bool>> ReadOr(XmlDictionaryReader rdr, ParameterExpression subject)
        {
            rdr.Read();

            BinaryExpression lambda1 = Expression.OrElse(
                    Expression.Invoke(ReadNode(rdr, subject), subject),
                    Expression.Invoke(ReadNode(rdr, subject), subject));

            rdr.ReadEndElement();

            Expression<Func<ClaimsPrincipal, bool>> lambda2 = Expression.Lambda<Func<ClaimsPrincipal, bool>>(lambda1, subject);
            return lambda2;
        }

        /// <summary>
        /// Read the And Node
        /// </summary>
        /// <param name="rdr">XmlDictionaryReader of the policy Xml</param>
        /// <param name="subject">ClaimsPrincipal subject</param>
        /// <returns>A LINQ expression created from the And node</returns>
        private Expression<Func<ClaimsPrincipal, bool>> ReadAnd(XmlDictionaryReader rdr, ParameterExpression subject)
        {
            rdr.Read();

            BinaryExpression lambda1 = Expression.AndAlso(
                    Expression.Invoke(ReadNode(rdr, subject), subject),
                    Expression.Invoke(ReadNode(rdr, subject), subject));

            rdr.ReadEndElement();

            Expression<Func<ClaimsPrincipal, bool>> lambda2 = Expression.Lambda<Func<ClaimsPrincipal, bool>>(lambda1, subject);
            return lambda2;
        }
    }
}
