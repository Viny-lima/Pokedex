using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Service
{
    public class ApiRequest
    {
        private T Get<T>(string Url)
        {
            var request = WebRequest.Create(Url);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json";

            try
            {
                using (HttpWebResponse reponse = (HttpWebResponse)request.GetResponse())
                using (Stream dataStream = reponse.GetResponseStream())
                {
                    if (dataStream == null) throw new NullReferenceException("dataStream Pokemon é null !");

                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseString = reader.ReadToEnd();

                        T obj = JsonConvert.DeserializeObject<T>(responseString);

                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                return default(T);
            }
        }

        public Pokemon GetPokemon(int Id)
        {
            var stringUrl = $"https://pokeapi.co/api/v2/pokemon/{Id}";

            return Get<Pokemon>(stringUrl);
        }

        public PropertiesListPokemon GetPropertiesListPokemons(int startIndex = 0, int qtdPokemons = 10)
        {
            string stringUrl = $"https://pokeapi.co/api/v2/pokemon?limit={qtdPokemons}&offset={startIndex}";

            return Get<PropertiesListPokemon>(stringUrl);
        }        

        public List<Pokemon> GetListaDePokemons(int startIndex = 0, int qtdPokemons = 10)
        {
            PropertiesListPokemon propertiesList = GetPropertiesListPokemons(startIndex, qtdPokemons);

            List<Pokemon> ListaDePokemons = new List<Pokemon>();

            foreach (AddressPokemon pokemon in propertiesList.Results)
            {
                string stringUrl = pokemon.Url.ToString();

                ListaDePokemons.Add(Get<Pokemon>(stringUrl));
            }

                
            return ListaDePokemons;
        }                    
    }
}
