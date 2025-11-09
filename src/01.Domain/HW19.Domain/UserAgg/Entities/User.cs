using HW19.Domain.ToDoAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.UserAgg.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }
        public List<ToDo> ToDos  { get; set; }
    }
}
