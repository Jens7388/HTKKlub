using HTKKlub.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HTKKlub.DataAccess
{
    public class ReservationRepository : RepositoryBase<Reservation>
    {
        /// <summary>
        /// Returns all reservations along with the reserved court
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await context.Set<Reservation>().Include("FkCourt").ToListAsync();
        }
    }
}