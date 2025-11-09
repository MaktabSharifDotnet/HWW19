using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.Contracts.Services
{
    public interface IUserService
    {
        public int Register(string username, string password);
    }
}
