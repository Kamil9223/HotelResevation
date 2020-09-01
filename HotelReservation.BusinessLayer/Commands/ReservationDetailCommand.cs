using System;
using System.Windows.Input;

namespace HotelReservation.BusinessLayer.Commands
{
    public class ReservationDetailCommand : ICommand
    {
        private Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public ReservationDetailCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {            
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
