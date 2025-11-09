using HW19.Domain.ToDoAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.CategoryAgg.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public List<ToDo> ToDos { get; set; }

    }
}
