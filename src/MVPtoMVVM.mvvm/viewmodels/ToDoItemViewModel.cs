using System;
using System.Collections.Generic;
using System.ComponentModel;
using MVPtoMVVM.domain;
using MVPtoMVVM.repositories;
using System.Linq;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class TodoItemViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly ITodoItemRepository todoItemRepository;
        private Synchronizer<TodoItemViewModel> synchronizer;
        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };
        public int Id { get; set; }
        public IObservableCommand SaveCommand { get; set; }
        public IObservableCommand DeleteCommand { get; set; }
        public MainWindowViewModel Parent { get; set; }

        public TodoItemViewModel(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
            SaveCommand = new SimpleCommand(Save, CanSave);
            DeleteCommand = new SimpleCommand(Delete);
            synchronizer = new Synchronizer<TodoItemViewModel>(PropertyChanged);
            validations = new Dictionary<string, IValidation>
                              {
                                  {"Description", new Validation(() => !string.IsNullOrEmpty(Description), "Cannot have an empty description.")},
                                  {"DueDate", new Validation(() => DueDate >= DateTime.Today, "Due Date must occur on or after today.")}
                              };
        }

        private void Delete()
        {
            todoItemRepository.Delete(Id);
            Parent.TodoItems.Remove(this);
        }

        private bool CanSave()
        {
            return validations.Values.All(x => x.IsValid);
        }

        private void Save()
        {
            var todoItem = todoItemRepository.Get(Id) ?? new TodoItem();
            todoItem.DueDate = DueDate;
            todoItem.Description = Description;
            todoItemRepository.Save(todoItem);
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                synchronizer.Update(x => x.Description);
                SaveCommand.Changed();
            }
        }

        private DateTime dueDate;
        private IDictionary<string, IValidation> validations;

        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value; 
                synchronizer.Update(x => x.DueDate);
                synchronizer.Update(x => x.ShowDueSoonAlert);
                SaveCommand.Changed();
            }
        }

        public bool ShowDueSoonAlert
        {
            get
            {
                return DueDate <= DateTime.Today.AddDays(1);
            }
        }

        public string this[string columnName]
        {
            get
            {
                var validation = validations[columnName];
                return validation.IsValid ? null : validation.Message;
            }
        }

        public string Error
        {
            get { return string.Empty; }
        }
    }
}