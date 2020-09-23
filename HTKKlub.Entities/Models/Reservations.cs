using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Reservations
    {
        public int PkReservationId { get; set; }
        public int FkCourtId { get; set; }
        public int FkFirstMemberId { get; set; }
        public int FkSecondMemberId { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public virtual Courts FkCourt { get; set; }
        public virtual Members FkFirstMember { get; set; }
        public virtual Members FkSecondMember { get; set; }
    }
}
