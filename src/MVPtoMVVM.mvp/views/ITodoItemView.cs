using System;
using MVPtoMVVM.mvp.presenters;

namespace MVPtoMVVM.mvp.views
{
    public interface ITodoItemView
    {
        int Id { get; set; }
        string Description { get; set; }
        DateTime DueDate { get; set; }
        bool SaveButtonEnabled { get; set; }
        ITodoItemPresenter Presenter { get; }
        bool DescriptionHasValidationErrors { set; }
        bool DueDateHasValidationErrors { set; }
        bool IsDueSoon { set; }
        string DescriptionValidationMessage { set; }
        string DueDateValidationMessage { set; }
        void Remove(int itemId);
    }
}