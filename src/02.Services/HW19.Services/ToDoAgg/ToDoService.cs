using HW19.Domain._common;
using HW19.Domain.ToDoAgg.Contracts.Repositories;
using HW19.Domain.ToDoAgg.Contracts.Services;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using HW19.Domain.ToDoAgg.Enums;
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

        public List<ToDoInfoDto> GetAll(int userId, string searchTerm, string sortBy)
        {
            return _toDoRepository.GetAll(userId, searchTerm, sortBy);
        }

        public int ToggleStatus(int toDoId, int userId)
        {
            var todo = _toDoRepository.GetById(toDoId);

           
            if (todo == null || todo.UserId != userId)
            {

                throw new Exception("عملیات تغییر وضعیت انجام نشد.");
            }

           
            if (todo.Status == StatusEnum.Done)
            {
                todo.Status = StatusEnum.Pending;
            }
            else
            {
                todo.Status = StatusEnum.Done;
            }

           return _toDoRepository.Update(todo);
        }
    }
}

