﻿using System;
using System.Collections.Generic;
using MVPtoMVVM.domain;
using System.Linq;

namespace MVPtoMVVM.repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private List<TodoItem> items;

        public TodoItemRepository()
        {
            items = new List<TodoItem>();
            items.Add(new TodoItem {Description = "First One", DueDate = DateTime.Today});
        }

        public void Add(TodoItem item)
        {
            items.Add(item);
        }

        public TodoItem Get(string description)
        {
            return items.FirstOrDefault(x => x.Description == description);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return items.AsEnumerable();
        }
    }
}