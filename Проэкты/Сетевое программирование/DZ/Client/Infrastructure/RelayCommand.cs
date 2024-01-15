using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Infrastracture
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        //public event EventHandler CanExecuteChanged;
        //лучше добавить...
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
    //public class RelayCommand : System.Windows.Input.ICommand
    //{
    //    readonly Action<object> action;
    //    readonly Predicate<object> predicate;
    //
    //    public RelayCommand(Action<object> action, Predicate<object> predicate = null)
    //    {
    //        this.action = action;
    //        this.predicate = predicate;
    //    }
    //
    //    public event EventHandler CanExecuteChanged
    //    {
    //        add
    //        {
    //            CommandManager.RequerySuggested += value;
    //        }
    //        remove
    //        {
    //            CommandManager.RequerySuggested -= value;
    //        }
    //    }
    //
    //    public bool CanExecute(object parameter)
    //    {
    //        return predicate == null ? true : predicate(parameter);
    //    }
    //
    //    public void Execute(object parameter)
    //    {
    //        action(parameter);
    //    }
    //}
}
