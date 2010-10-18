using MVPtoMVVM.domain;
using MVPtoMVVM.mvp.presenters;

namespace MVPtoMVVM.mvp.mappers
{
    public interface ITodoItemMapper
    {
        TodoItem MapFrom(ITodoItemPresenter presenter);
    }
}