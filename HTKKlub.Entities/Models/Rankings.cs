using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Rankings
    {
        public int PkRankId { get; set; }
        public int FkMemberId { get; set; }
        public int Points { get; set; }

        public virtual Members FkMember { get; set; }
    }
}
