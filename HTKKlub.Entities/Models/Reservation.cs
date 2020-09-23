using HTKKlub.Utilities;

using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Reservation
    {
        protected DateTime reservationStart;
        protected DateTime reservationEnd;

        public int PkReservationId { get; set; }
        public int FkCourtId { get; set; }
        public int FkFirstMemberId { get; set; }
        public int FkSecondMemberId { get; set; }

        public DateTime ReservationStart
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
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateBefore(value, reservationEnd);
                    if(isValid)
                    {
                        ReservationStart = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(ReservationStart));
                    }
                }
            }
        }
        public DateTime ReservationEnd
        {
            get
            {
                return reservationEnd;
            }
            set
            {
                if(reservationEnd != value)
                {
                    // Using the validation class, check if the end time of the reservation is after the start time
                    (bool isValid, string errorMessage) = Validations.ValidateIsDateAfter(value, reservationEnd);
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
