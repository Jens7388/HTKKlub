using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTKKlub.DataAccess.Repos;
using HTKKlub.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTKKlub.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RankingController
    {
        [HttpGet("all")]
        public async Task<IEnumerable<Ranking>> GetAllAsync()
        {
            return await new RankingRepository().GetAllAsync();
        }
    }
}
