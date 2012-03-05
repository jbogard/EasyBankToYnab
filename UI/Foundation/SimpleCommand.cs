using System;
using System.Windows.Input;

namespace QuestMaster.EasyBankRepository.UI.Foundation
{
  public class SimpleCommand : ICommand
    {
      public event EventHandler CanExecuteChanged;
        private readonly Func<object, bool> canExecuteMethod;
        private readonly Action<object> executeMethod;


        public SimpleCommand(Action<object> executeMethod) : this(executeMethod, null)
        {
        }

        public SimpleCommand(Action<object> executeMethod, Func<object, bool> canExecuteChangedMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteChangedMethod;
        }

        public bool CanExecute(object parameter)
        {
            return ((this.canExecuteMethod == null) ? true : this.canExecuteMethod(parameter));
        }

        public void Execute(object parameter)
        {
            this.executeMethod(parameter);
        }

        public void OnCanExecuteChanged(EventArgs e)
        {
            EventHandler canExecuteChanged = this.CanExecuteChanged;
            if (canExecuteChanged != null)
            {
                canExecuteChanged(this, e);
            }
        }
    }
}

