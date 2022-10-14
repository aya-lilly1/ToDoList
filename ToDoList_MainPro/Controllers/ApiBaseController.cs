using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using Tazeez.Common.Extensions;
using ToDoList.ModelView;

namespace ToDoList.Controllers
{
    public class ApiBaseController :Controller
    {
        private UserView _loggedInUser;

        protected UserView LoggedInUser
        {
            get
            {
                if (_loggedInUser != null)
                {
                    return _loggedInUser;
                }

                Request.Headers.TryGetValue("Authorization", out StringValues Token);

                if (string.IsNullOrWhiteSpace(Token))
                {
                    _loggedInUser = null;
                    return _loggedInUser;
                }

                var ClaimId = User.Claims.FirstOrDefault(c => c.Type == "Id");

                int.TryParse(ClaimId.Value, out int idd);

                if (ClaimId == null || !int.TryParse(ClaimId.Value, out int id))
                {
                    throw new ServiceValidationException(401, "Invalid or expired token");
                }

                return new UserView
                {
                    Id = id,
                    FirstName = "Baraa",
                    LastName = "Deek",
                    Email = "test@gmail.com"
                };
            }
        }

        public ApiBaseController()
        {
        }
    }
}
