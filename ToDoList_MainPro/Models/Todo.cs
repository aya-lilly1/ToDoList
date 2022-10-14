using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ToDoList.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public bool Archived { get; set; }
        [Timestamp]
        public DateTime CreatedDate { get; set; }

        [Timestamp] // or 
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDate{ get; set; }

      

        public virtual User IduserNavigation { get; set; }
    }
}
