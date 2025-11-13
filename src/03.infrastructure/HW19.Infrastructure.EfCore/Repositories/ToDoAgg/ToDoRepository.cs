using HW19.Domain.ToDoAgg.Contracts.Repositories;
using HW19.Domain.ToDoAgg.Dtos;
using HW19.Domain.ToDoAgg.Entities;
using HW19.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Infrastructure.EfCore.Repositories.ToDoAgg
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _context;
        public ToDoRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool ExistCaetgoryId(int toDoId)
        {
           return _context.ToDos.Any(t=>t.Id == toDoId);
        }

        public List<ToDoInfoDto> GetAll(int userId, string searchTerm, string sortBy)
        {
            var query = _context.ToDos
                   .AsNoTracking() 
                   .Where(t => t.UserId == userId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
               
                query = query.Where(t =>
                    t.Title.Contains(searchTerm) ||
                    t.Category.Name.Contains(searchTerm)
                );
            }
            switch (sortBy)
            {
                case "Title":
                    query = query.OrderBy(t => t.Title);
                    break;
                case "DueDate":
                    query = query.OrderBy(t => t.DueDate);
                    break;
                case "IsCompleted":
                    
                    query = query.OrderBy(t => t.Status);
                    break;
                default:
                   
                    query = query.OrderByDescending(t => t.Id);
                    break;

            }
            return query.Select(t => new ToDoInfoDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Status = t.Status,
                CategoryName = t.Category.Name
            }).ToList();
        }

        public int Delete(int Id)
        {
            ToDo? todo=_context.ToDos.FirstOrDefault(t => t.Id == Id);
            if (todo != null) 
            {
                todo.IsDeleted= true;
               return _context.SaveChanges();
            }
            return 0;
        }

        public int Create(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
           return _context.SaveChanges();
            
        }

        public int Update(ToDo toDoId)
        {
            _context.ToDos.Update(toDoId);
            return _context.SaveChanges();
        }

        public ToDo? GetById(int id)
        {
          return _context.ToDos.FirstOrDefault(t=>t.Id==id);
        }
    }
}
