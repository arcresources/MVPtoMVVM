using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using MVPtoMVVM.domain;
using MVPtoMVVM.repositories;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ITodoItemRepository todoItemRepository;
        private Synchronizer<MainWindowViewModel> updater;

        public MainWindowViewModel(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
            AddNewItemCommand = new SimpleCommand(AddNewItem);
            CancelChangesCommand = new SimpleCommand(RefreshChanges);
            updater = new Synchronizer<MainWindowViewModel>(this.PropertyChanged);
            RefreshChanges();
        }

        private void RefreshChanges()
        {
            TodoItems = new ObservableCollection<TodoItemViewModel>(todoItemRepository.GetAll().Select(MapFrom));
            updater.Update(x => x.TodoItems);
        }

        private void AddNewItem()
        {
            var todoItem = new TodoItem();
            todoItemRepository.Save(todoItem);

            TodoItems.Add(MapFrom(todoItem));
            updater.Update(x => x.TodoItems);
        }

        private TodoItemViewModel MapFrom(TodoItem x)
        {
            return new TodoItemViewModel(todoItemRepository)
                       {
                           Id = x.Id,
                           Description =  x.Description,
                           DueDate = x.DueDate,                                                                        
                           Parent = this,
                       };
        }

        public ICollection<TodoItemViewModel> TodoItems { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = (o,e)=> { };
        public ICommand CancelChangesCommand { get; set; }
        public ICommand AddNewItemCommand { get; set; }

        public void Update(Expression<Func<MainWindowViewModel, object>> property)
        {
            updater.Update(property);
        }
    }
}