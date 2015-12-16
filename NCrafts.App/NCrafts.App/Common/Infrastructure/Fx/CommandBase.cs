using System;
using System.Windows.Input;

namespace NCrafts.App.Common.Infrastructure.Fx
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public virtual bool CanExecute()
        {
            return true;
        }

        public abstract void Execute();

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }
    }

    public abstract class CommandBase<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public virtual bool CanExecute(T obj)
        {
            return true;
        }

        public abstract void Execute(T session);

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute((T) parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute((T) parameter);
        }
    }
}
