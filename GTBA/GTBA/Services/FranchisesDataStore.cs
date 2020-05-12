using GTBA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services
{
    public class FranchisesDataStore : IDataStore<Franchise>
    {
        private GTBAContext context = new GTBAContext();

        public FranchisesDataStore()
        {
        }

        public async Task<bool> AddItemAsync(Franchise franchise)
        {
            try
            {
                //item.Id = 1;
                await context.Franchises.AddAsync(franchise);

                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            Franchise franchise = await GetItemAsync(id);
            context.Franchises.Remove(franchise);

            return await SaveChangesAsync();
        }

        public async Task<Franchise> GetItemAsync(int id)
        {
            //korte versie
            return await context.Franchises.SingleAsync(item => item.FranchiseId == id);

            //lange versie
            /*var todoItem = from item in context.Items
                           where item.Id == id
                           select item;

            return await todoItem.SingleAsync(); */
        }

        public async Task<IEnumerable<Franchise>> GetItemsAsync(bool forceRefresh = false)
        {
            return await context.Franchises.ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Franchise franchise)
        {
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
