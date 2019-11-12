#region

using AutoMapper;
using BTL.Application.Web.Infrastructure.Security.Authentications.Models.Profiles;

#endregion

namespace BTL.Application.Web.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.AddProfile(new UserInformationMapperProfile());
        }
    }
}