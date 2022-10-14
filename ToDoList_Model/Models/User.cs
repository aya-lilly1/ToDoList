using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ToDoList.Models
{
    public partial class User
    {
        public User()
        {
            Todos = new HashSet<Todo>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }
        public string Image { get; set; }
        [Timestamp]
        public DateTime CreatedDate { get; set; }

        [Timestamp] // or 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate{ get; set; }

        public bool Archived { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
