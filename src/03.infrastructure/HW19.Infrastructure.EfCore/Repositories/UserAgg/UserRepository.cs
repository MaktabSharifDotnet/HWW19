using HW19.Domain.UserAgg.Contracts.Repositories;
using HW19.Domain.UserAgg.Dto;
using HW19.Domain.UserAgg.Entities;
using HW19.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Infrastructure.EfCore.Repositories.UserAgg
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User? Register(UserInfoInputDto userInfoInputDto) 
        {
           User user = new User() 
           {
             Username = userInfoInputDto.Username,
             PasswordHash = userInfoInputDto.Password
           };
            _context.Users.Add(user);
             _context.SaveChanges();
            return user;
        }

        public bool IsAlreadyExistUsername(string username) 
        {
            
           return _context.Users.AsNoTracking().Any(u=> u.Username == username);
        }

      

        public UserInfoInputDto? GetInfoInputByUsername(string username)
        {
           return _context.Users
                .Where(user=>user.Username== username)
                .Select(user=>new UserInfoInputDto 
                {
                  Username=user.Username,
                  Password = user.PasswordHash
                }).FirstOrDefault();
        }

        public User? GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u=>u.Username== username);
        }
    }
}
