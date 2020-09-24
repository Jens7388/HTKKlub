using HTKKlub.Utilities;

using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Court
    {
        protected string courtName;

        public Court()
        {
            Reservations = new HashSet<Reservation>();
        }

        public virtual int PkCourtId { get; set; }

        public virtual string CourtName
        {
            get
            {
                return courtName;
            }

            set
            {
                if(courtName != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        courtName = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(CourtName));
                    }
                }
            }
        }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}