using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
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
        private IDictionary<string, IValidation> validations;
        public bool IsDirty { get; set; }

        public TodoItemViewModel(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
            SaveCommand = new SimpleCommand(Save, CanSave);
            DeleteCommand = new SimpleCommand(Delete);
            synchronizer = new Synchronizer<TodoItemViewModel>(() => PropertyChanged);
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
            return validations.Values.All(x => x.IsValid) && IsDirty;
        }

        private void Save()
        {
            var todoItem = todoItemRepository.Get(Id) ?? new TodoItem();
            todoItem.DueDate = DueDate;
            todoItem.Description = Description;
            todoItemRepository.Save(todoItem);
            IsDirty = false;
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                IsDirty = true;
                Update(x => x.Description);
                SaveCommand.Changed();
            }
        }

        private void Update(Expression<Func<TodoItemViewModel, object>> func)
        {
            synchronizer.Update(this, func);
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                IsDirty = true;
                Update(x => x.DueDate);
                Update(x => x.ShowDueSoonAlert);
                SaveCommand.Changed();
            }
        }

        public Visibility ShowDueSoonAlert
        {
            get
            {
                return DueDate <= DateTime.Today.AddDays(1) ? Visibility.Visible : Visibility.Hidden;
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