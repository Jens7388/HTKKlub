using HTKKlub.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKKlub.DataAccess.Repos
{
    public class RankingRepository: RepositoryBase<Ranking>
    {
        /// <summary>
        /// Returns the rankings along with their members
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Ranking>> GetAllAsync()
        {
            return await context.Set<Ranking>().OrderByDescending(r => r.Points).ToListAsync();
        }
    }
}