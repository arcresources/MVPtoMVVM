using System;
using MVPtoMVVM.presenters;

namespace MVPtoMVVM.views
{
    public interface ITodoItemView
    {
        string Description { get; set; }
        DateTime DueDate { get; set; }
        bool SaveButtonEnabled { get; set; }
        ITodoItemPresenter Presenter { get; }
    }
}