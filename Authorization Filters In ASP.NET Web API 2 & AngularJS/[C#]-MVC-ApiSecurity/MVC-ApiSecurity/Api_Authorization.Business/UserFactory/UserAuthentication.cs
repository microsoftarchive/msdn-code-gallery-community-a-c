using Api_Authorization.Models;
using Api_Authorization.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Authorization.Business.UserFactory
{
    public class UserAuthentications
    {
        public ApiSecurityEntities _ctx = null;

        public loggedUserModel MemberAuthentication(loginUserModel model)
        {
            loggedUserModel UserAuth = null;

            if (model != null)
            {
                using (_ctx = new ApiSecurityEntities())
                {
                    UserAuth = (
                        from u in _ctx.UserAuthentications
                        join r in _ctx.UserRoles on u.RoleID equals r.RoleID
                        where u.LoginID == model.LoginId && u.Password == model.Password && u.StatusID == 1
                        select new
                        {
                            UserId = u.UserID,
                            UserName = u.UserName,
                            Role = r.RoleName,
                            Status = (int)u.StatusID
                        }).Select(x => new loggedUserModel
                        {
                            UserId = x.UserId,
                            UserName = x.UserName,
                            Role = x.Role,
                            Status = (int)x.Status

                        }).FirstOrDefault();
                }
            }
            return UserAuth;
        }
    }
}
