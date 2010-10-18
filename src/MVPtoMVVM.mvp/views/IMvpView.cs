using System.Collections.Generic;
using MVPtoMVVM.mvp.presenters;

namespace MVPtoMVVM.mvp.views
{
    public interface IMvpView
    {
        void SetTodoItems(IEnumerable<ITodoItemPresenter> presenters);
        IEnumerable<ITodoItemPresenter> GetTodoItems();
    }
}