using MVPtoMVVM.domain;
using MVPtoMVVM.views;

namespace MVPtoMVVM.presenters
{
    public interface ITodoItemPresenter
    {
        void SetView(ITodoItemView view);
        void SetItem(TodoItem item);
    }
}