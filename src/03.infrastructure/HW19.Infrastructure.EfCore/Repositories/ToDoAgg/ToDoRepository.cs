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

        public bool ExistCaetgoryId(int categoryId)
        {
           return _context.ToDos.Any(t=>t.CategoryId == categoryId);
        }

        public List<ToDoInfoDto> GetAll()
        {
          return _context.ToDos
                .AsNoTracking()
                .Select(t=>new ToDoInfoDto
                  {
                      Id = t.Id,
                      Title = t.Title,
                      Description = t.Description,
                      DueDate = t.DueDate,
                      Status = t.Status,
                  }).ToList();
        }

        public int Delete(int categoryId)
        {
            ToDo? todo=_context.ToDos.FirstOrDefault(t => t.CategoryId == categoryId);
            if (todo != null) 
            {
                todo.IsDeleted= true;
               return _context.SaveChanges();
            }
            return 0;
        }
    }
}
