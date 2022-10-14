using System.ComponentModel;

namespace ToDoList.ModelView
{
    public class UpdateUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DefaultValue("")]
        public string Image { get; set; }

        public string ImageString { get; set; }

        public string Email { get; set; }
    }
}
