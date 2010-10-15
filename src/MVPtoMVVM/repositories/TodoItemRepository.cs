using System;
using System.Collections.Generic;
using MVPtoMVVM.domain;
using System.Linq;

namespace MVPtoMVVM.repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private List<TodoItem> items;
        private int totalItems = 0;

        public TodoItemRepository()
        {
            items = new List<TodoItem>();
            Add(new TodoItem {Description = "First One", DueDate = DateTime.Today});
        }

        public void Add(TodoItem item)
        {
            if (item.Id == 0)
                AddItem(item);
            else
            {
                UpdateItem(item);
            }
        }

        public TodoItem Get(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return items.AsEnumerable();
        }
        private void UpdateItem(TodoItem item)
        {
            items.Remove(items.Single(x => x.Id == item.Id));
            items.Add(item);
        }

        private void AddItem(TodoItem item)
        {
            totalItems++;
            item.Id = totalItems;
            items.Add(item);
        }

    }
}