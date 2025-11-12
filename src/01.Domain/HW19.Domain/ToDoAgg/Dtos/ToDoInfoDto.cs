using HW19.Domain.CategoryAgg.Entities;
using HW19.Domain.ToDoAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.ToDoAgg.Dtos
{
    public  class ToDoInfoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public StatusEnum Status { get; set; }

        public string CategoryName { get; set; }
    }
}
