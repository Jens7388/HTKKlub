using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Member
    {
        public Member()
        {
            Rankings = new HashSet<Ranking>();
            ReservationsFkFirstMember = new HashSet<Reservation>();
            ReservationsFkSecondMember = new HashSet<Reservation>();
        }

        public int PkMemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Reservation> ReservationsFkFirstMember { get; set; }
        public virtual ICollection<Reservation> ReservationsFkSecondMember { get; set; }
    }
}
