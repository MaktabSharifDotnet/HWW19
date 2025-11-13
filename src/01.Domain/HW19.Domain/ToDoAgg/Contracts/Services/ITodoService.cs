using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.ToDoAgg.Contracts.Services
{
    public interface ITodoService
    {
        public List<ToDoInfoDto> GetAll(int userId, string searchTerm, string sortBy);
        public int Delete(int categoryId);

        public int Create(CreateToDoDto toDo);
        public int ToggleStatus(int toDoId, int userId);

    }
}
