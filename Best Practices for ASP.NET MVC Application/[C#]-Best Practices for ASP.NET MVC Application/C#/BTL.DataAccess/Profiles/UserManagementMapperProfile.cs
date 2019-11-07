#region

using AutoMapper;
using BTL.ContractMessages.UserManagement;
using BTL.Domain.Core.UserManagement;

#endregion

namespace BTL.DataAccess.Profiles
{
    public class UserManagementMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UserInfo, User>()
                .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                .ForMember(x => x.Password, o => o.MapFrom(m => m.Password))
                .ForMember(x => x.Theme, o => o.MapFrom(m => m.Theme))
                .ForMember(x => x.CreatedAt, o => o.MapFrom(m => m.CreatedAt))
                .ForMember(x => x.UpdatedAt, o => o.MapFrom(m => m.UpdatedAt));

            Mapper.CreateMap<User, UserInfo>()
                .ForMember(x => x.UserName, o => o.MapFrom(m => m.UserName))
                .ForMember(x => x.Password, o => o.MapFrom(m => m.Password))
                .ForMember(x => x.Theme, o => o.MapFrom(m => m.Theme))
                .ForMember(x => x.CreatedAt, o => o.MapFrom(m => m.CreatedAt))
                .ForMember(x => x.UpdatedAt, o => o.MapFrom(m => m.UpdatedAt));
        }
    }
}