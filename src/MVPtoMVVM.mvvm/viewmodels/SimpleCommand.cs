using System;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class SimpleCommand : IObservableCommand
    {
        private readonly Action command;
        private Func<bool> predicate;

        public SimpleCommand(Action command): this(command, () => true)
        {
            
        }

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

        public event EventHandler CanExecuteChanged = (o,e)=>{};
    }
}