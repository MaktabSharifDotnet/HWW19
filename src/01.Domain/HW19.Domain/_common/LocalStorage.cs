using HW19.Domain.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW19.Domain._common
{
    public static class LocalStorage
    {
        public static User LoginUser { get;private set; }

        public static void Login (User user) 
        {
            LoginUser = user;
        }

        public static void LogOut() 
        {
            LoginUser = null;
        }
    }
}
