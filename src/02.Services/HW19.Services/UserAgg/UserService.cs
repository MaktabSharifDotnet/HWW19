using HW19.Domain._common;
using HW19.Domain.UserAgg.Contracts.Repositories;
using HW19.Domain.UserAgg.Contracts.Services;
using HW19.Domain.UserAgg.Dto;
using HW19.Domain.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Services.UserAgg
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Login(UserInfoInputDto userInfoInputDto)
        {
            User? user= _userRepository.GetByUsername(userInfoInputDto.Username);
            string passHash = HashPassword(userInfoInputDto.Password);

            if (user==null||user.PasswordHash!=passHash)
            {
                throw new Exception("نام کاربری یا رمز عبور اشتباه است. ");
            }
            LocalStorage.Login(user);
            return user.Id;
        }

        public User? Register(UserInfoInputDto userInfoInputDto) 
        {
            bool result=  _userRepository.IsAlreadyExistUsername(userInfoInputDto.Username);
            if (result) 
            {
                throw new Exception("این نام کاربری قبلا توسط یک کاربر دیگر استفاده شده است ");
            }
            string passwordHash = HashPassword(userInfoInputDto.Password);
            userInfoInputDto.Password=passwordHash;
            return _userRepository.Register(userInfoInputDto);
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
