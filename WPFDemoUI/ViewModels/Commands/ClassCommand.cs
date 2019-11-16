using System;
using System.Windows.Input;

namespace WPFDemoUI.ViewModels.Commands
{
    class ClassCommand<T> : CommandBase where T : class
    {
        private readonly Action<T> _function;

        public override event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ClassCommand(Action<T> function)
        {
            this._function = function;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            this._function.Invoke(parameter as T);
        }
    }
}
