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
        protected string phoneNumber;

        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationsFkFirstMember = new HashSet<Reservation>();
            ReservationsFkSecondMember = new HashSet<Reservation>();
        }

        public virtual int PkMemberId{ get; set; }

        public virtual string Name 
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

        public virtual string Address 
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

        public virtual string Email 
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

        public virtual string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                if(phoneNumber != value)
                {
                    // Using the validation class, check if the string is not null
                    (bool isValid, string errorMessage) = Validations.ValidateIsStringNull(value);
                    if(isValid)
                    {
                        PhoneNumber = value;
                    }
                    else
                    {
                        throw new ArgumentException(errorMessage, nameof(PhoneNumber));
                    }
                }
            }
        }

        public virtual DateTime BirthDate { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationsFkSecondMember { get; set; }
    }
}
