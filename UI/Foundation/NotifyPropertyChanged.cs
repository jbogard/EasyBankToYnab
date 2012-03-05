using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace EasyBankRepository.Foundation
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
        public static readonly string UnknownProperty = string.Empty;

        protected virtual bool AssignAndRaisePropertyChanged<T>(ref T field, T value, params string[] propertyNames)
        {
            bool flag = false;
            if (!IsNullReference<T>(field) || !IsNullReference<T>(value))
            {
                if (IsNullReference<T>(field) || IsNullReference<T>(value))
                {
                    field = value;
                    flag = true;
                    foreach (string str in propertyNames ?? new string[0])
                    {
                        this.OnPropertyChanged(str);
                    }
                    return flag;
                }
                if (field.Equals(value))
                {
                    return flag;
                }
                field = value;
                flag = true;
                foreach (string str in propertyNames ?? new string[0])
                {
                    this.OnPropertyChanged(str);
                }
            }
            return flag;
        }

        protected static bool IsNullReference<T>(T obj)
        {
            return object.ReferenceEquals(obj, null);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, e);
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<TValue>(Expression<Func<TValue>> selector)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(GetProperty(selector).Name));
        }

        private static PropertyInfo GetProperty(Expression expression)
        {
            if (expression is LambdaExpression)
            {
                expression = ((LambdaExpression)expression).Body;
            }
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (PropertyInfo)((MemberExpression)expression).Member;
                default:
                    throw new InvalidOperationException("Expression does not contain a property.");
            }
        }

    }
}

