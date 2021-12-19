using Newtonsoft.Json;
using Pokedex.Model.Enums;
using Pokedex.Model.PokeApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Pokedex.Model.Service
{
    public static class ApiRequest
    {

        /// <summary>
        /// Método genérico de Requisições <see cref="WebRequest"/> usando a <paramref name="Url"/> passada no parâmetro.
        /// Em seguida ocorre um <see cref="JsonConvert.DeserializeObject(string)"/> no <see cref="object"/> do tipo <paramref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Tipo <see cref="object"/> a ser deserializado do Json</typeparam>.
        /// <param name="Url">Url usada para requisição <see cref="WebRequest.Create()"/></param>
        /// <returns> Retona um <see cref="Object"/> do tipo especificado .</returns>
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

        /// <summary>
        /// Método genérico de Requisições <see cref="WebRequest"/> usando a <paramref name="Url"/> passada no parâmetro.
        /// Em seguida ocorre um <see cref="JsonConvert.DeserializeObject(string)"/> no <see cref="object"/> do tipo <paramref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Tipo <see cref="object"/> a ser deserializado do Json</typeparam>.
        /// <param name="Url">Url usada para requisição <see cref="WebRequest.Create()"/></param>
        /// <returns> Retona um <see cref="Object"/> do tipo especificado .</returns>
        public static T Get<T>(Uri Url)
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

        /// <summary>
        /// Responsável construção de um <see cref="Object"/> da class <see cref="PokemonAPI"/> apartir de um Json da API. Gerado por uma Url + <paramref name="Id"/>.
        /// </summary>
        /// <param name="Id">Index do Pokemon na API></param>
        /// <returns>Um object <see cref="PokemonAPI"/> construido pela API.</returns>
        public static PokemonAPI GetPokemon(int Id)
        {
            var stringUrl = $"https://pokeapi.co/api/v2/pokemon/{Id}";

            return Get<PokemonAPI>(stringUrl);
        }

        /// <summary>
        /// Responsável construção de um <see cref="Object"/> da class <see cref="PokemonAPI"/> apartir de um Json da API. Gerado por uma Url + <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Nome do Pokemon na API></param>
        /// <returns>Um object <see cref="PokemonAPI"/> construido pela API.</returns>
        public static PokemonAPI GetPokemon(string name)
        {
            var stringUrl = $"https://pokeapi.co/api/v2/pokemon/{name}";

            return Get<PokemonAPI>(stringUrl);
        }

        /// <summary>
        /// Responsável construção de um <see cref="Object"/> da class <see cref="PokemonPropertiesList"/> apartir de um Json da API.
        /// </summary>
        /// <param name="startIndex">Id do primeiro <see cref="PokemonAPI"/> que se deseja na adicionar na lista.</param>
        /// <param name="qtdPokemons">Quantidade de <see cref="PokemonAPI"/> adiciondos a lista.</param>
        /// <returns>Um object <see cref="PokemonPropertiesList"/> construido pela API.</returns>
        public static PokemonPropertiesList GetPropertiesListPokemons(int startIndex = 0, int quantity = 10)
        {
            string stringUrl = $"https://pokeapi.co/api/v2/pokemon?limit={quantity}&offset={startIndex}";
            return Get<PokemonPropertiesList>(stringUrl);
        }

        /// <summary>
        /// Responsável pela criação de um <see cref="List{Pokemon}"/> de <see cref="PokemonAPI"/> apartir de um Json da API.
        /// </summary>
        /// <param name="startIndex">Id do primeiro <see cref="PokemonAPI"/> que se deseja na adicionar na lista.</param>
        /// <param name="quantity">Quantidade de <see cref="PokemonAPI"/> adiciondos a lista.</param>
        /// <returns>Uma <see cref="List{Pokemon}"/> de pokemons construidas pela API.</returns>
        public static IList<PokemonAPI> GetPokemonsList(int startIndex = 0, int quantity = 10)
        {
            PokemonPropertiesList propertiesList = GetPropertiesListPokemons(startIndex, quantity);

            IList<PokemonAPI> pokemons = new List<PokemonAPI>();

            foreach (PokemonAddressAPI address in propertiesList.Results)
            {
                string stringUrl = address.Url.ToString();

                pokemons.Add(Get<PokemonAPI>(stringUrl));
            }
                
            return pokemons;
        }
        
        public static IList<PokemonAPI> GetPokemonsListByType(int typeNumber, int startIndex = 0, int quantity = 10)
        {
            string url = $"https://pokeapi.co/api/v2/type/{typeNumber}";

            var propertiesList = Get<TypePageAPI>(url);

            Console.WriteLine(propertiesList);

            IList<PokemonAPI> pokemons = new List<PokemonAPI>();

            foreach (var pokemon in propertiesList.Pokemons)
            {
                var propertiesUrl = pokemon.PokemonAddress.Url.ToString();

                pokemons.Add(Get<PokemonAPI>(propertiesUrl));
            }

            return pokemons;
        }
    }
}
