using AutoMapper;
using TermPaper.Api.Requests;
using TermPaper.Shared.Entities;

namespace TermPaper.Api.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterRequest, User>();

        }
    }
}
