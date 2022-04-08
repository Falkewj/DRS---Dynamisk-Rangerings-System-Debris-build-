using DRS___Dynamisk_Rangerings_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS___Dynamisk_Rangerings_System.Services
{
    public class DbService<T> : IDbService<T> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new DRSDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {

            using (var context = new DRSDbContext())
            {
                return await context.Set<T>().FindAsync(id);
            }

        }

        public async Task AddObjectAsync(T obj)
        {
            using (var context = new DRSDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveObjectAsync(T obj)
        {
            using (var context = new DRSDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new DRSDbContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }

    }
}
