using HW19.Domain.UserAgg.Dto;
using HW19.Domain.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.UserAgg.Contracts.Repositories
{
    public interface IUserRepository
    {
        public User? Register(UserInfoInputDto userInfoInputDto);
        public bool IsAlreadyExistUsername(string username);

        public UserInfoInputDto? GetInfoInputByUsername(string username);

        public User? GetByUsername(string username);


    }
}
