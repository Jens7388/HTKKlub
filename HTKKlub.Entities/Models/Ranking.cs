using System;
using System.Collections.Generic;

namespace HTKKlub.Entities
{
    public partial class Ranking
    {
        public virtual int PkRankId { get; set; }
        public virtual int FkMemberId { get; set; }
        public virtual int Points { get; set; }

        public virtual Member FkMember { get; set; }
    }
}