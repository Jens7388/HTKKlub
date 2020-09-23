using HTKKlub.Utilities;

using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Member
    {
        protected string name;
        protected string address;
        protected string email;

        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationsFkFirstMember = new HashSet<Reservation>();
            ReservationsFkSecondMember = new HashSet<Reservation>();
        }

        public int PkMemberId
        { get; set; }

        public string Name 
        {
            get
            {
                return name;
            }

            set
            {
                if(name != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        Name = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(Name));
                    }
                }
            }
        }

        public string Address 
        {
            get
            {
                return address;
            }

            set
            {
                if(address != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        Address = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(Address));
                    }
                }
            }
        }

        public string Email 
        {
            get
            {
                return email;
            }

            set
            {
                if(email != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        Email = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(Email));
                    }
                }
            }
        }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationsFkSecondMember { get; set; }
    }
}
