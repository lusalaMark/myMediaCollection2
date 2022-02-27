using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace myMediaCollection2.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> canExecute;
        public RelayCommand(Action action)
        : this(action, null)
        {
        }
        public RelayCommand(Action action, Func<bool> canExecute)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            this.action = action;
            this.canExecute = canExecute;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public bool CanExecute(object parameter) => canExecute ==null || canExecute();
        public void Execute(object parameter) => action();
        public event EventHandler<object> CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
