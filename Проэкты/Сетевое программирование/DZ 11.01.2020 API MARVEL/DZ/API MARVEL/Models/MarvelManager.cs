using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace API_MARVEL.Models
{
    public class MarvelManager
    {

        string baseUrl = "http://gateway.marvel.com/v1/public/";
        NetworkManager networkManager;
        public int Total { get; set; }
        public int Limit { get; set; }
        public MarvelManager()
        {
            networkManager = new NetworkManager();
        }

        public async Task<List<MarvelCharacter>> GetCharacters(int offset, int count)
        {
            string url = $"{baseUrl}characters?offset={offset}&limit={count}&ts={APIConfig.TimeStamp}&apikey={APIConfig.PublicKey}&hash={APIConfig.Hash()}";
            string json = await networkManager.GetJson(url);
            
            JObject googleSearch = JObject.Parse(json);
            IList<JToken> results = googleSearch["data"]["results"].Children().ToList();
            Total = googleSearch["data"]["total"].Value<int>();
            Limit = googleSearch["data"]["limit"].Value<int>();
            IList<MarvelCharacter> marvelCharacters = new List<MarvelCharacter>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                MarvelCharacter character = new MarvelCharacter
                {
                    Name = result["name"].ToString(),
                    ImageUrl = $"{result["thumbnail"]["path"].ToString()}.{result["thumbnail"]["extension"].ToString()}"
                };
                marvelCharacters.Add(character);
            }
            return marvelCharacters.ToList();
        }
    }
}
