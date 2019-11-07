#region

using AutoMapper;
using BTL.DataAccess.Profiles;

#endregion

namespace BTL.Services.AppSecurity.Service
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile(new UserManagementMapperProfile());
        }
    }
}