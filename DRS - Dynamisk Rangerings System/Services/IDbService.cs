using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    interface IDbService<T>
    {
        public Task<IEnumerable<T>> GetObjectsAsync();
        public Task<T> GetObjectByIdAsync(int id);
        public Task AddObjectAsync(T obj);
        public Task RemoveObjectAsync(T obj);
        public Task UpdateObjectAsync(T obj);
    }
}
