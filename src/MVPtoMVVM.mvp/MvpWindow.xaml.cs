using System.Collections.Generic;
using System.Linq;
using MVPtoMVVM.presenters;
using MVPtoMVVM.views;
using StructureMap;

namespace MVPtoMVVM.mvp
{
    public partial class MvpWindow : IMvpView
    {
        private IMvpPresenter presenter;

        public MvpWindow()
        {
            InitializeComponent();
            presenter = ObjectFactory.GetInstance<IMvpPresenter>();
            presenter.SetView(this);
        }

        public void SetTodoItems(IEnumerable<ITodoItemPresenter> presenters)
        {
            todoItemsList.ItemsSource = presenters.Select(x => new TodoItemView(x));
        }

    }
}
