namespace MVPtoMVVM.mvvm.viewmodels
{
    public interface IValidation
    {
        bool IsValid { get; }
        string Message { get;  }
    }
}