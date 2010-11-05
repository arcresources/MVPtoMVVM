using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class Synchronizer<T> where T : INotifyPropertyChanged
    {
        private readonly Func<PropertyChangedEventHandler> eventHandler;

        public Synchronizer(Func<PropertyChangedEventHandler> eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        public void Update(T viewModel, Expression<Func<T, object>> property)
        {
            eventHandler()(viewModel, new PropertyChangedEventArgs(GetPropertyNameFrom(property)));
        }

        string GetPropertyNameFrom(Expression<Func<T, object>> property)
        {
            if (property.Body.NodeType == ExpressionType.Convert)
            {
                var body = (UnaryExpression)property.Body;
                return (body.Operand as MemberExpression).Member.Name;
            }
            if (property.Body.NodeType == ExpressionType.MemberAccess)
            {
                return (property.Body as MemberExpression).Member.Name;
            }
            return "";
        }
    }
}