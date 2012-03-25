using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public static void Raise<TValue>(this PropertyChangedEventHandler handler, object sender, Expression<Func<TValue>> selector)
    {
      if (handler != null)
      {
        handler(sender, new PropertyChangedEventArgs(GetProperty(selector).Name));
      }
    }

    internal static PropertyInfo GetProperty(Expression expression)
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