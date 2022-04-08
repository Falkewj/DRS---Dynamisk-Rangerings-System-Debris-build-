using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRS___Dynamisk_Rangerings_System.Models;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAdmins();
    }
}
