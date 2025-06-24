using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
 public   class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Action startGame;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        public RelayCommand(Action startGame)
        {
            this.startGame = startGame;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _action(parameter);
            }
            else
            {
                _action("Error");
            }
        }

        public static implicit operator Action<object, object>(RelayCommand v)
        {
           // throw new NotImplementedException();
          return null;
        }
        #endregion

    }
}
