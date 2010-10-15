using MVPtoMVVM.domain;
using MVPtoMVVM.presenters;

namespace MVPtoMVVM.mappers
{
    public interface ITodoItemMapper
    {
        TodoItem MapFrom(ITodoItemPresenter presenter);
    }
}