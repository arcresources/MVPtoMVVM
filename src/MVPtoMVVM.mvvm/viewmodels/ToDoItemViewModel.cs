using System;
using System.ComponentModel;
using System.Windows.Input;
using MVPtoMVVM.repositories;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class TodoItemViewModel : INotifyPropertyChanged
    {
        private readonly ITodoItemRepository todoItemRepository;
        private Synchronizer<TodoItemViewModel> updater;

        public TodoItemViewModel(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
            SaveCommand = new SimpleCommand(Save, CanSave);
            DeleteCommand = new SimpleCommand(Delete);
            updater = new Synchronizer<TodoItemViewModel>(PropertyChanged);
        }

        private void Delete()
        {
            todoItemRepository.Delete(Id);
            Parent.TodoItems.Remove(this);
            Parent.Update(x => x.TodoItems);
        }

        private bool CanSave()
        {
            return !string.IsNullOrEmpty(Description) && DueDate >= DateTime.Today;
        }

        private void Save()
        {
            var todoItem = todoItemRepository.Get(Id);
            todoItem.DueDate = DueDate;
            todoItem.Description = Description;
            todoItemRepository.Save(todoItem);
        }

        public event PropertyChangedEventHandler PropertyChanged = (o,e)=> { };
        public int Id { get; set; }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                updater.Update(x => x.Description);
                SaveCommand.Changed();
            }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; 
                updater.Update(x => x.DueDate);
                SaveCommand.Changed();
            }
        }

        public IObservableCommand SaveCommand { get; set; }
        public IObservableCommand DeleteCommand { get; set; }
        public MainWindowViewModel Parent { get; set; }
    }
}