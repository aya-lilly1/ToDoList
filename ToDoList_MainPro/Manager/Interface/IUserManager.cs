using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ModelView;

namespace ToDoLiist_CORE.Manager.Interface
{
    public interface IUserManager : IManager
    {
        LoginUserResponse Login(LoginModelView userReg);
        LoginUserResponse SignUp(UserRegistrationModel userReg);
        void DeleteUser(UserView currentUser, int id);
        UserView UpdateUser(UserView currentUser, UpdateUser request);
        List<UserView> Get();


    }
}
