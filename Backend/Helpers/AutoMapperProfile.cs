using AutoMapper;
using Backend.Entities;
using Backend.Models;


namespace Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<Chat, ChatModel>();
            CreateMap<ChatModel, Chat>();

        }
    }
}