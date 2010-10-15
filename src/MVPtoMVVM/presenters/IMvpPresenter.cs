using MVPtoMVVM.views;

namespace MVPtoMVVM.presenters
{
    public interface IMvpPresenter
    {
        void SetView(IMvpView view);
        void AddNewItem();
        void CancelAllChanges();
    }
}