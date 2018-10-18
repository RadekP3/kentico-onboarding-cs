using System;

namespace TodoList.Api.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = "";
        public override string ToString()
        {
            return $"Id: {Id}, Text: {Text}";
        }
    }
}