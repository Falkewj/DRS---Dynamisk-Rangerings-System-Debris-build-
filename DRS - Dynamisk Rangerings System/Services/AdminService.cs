using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.MockData;
using DRS___Dynamisk_Rangerings_System.Models;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    public class AdminService : IAdminService
    {
        public List<Admin> Admins { get; set; }
        private JsonFileService<Admin> JsonFileService { get; set; }


        public AdminService()
        {
            //JsonFileService = jsonFileService;
            Admins = MockAdmins.GetMockAdmins();
            //Admins = JsonFileService.GetJsonObjects().ToList();
            //JsonFileService.SaveJsonObjects(Admins);
        }
      
        public IEnumerable<Admin> GetAdmins()
        {
            return MockAdmins.GetMockAdmins();
        }
    }
}
