using HTKKlub.Entities;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HTKKlub.Desktop.Gui.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        protected ObservableCollection<Reservation> reservations;
        protected Reservation selectedReservation;

        public ReservationViewModel()
        {
            Reservations = new ObservableCollection<Reservation>();
        }

        public virtual ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }
            set
            {
                SetProperty(ref reservations, value);
            }
        }

        public virtual Reservation SelectedReservation
        {
            get
            {
                return selectedReservation;
            }
            set
            {
                SetProperty(ref selectedReservation, value);
            }
        }
    }
}
