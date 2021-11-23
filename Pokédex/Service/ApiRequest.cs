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
        /// Responsável construção de um <see cref="Object"/> da class <see cref="Pokemon"/> apartir de um Json da API. Gerado por uma Url + <paramref name="Id"/>.
        /// </summary>
        /// <param name="Id">Index do Pokemon na API></param>
        /// <returns>Um object <see cref="Pokemon"/> construido pela API.</returns>
        public static Pokemon GetPokemon(int Id)
        {
            var stringUrl = $"https://pokeapi.co/api/v2/pokemon/{Id}";

            return Get<Pokemon>(stringUrl);
        }

        /// <summary>
        /// Responsável construção de um <see cref="Object"/> da class <see cref="PropertiesListPokemon"/> apartir de um Json da API.
        /// </summary>
        /// <param name="startIndex">Id do primeiro <see cref="Pokemon"/> que se deseja na adicionar na lista.</param>
        /// <param name="qtdPokemons">Quantidade de <see cref="Pokemon"/> adiciondos a lista.</param>
        /// <returns>Um object <see cref="PropertiesListPokemon"/> construido pela API.</returns>
        public static PropertiesListPokemon GetPropertiesListPokemons(int startIndex = 0, int qtdPokemons = 10)
        {
            string stringUrl = $"https://pokeapi.co/api/v2/pokemon?limit={qtdPokemons}&offset={startIndex}";
            return Get<PropertiesListPokemon>(stringUrl);
        }

        /// <summary>
        /// Responsável pela criação de um <see cref="List{Pokemon}"/> de <see cref="Pokemon"/> apartir de um Json da API.
        /// </summary>
        /// <param name="startIndex">Id do primeiro <see cref="Pokemon"/> que se deseja na adicionar na lista.</param>
        /// <param name="qtdPokemons">Quantidade de <see cref="Pokemon"/> adiciondos a lista.</param>
        /// <returns>Uma <see cref="List{Pokemon}"/> de pokemons construidas pela API.</returns>
        public static List<Pokemon> GetListaDePokemons(int startIndex = 0, int qtdPokemons = 10)
        {
            PropertiesListPokemon propertiesList = GetPropertiesListPokemons(startIndex, qtdPokemons);

            List<Pokemon> ListaDePokemons = new List<Pokemon>();

            foreach (AddressPokemon address in propertiesList.Results)
            {
                string stringUrl = address.Url.ToString();

                ListaDePokemons.Add(Get<Pokemon>(stringUrl));
            }
                
            return ListaDePokemons;
        }                  
    }
}
