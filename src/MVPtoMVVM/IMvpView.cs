using System.Collections.Generic;
using MVPtoMVVM.domain;

namespace MVPtoMVVM
{
    public interface IMvpView
    {
        void SetTodoItems(IEnumerable<TodoItem> items);
    }
}