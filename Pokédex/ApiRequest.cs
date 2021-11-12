using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public class ApiRequest
    {
        public PropertiesListPokemon GetListaPokemons(int startIndex = 0, int qtdPokemons = 10)
        {            
            var consulta = (HttpWebRequest)WebRequest.Create($"https://pokeapi.co/api/v2/pokemon?limit={qtdPokemons}&offset={startIndex}");
            consulta.Method = "GET";
            consulta.ContentType = "application/json";
            consulta.Accept = "application/json";

            try
            {
                using (WebResponse reposta = consulta.GetResponse())
                using (Stream dadosAPI = reposta.GetResponseStream())
                {
                    if (dadosAPI == null)
                    {
                        return null;
                    }
                    using (StreamReader leitorDadosAPI = new StreamReader(dadosAPI))
                    {
                        string repostaString = leitorDadosAPI.ReadToEnd();

                        PropertiesListPokemon listaDePokemons = JsonConvert.DeserializeObject<PropertiesListPokemon>(repostaString);                        

                        return listaDePokemons;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
