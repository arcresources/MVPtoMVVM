using System.Windows.Input;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public interface IObservableCommand : ICommand
    {
        void Changed();
    }
}