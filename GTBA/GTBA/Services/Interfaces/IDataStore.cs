﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTBA.Services.Interfaces
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false, string sorter = null);
        Task<IEnumerable<T>> GetItemsByTagsAsync(string tag, string sorter = null);

    }
}
