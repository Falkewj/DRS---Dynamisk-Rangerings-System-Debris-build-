using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    interface IJsonFileService<T>
    {
        public IEnumerable<T> GetJsonObjects();
        public void SaveJsonObjects(List<T> objects);

    }
}
