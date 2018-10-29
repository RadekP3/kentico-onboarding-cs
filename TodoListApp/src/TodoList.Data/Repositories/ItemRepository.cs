using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Contracts.Data;
using TodoList.Contracts.Models;

namespace TodoList.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private Item[] _items =
        {
            new Item {Id = new Guid("9cece279-9343-4214-b03f-1062a047727e"), Text = "First"},
            new Item {Id = new Guid("5f24635c-e42f-4c99-8156-a8b94b213d0b"), Text = "Second"},
            new Item {Id = new Guid("779f5f6a-a31d-4956-98bd-3ac7d20993e7"), Text = "Third"}
        };

        public IEnumerable<Item> GetAllItems()
        {
            return _items;
        }

        public Item GetItem(Guid id)
        {
            return _items.FirstOrDefault(p => p.Id == id);
        }

        public void AddItem(Item item)
        {
            _items[_items.Length] = item;
        }

        public void DeleteItem(Guid itemId)
        {
            _items = _items.Where(p => p.Id != itemId).ToArray();

        }
    }
}