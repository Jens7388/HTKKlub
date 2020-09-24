using HTKKlub.Entities;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HTKKlub.Services
{
    public class RankingService: WebServiceBase
    {
        /// <summary>
        /// Returns a list of all order objects.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<Ranking>> GetAllAsync()
        {
            try
            {
                // Call the web API
                string json = await CallWebApiAsync("http://localhost:64637/ranking/all");

                // Deserialize the JSON data into an object list
                List<Ranking> rankingData = JsonConvert.DeserializeObject<List<Ranking>>(json);

                // Return the object list
                return rankingData;
            }
            catch
            {
                throw;
            }
        }
    }
}