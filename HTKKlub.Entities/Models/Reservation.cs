using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Reservation
    {
        public int PkReservationId { get; set; }
        public int FkCourtId { get; set; }
        public int FkFirstMemberId { get; set; }
        public int FkSecondMemberId { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public virtual Court FkCourt { get; set; }
        public virtual Member FkFirstMember { get; set; }
        public virtual Member FkSecondMember { get; set; }
    }
}
