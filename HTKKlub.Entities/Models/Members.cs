using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Members
    {
        public Members()
        {
            Rankings = new HashSet<Rankings>();
            ReservationsFkFirstMember = new HashSet<Reservations>();
            ReservationsFkSecondMember = new HashSet<Reservations>();
        }

        public int PkMemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Rankings> Rankings { get; set; }
        public virtual ICollection<Reservations> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservations> ReservationsFkSecondMember { get; set; }
    }
}
