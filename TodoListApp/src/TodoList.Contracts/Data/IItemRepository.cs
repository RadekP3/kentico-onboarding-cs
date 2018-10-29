using System;
using System.Collections.Generic;
using TodoList.Contracts.Models;

namespace TodoList.Contracts.Data
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(Guid itemId);
        void AddItem(Item item);
        void DeleteItem(Guid itemId);
    }
}