using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using MVPtoMVVM.domain;
using MVPtoMVVM.repositories;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class TodoItemViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly ITodoItemRepository todoItemRepository;
        public IObservableCommand SaveCommand { get; set; }
        public IObservableCommand DeleteCommand { get; set; }
        public MainWindowViewModel Parent { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };
        public int Id { get; set; }
        private readonly IDictionary<string, IValidation> validations;
        public bool IsDirty { get; set; }

        public TodoItemViewModel(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
            SaveCommand = new SimpleCommand(Save, CanSave);
            DeleteCommand = new SimpleCommand(Delete);
            validations = new Dictionary<string, IValidation>
                              {
                                  {
                                      "Description",
                                      new Validation(() => !string.IsNullOrEmpty(Description),
                                                    "Cannot have an empty description.")
                                  },
                                  {
                                      "DueDate", 
                                      new Validation(() => DueDate >= DateTime.Today, 
                                                     "Due Date must occur on or after today.")
                                  }
                              };
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

        private void Delete()
        {
            todoItemRepository.Delete(Id);
            Parent.TodoItems.Remove(this);
        }
        
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                IsDirty = true;
                PropertyChanged(null, new PropertyChangedEventArgs("Description"));
                SaveCommand.Changed();
            }
        }

        private DateTime dueDate;

        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                IsDirty = true;

                PropertyChanged(this, new PropertyChangedEventArgs("DueDate"));
                PropertyChanged(this, new PropertyChangedEventArgs("ShowAlert"));
                SaveCommand.Changed();
            }
        }

        public Visibility ShowAlert
        {
            get { return DueDate <= DateTime.Today.AddDays(1) ? Visibility.Visible : Visibility.Hidden; }
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