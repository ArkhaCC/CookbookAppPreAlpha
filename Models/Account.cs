using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CookbookApp.Models
{
    public class Account
    {
        public string NewUserName { get; set; }

        public string Password { get; set; }
        public string VerifyPassword { get; set; }

       
    }
}
