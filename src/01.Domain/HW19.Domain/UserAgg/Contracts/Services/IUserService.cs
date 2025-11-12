using HW19.Domain.UserAgg.Dto;
using HW19.Domain.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.UserAgg.Contracts.Services
{
    public interface IUserService
    {
        public int Login(UserInfoInputDto userInfoInputDto);
        public User? Register(UserInfoInputDto userInfoInputDto);
    }
}
