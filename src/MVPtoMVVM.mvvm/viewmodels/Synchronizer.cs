using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MVPtoMVVM.mvvm.viewmodels
{
    public class Synchronizer<T> where T : INotifyPropertyChanged
    {
        private readonly PropertyChangedEventHandler eventHandler;

        public Synchronizer(PropertyChangedEventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        public void Update(Expression<Func<T, object>> property)
        {
            eventHandler(null, new PropertyChangedEventArgs(GetPropertyNameFrom(property)));
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