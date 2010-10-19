using System;
using System.Windows.Input;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public interface IObservableCommand : ICommand
    {
        void Changed();
    }

    public class SimpleCommand : IObservableCommand
    {
        private readonly Action command;
        private readonly Func<bool> predicate;
        public event EventHandler CanExecuteChanged = (o, e) => { };

        public SimpleCommand(Action command): this(command, () => true) {}

        public SimpleCommand(Action command, Func<bool> predicate)
        {
            this.command = command;
            this.predicate = predicate;
        }

        public void Execute(object parameter)
        {
            command();
        }

        public bool CanExecute(object parameter)
        {
            return predicate();
        }

        public void Changed()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

    }
}