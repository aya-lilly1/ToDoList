using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.ModelView;

namespace ToDoLiist_CORE.Manager.Interface
{
    public interface IRoleManager
    {
        bool CheckAccess(UserView user);

    }
}
