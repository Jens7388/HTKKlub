using HTKKlub.Entities;

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace HTKKlub.Services
{
    public abstract class WebServiceBase
    {
        /// <summary>
        /// Calls an API and returns a string with its JSON data
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected virtual async Task<string> CallWebApiAsync(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                httpWebRequest.Accept = "application/json";

                string result;

                using(HttpWebResponse response = await httpWebRequest.GetResponseAsync() as HttpWebResponse)
                {
                    using StreamReader sr = new StreamReader(response.GetResponseStream());
                    result = await sr.ReadToEndAsync();
                };

                return result;
            }
            catch(Exception ex)
            {
                throw new WebServiceException("No connection was established to Endpoint.", ex);
            }
        }
    }
}