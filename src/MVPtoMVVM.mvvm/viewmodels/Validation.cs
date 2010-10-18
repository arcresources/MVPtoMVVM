using System;

namespace MVPtoMVVM.mvvm.viewmodels
{
    class Validation : IValidation
    {
        private Func<bool> Condition;

        public Validation(Func<bool> condition, string message)
        {
            Condition = condition;
            Message = message;
        }

        public bool IsValid
        {
            get { return Condition(); }
        }

        public string Message { get;set;}
    }
}