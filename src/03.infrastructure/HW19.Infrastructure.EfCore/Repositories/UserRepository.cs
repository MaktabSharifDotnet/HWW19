using HW19.Domain.Contracts.Repositories;
using HW19.Domain.UserAgg.Entities;
using HW19.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Infrastructure.EfCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public int Register(string username , string hashedPassword) 
        {
           User user = new User() 
           {
             Username = username ,
             PasswordHash = hashedPassword
           };
            _context.Users.Add(user);
             _context.SaveChanges();
            return user.Id;
        }

        public bool IsAlreadyExistUsername(string username) 
        {
            
           return _context.Users.AsNoTracking().Any(u=> u.Username == username);
        }
    }
}
