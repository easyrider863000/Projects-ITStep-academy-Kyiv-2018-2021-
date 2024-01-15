using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API_MARVEL.Models
{
    public class NetworkManager
    {
        public async Task<string> GetJson(string url)
        {
            //WebClient client = new WebClient();
            //return client.DownloadString(url);
            HttpClient client = new HttpClient();
            return await client.GetStringAsync(url);
        }

    }
}
