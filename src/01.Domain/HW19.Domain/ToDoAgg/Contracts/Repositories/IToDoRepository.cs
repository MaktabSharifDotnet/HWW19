using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.ToDoAgg.Contracts.Repositories
{
    public interface IToDoRepository
    {
        public List<ToDoInfoDto> GetAll();
        public int Delete(int categoryId);

        public bool ExistCaetgoryId(int categoryId);
        public int Create(ToDo toDo);
    }
}
