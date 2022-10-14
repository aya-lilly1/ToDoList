using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.ModelView
{
    public class ToDoView
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
       

    }
}
