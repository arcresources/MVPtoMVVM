using System;

namespace MVPtoMVVM.views
{
    public interface ITodoItemView
    {
        string Description { get; set; }
        DateTime DueDate { get; set; }
    }
}