using System;
using MVPtoMVVM.mvp.views;

namespace MVPtoMVVM.mvp.presenters
{
    public interface ITodoItemPresenter
    {
        void SetView(ITodoItemView view);
        void SaveItem();
        void DeleteItem();
        int Id { get; set; }
        string Description { get; set; }
        DateTime DueDate { get; set; }
    }
}