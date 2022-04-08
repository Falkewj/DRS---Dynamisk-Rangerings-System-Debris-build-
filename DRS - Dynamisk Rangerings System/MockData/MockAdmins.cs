using DRS___Dynamisk_Rangerings_System.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DRS___Dynamisk_Rangerings_System.MockData
{
    public class MockAdmins
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<Admin> admins = new List<Admin>()
        {
            new Admin("admin", passwordHasher.HashPassword(null, "secret")),
            new Admin("saim", passwordHasher.HashPassword(null, "123"))
        };

        public static List<Admin> GetMockAdmins()
        {
            return admins;
        }
        
    }
}