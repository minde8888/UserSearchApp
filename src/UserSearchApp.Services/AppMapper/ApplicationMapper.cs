using AutoMapper;
using UserSearchApp.Domain.Entities;
using UserSearchApp.Services.Dtos;

namespace UserSearchApp.Services.AppMapper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() {
            CreateMap<SearchUserInfo, UserInfo>().ReverseMap();
            CreateMap<Address, UserAddress>().ReverseMap();
            CreateMap<Geo, UserGeo>().ReverseMap();
        }      
    }
}
