using System.Collections.Generic;
using MVPtoMVVM.presenters;

namespace MVPtoMVVM.views
{
    public interface IMvpView
    {
        void SetTodoItems(IEnumerable<ITodoItemPresenter> presenters);
    }
}