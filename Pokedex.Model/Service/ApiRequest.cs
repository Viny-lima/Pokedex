using Newtonsoft.Json;
using Pokedex.Model.PokeApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using static Pokedex.Model.Service.UrlConstants;

namespace Pokedex.Model.Service
{
    public static class ApiRequest
    {
        public static T Get<T>(string Url)
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
                    if (dataStream == null) throw new NullReferenceException("dataStream é null !");

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

        public static PokemonAPI GetPokemonById(int Id)
        {
            var stringUrl = $"{BaseUrl}{PokemonEndpoint}{Id}";

            return Get<PokemonAPI>(stringUrl);
        }

        public static PokemonAPI GetPokemonByName(string name)
        {
            var stringUrl = $"{BaseUrl}{PokemonEndpoint}{name}";

            return Get<PokemonAPI>(stringUrl);
        }


        public static IList<PokemonAPI> GetPokemonsList(int startIndex = 0, int quantity = 10)
        {
            var url = $"{BaseUrl}{PokemonEndpoint}?limit={quantity}&offset={startIndex}";
            var pokemonsInAPI = Get<ListPokemonAPI>(url);

            IList<PokemonAPI> pokemons = new List<PokemonAPI>();

            foreach (var pokemon in pokemonsInAPI.Results)
            {
                pokemons.Add(new PokemonAPI() { Id = pokemon.Id, Name = pokemon.Name });
            }
                
            return pokemons;
        }
        
        public static IList<PokemonAPI> GetPokemonsListByType(string typeNumber)
        {
            var url = $"{BaseUrl}{TypeEndpoint}{typeNumber}";
            var typesInAPI = Get<ListPokemonTypeAPI>(url);

            IList<PokemonAPI> pokemons = new List<PokemonAPI>();

            foreach (var pokemon in typesInAPI.Pokemons)
            {
                pokemons.Add(new PokemonAPI() { Id = pokemon.PokemonItemList.Id,
                                                Name = pokemon.PokemonItemList.Name });
            }

            return pokemons;
        }
    }
}
