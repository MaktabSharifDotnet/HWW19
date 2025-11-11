using HW19.Domain._common;
using HW19.Domain.ToDoAgg.Contracts.Repositories;
using HW19.Domain.ToDoAgg.Contracts.Services;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using HW19.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Services.ToDoAgg
{
    public class ToDoService : ITodoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public int Create(CreateToDoDto toDo)
        {
           

           
            DateTime dueDate = toDo.DueDate.ToMiladi();

            ToDo task = new ToDo
            {
               Title = toDo.Title,
               Description=toDo.Description,
               CategoryId = toDo.CategoryId,
               DueDate = dueDate,
               UserId=LocalStorage.LoginUser.Id,

            };

           return _toDoRepository.Create(task);
        }

        public int Delete(int Id)
        {
            bool exist=_toDoRepository.ExistCaetgoryId(Id);
            if (!exist)
            {
                throw new Exception("کتگوری ای با این آیدی موجود نیست .");
            }
            return _toDoRepository.Delete(Id);
        }

        public List<ToDoInfoDto> GetAll()
        {
           return _toDoRepository.GetAll();
        }
    }
}
