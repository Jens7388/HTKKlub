using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Court
    {
        public Court()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PkCourtId { get; set; }
        public string CourtName { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
