using MVPtoMVVM.mvp.views;

namespace MVPtoMVVM.mvp.presenters
{
    public interface IMvpPresenter
    {
        void SetView(IMvpView view);
        void AddNewItem();
        void CancelAllChanges();
        void Remove(int itemId);
    }
}