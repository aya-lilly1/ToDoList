using AutoMapper;

using ToDoList.Models;
using ToDoList.ModelView;

namespace ToDoLiist_CORE.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, LoginUserResponse>().ReverseMap();
            CreateMap<UserView, User>().ReverseMap();
            CreateMap<Todo,ToDoView >().ReverseMap();


        }
    }
}
