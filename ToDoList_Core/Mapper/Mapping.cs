using AutoMapper;
using ToDoList.Models;
using ToDoList.ModelView;

namespace ToDoList.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<LoginUserResponse, User>().ReverseMap();
            CreateMap<UserRegistrationModel, User>().ReverseMap();
            CreateMap<UpdateUser, User>().ReverseMap();
            CreateMap<ToDoView, Todo>().ReverseMap();

        }
    }
}
