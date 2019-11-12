using Api_Authorization.Models;
using Api_Authorization.Models.ViewModel;
using Api_Authorization.Utility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api_Authorization.Business.UserFactory
{
    public class UserAuthorizations
    {
        public ApiSecurityEntities _ctx = null;
        public tokenModel objModel = null;

        public bool ValidateToken(string authorizedToken, string userAgent)
        {
            bool result = false;
            try
            {
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(authorizedToken));
                string[] parts = key.Split(new char[] { ':' });
                if (parts.Length == 3)
                {
                    objModel = new tokenModel()
                    {
                        clientToken = parts[0],
                        userid = parts[1],
                        methodtype = parts[2],
                        ip = HostService.GetIP()
                    };

                    //compare token
                    string serverToken = generateToken(objModel.userid, objModel.methodtype, objModel.ip, userAgent);
                    if (objModel.clientToken == serverToken)
                    {
                        result = ValidateAuthorization(objModel.userid, objModel.methodtype);
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return result;
        }

        public string generateToken(string userid, string methodtype, string ip, string userAgent)
        {
            string message = string.Join(":", new string[] { userid, ip, userAgent });
            string key = methodtype ?? "";

            var encoding = new System.Text.ASCIIEncoding();

            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public bool ValidateAuthorization(string userid, string methodtype)
        {
            bool IsValid = false;
            if (userid != null)
            {
                using (_ctx = new ApiSecurityEntities())
                {
                    if (_ctx.UserAuthentications.Any(u => u.LoginID == userid && u.StatusID == 1))
                    {
                        switch (methodtype)
                        {
                            case "get":
                                IsValid = (from u in _ctx.UserAuthentications
                                           join r in _ctx.UserRoles on u.RoleID equals r.RoleID
                                           where u.LoginID == userid && u.StatusID == 1 && r.CanRead == true
                                           select u).Any();
                                break;
                            case "post":
                                IsValid = (from u in _ctx.UserAuthentications
                                           join r in _ctx.UserRoles on u.RoleID equals r.RoleID
                                           where u.LoginID == userid && u.StatusID == 1 && r.CanCreate == true
                                           select u).Any();
                                break;
                            case "put":
                                IsValid = (from u in _ctx.UserAuthentications
                                           join r in _ctx.UserRoles on u.RoleID equals r.RoleID
                                           where u.LoginID == userid && u.StatusID == 1 && r.CanUpdate == true
                                           select u).Any();
                                break;
                            case "delete":
                                IsValid = (from u in _ctx.UserAuthentications
                                           join r in _ctx.UserRoles on u.RoleID equals r.RoleID
                                           where u.LoginID == userid && u.StatusID == 1 && r.CanDelete == true
                                           select u).Any();
                                break;
                            default:
                                IsValid = false;
                                break;
                        }
                    }
                }
            }
            return IsValid;
        }
    }
}
