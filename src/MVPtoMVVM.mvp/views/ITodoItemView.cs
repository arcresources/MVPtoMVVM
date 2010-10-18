using System;
using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;

namespace MVPtoMVVM.views
{
    public interface ITodoItemView
    {
        int Id { get; set; }
        string Description { get; set; }
        DateTime DueDate { get; set; }
        bool SaveButtonEnabled { get; set; }
        ITodoItemPresenter Presenter { get; }
        void Remove(int itemId);
    }
}