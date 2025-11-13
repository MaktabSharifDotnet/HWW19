

using HW19.Domain.ToDoAgg.Dtos;
using System.Collections.Generic;

namespace HW19.Presentation.MVC.Models
{
    public class ToDoIndexViewModel
    {
        
        public List<ToDoInfoDto> ToDos { get; set; } = [];

      
        public string SearchTerm { get; set; }

       
        public string SortBy { get; set; }

       
    }
}