using GTBA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services.DataStores
{
    public abstract class BaseDataStore<T> where T : class, new()
    {
        protected GTBAContext context = new GTBAContext();
        protected DbSet<T> table;

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            return await SaveChangesAsync();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            try
            {
                await table.AddAsync(item);

                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            T item = await GetItemAsync(id);
            table.Remove(item);

            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            int n = await context.SaveChangesAsync();

            if (n != 0)
            {
                return true;
            }
            return false;
        }
    }
}
