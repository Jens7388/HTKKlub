using HTKKlub.Utilities;

using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Reservation
    {
        protected DateTime reservationStart;
        protected DateTime reservationEnd;

        public virtual int PkReservationId { get; set; }
        public virtual int FkCourtId { get; set; }
        public virtual int FkFirstMemberId { get; set; }
        public virtual int FkSecondMemberId { get; set; }

        public virtual DateTime ReservationStart
        {
            get
            {
                return reservationStart;
            }
            set
            {
                if(reservationStart != value)
                {
                    // Using the validation class, check if the start time of the reservation is before the end time
                    (bool isValid, string errorMessage) = Validations.ValidateReservationDates(value, reservationEnd);
                    if(isValid)
                    {
                        reservationStart = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(ReservationStart));
                    }
                }
            }
        }

        public virtual DateTime ReservationEnd
        {
            get
            {
                return reservationEnd;
            }
            set
            {
                if(reservationEnd != value)
                {
                    // Using the validation class, check if the start time of the reservation is before the end time
                    (bool isValid, string errorMessage) = Validations.ValidateReservationDates(value, reservationEnd);
                    if(isValid)
                    {
                        reservationEnd = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(ReservationEnd));
                    }
                }
            }
        }

        public virtual Court FkCourt { get; set; }
        public virtual Member FkFirstMember { get; set; }
        public virtual Member FkSecondMember { get; set; }
    }
}