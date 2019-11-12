#region

using AutoMapper;
using BTL.ContractMessages.UserManagement;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Models.Profiles
{
    public class UserInformationMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<SocialUserInformation, FacebookUserInformation>()
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                .ForMember(x => x.PictureUrl, o => o.MapFrom(m => m.PictureUrl));

            Mapper.CreateMap<FacebookUserInformation, SocialUserInformation>()
                .ForMember(x => x.UserId, o => o.MapFrom(m => m.UserId))
                .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                .ForMember(x => x.PictureUrl, o => o.MapFrom(m => m.PictureUrl));
        }
    }
}