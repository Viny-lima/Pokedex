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
        public string url { get; set; }

        private int actual = 0;

        public ApiRequest()
        {
            url = "https://pokeapi.co/api/v2/pokemon?limit=10&offset=";//Lista de Pokemons da PokéAPI
        }

        public ListaPokemon GetListaPokemons()
        {
            var consulta = (HttpWebRequest)WebRequest.Create(url + actual);
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

                        ListaPokemon listaDePokemons = JsonConvert.DeserializeObject<ListaPokemon>(repostaString);
                        actual += 10;

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
