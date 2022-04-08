using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DRS___Dynamisk_Rangerings_System.Models
{
    public class Admin
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        
        public Admin()
        {
            
        }
    }
}   
