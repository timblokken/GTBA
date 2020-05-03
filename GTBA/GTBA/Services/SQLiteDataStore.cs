using GTBA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GTBA.Services
{
    public class SQLiteDataStore : IDataStore<Item>
    {
        private ItemContext context = new ItemContext();

        public SQLiteDataStore()
        {
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                //item.Id = 1;
                await context.Items.AddAsync(item);

                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            Item item = await GetItemAsync(id);
            context.Items.Remove(item);

            return await SaveChangesAsync();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            //korte versie
            return await context.Items.SingleAsync(item => item.Id == id);

            //lange versie
            /*var todoItem = from item in context.Items
                           where item.Id == id
                           select item;

            return await todoItem.SingleAsync(); */
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await context.Items.ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Item item)
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
