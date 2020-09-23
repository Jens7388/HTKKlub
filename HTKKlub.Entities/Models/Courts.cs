using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Courts
    {
        public Courts()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int PkCourtId { get; set; }
        public string CourtName { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
