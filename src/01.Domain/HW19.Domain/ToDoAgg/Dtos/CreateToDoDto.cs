using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.ToDoAgg.Dtos
{
    public class CreateToDoDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
