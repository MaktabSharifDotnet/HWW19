using HW19.Domain.CategoryAgg.Entities;
using HW19.Domain.ToDoAgg.Enums;
using HW19.Domain.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.ToDoAgg.Entities
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }

        public DateTime DueDate { get; set; }
        
        public  StatusEnum Status { get; set; }=StatusEnum.Pending;
        public bool IsDeleted { get; set; } = false;

        #region Navigation property

        public User User { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        #endregion

    }
}
