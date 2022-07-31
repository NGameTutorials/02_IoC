using System;
using System.Windows.Input;

namespace IoC.Models
{
    public class BasicCommand : ICommand
    {
        public BasicCommand(Action? action)
        {
            Action = action;
        }

        Action? Action { get; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; // Expresses whether the command is operable or disabled.
        }

        public void Execute(object? parameter)
        {
            // The code to execute here when the command fires.
            Action?.Invoke();
        }
    }

}
