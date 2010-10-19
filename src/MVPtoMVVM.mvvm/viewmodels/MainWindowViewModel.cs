﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MVPtoMVVM.domain;
using MVPtoMVVM.repositories;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ITodoItemRepository todoItemRepository;
        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };
        public ICollection<TodoItemViewModel> TodoItems { get; set; }
        public ICommand CancelChangesCommand { get; set; }
        public ICommand AddNewItemCommand { get; set; }

        public MainWindowViewModel(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
            AddNewItemCommand = new SimpleCommand(AddNewItem);
            CancelChangesCommand = new SimpleCommand(RefreshChanges);
            TodoItems = new ObservableCollection<TodoItemViewModel>();
            RefreshChanges();
        }

        private void RefreshChanges()
        {
            TodoItems.Clear();
            foreach (var item in todoItemRepository.GetAll().Select(MapFrom))
            {
                TodoItems.Add(item);
            }
        }

        private TodoItemViewModel MapFrom(TodoItem item)
        {
            return new TodoItemViewModel(todoItemRepository)
                       {
                           Id = item.Id,
                           Description = item.Description,
                           DueDate = item.DueDate,
                           Parent = this,
                           IsDirty = false,
                       };
        }

        private void AddNewItem()
        {
            TodoItems.Add(new TodoItemViewModel(todoItemRepository)
                              {
                                  Parent =  this, 
                                  DueDate = DateTime.Today, 
                                  Description = string.Empty,
                                  IsDirty = false,
                              });
        }
    }
}