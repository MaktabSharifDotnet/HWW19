using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        public int Register(string username, string hashedPassword);
        public bool IsAlreadyExistUsername(string username);
    }
}
