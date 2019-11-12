#region

using System;
using System.Collections.Generic;
using BTL.Infrastructure.Configuration;

#endregion

namespace BTL.Application.Web
{
    public class AuthenticationTypeConfiguration : ISectionConfiguration
    {
        public AuthenticationTypeConfiguration()
        {
            SectionCollection =
                new HashSet<Tuple<string, string, string, string, string, string>>(new AuthenticationTypeComparator());
        }

        /// <summary>
        ///   Gets or sets the section collection. Tuple is name, value, authRequestType, processType, returnResult, inputParameter
        /// </summary>
        /// <value> The section collection. </value>
        internal ISet<Tuple<string, string, string, string, string, string>> SectionCollection { get; private set; }

        #region ISectionConfiguration Members

        public void Add(string sectionName, string sectionValue, List<KeyValuePair<string, string>> valuePairs)
        {
            var authRequestType = valuePairs.Find(e => e.Key == "authRequestType").Value;
            var processType = valuePairs.Find(e => e.Key == "processType").Value;
            var returnResult = valuePairs.Find(e => e.Key == "returnResult").Value;
            var inputParams = valuePairs.Find(e => e.Key == "inputParameter").Value;
            SectionCollection.Add(
                new Tuple<string, string, string, string, string, string>(
                    sectionName, sectionValue, authRequestType, processType, returnResult, inputParams));
        }

        #endregion
    }

    public class AuthenticationTypeComparator : IEqualityComparer<Tuple<string, string, string, string, string, string>>
    {
        #region IEqualityComparer<Tuple<string,string,string,string,string>> Members

        public bool Equals(Tuple<string, string, string, string, string, string> x,
                           Tuple<string, string, string, string, string, string> y)
        {
            return (x.Item1.Equals(y.Item1, StringComparison.CurrentCulture)
                    && x.Item2.Equals(y.Item2, StringComparison.CurrentCulture)
                    && x.Item3.Equals(y.Item3, StringComparison.CurrentCulture)
                    && x.Item4.Equals(y.Item4, StringComparison.CurrentCulture)
                    && x.Item5.Equals(y.Item5, StringComparison.CurrentCulture)
                    && x.Item6.Equals(y.Item6, StringComparison.CurrentCulture));
        }

        // TODO implement hashcode with unique value
        public int GetHashCode(Tuple<string, string, string, string, string, string> obj)
        {
            return obj.Item1.Length ^ obj.Item2.Length ^ obj.Item3.Length ^ obj.Item4.Length ^ obj.Item5.Length ^ obj.Item6.Length;
        }

        #endregion
    }
}