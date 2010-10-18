using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            
            updater.Update(x => x.TodoItems);
        }

        private void AddNewItem()
        {
            TodoItems.Add(new TodoItemViewModel(todoItemRepository){Parent =  this});
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