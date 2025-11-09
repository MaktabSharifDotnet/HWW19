using HW19.Domain.Contracts.Repositories;
using HW19.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int Register(string username, string password) 
        {
            bool result=  _userRepository.IsAlreadyExistUsername(username);
            if (result) 
            {
                throw new Exception("این نام کاربری قبلا توسط یک کاربر دیگر استفاده شده است ");
            }
            string passwordHash = HashPassword(password);
            return _userRepository.Register(username, passwordHash);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
              
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
