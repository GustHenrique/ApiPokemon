using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokemonController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        [HttpGet(Name = "GetPokemons")]
        public IEnumerable<Pokemon> Get()
        {
            IList<Pokemon> list = new List<Pokemon>();
            string FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Pokemons.json";
            string PokemonsData = System.IO.File.ReadAllText(FilePath);

            if (!string.IsNullOrEmpty(PokemonsData))
            {
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Pokemon>>(PokemonsData);
                return list;
            }
            else
            {
                list = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Pokemon>>(PokemonsData);
                return list;
            }

            return list;

        }

        [HttpPost(Name = "GravarPokemon")]
        public void SavePokemon([FromBody] Pokemon pokemon)
        {
            if (pokemon != null)
            {
                string FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Pokemons.json";
                string PokemonData = System.IO.File.ReadAllText(FilePath);

                if (!string.IsNullOrEmpty(PokemonData))
                {
                    IList<Pokemon> lista = new List<Pokemon>();
                    lista = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Pokemon>>(PokemonData);

                    bool Atualizacao = false;

                    for (int i = 0; i < lista.Count; i++)
                    {
                        Pokemon item = lista[i];

                        if (item.Number == pokemon.Number)
                        {
                            lista[i] = pokemon;
                            Atualizacao = true;
                            break;
                        }
                    }
                    if (Atualizacao == false)
                    {
                        lista.Add(pokemon);
                    }

                    string Dados = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
                    System.IO.File.WriteAllText(FilePath, Dados);

                }
                else
                {
                    IList<Pokemon> lista = new List<Pokemon>();
                    lista.Add(pokemon);
                    string Dados = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
                    System.IO.File.WriteAllText(FilePath, Dados);
                }


            }
        }

        [HttpDelete(Name = "DeletarPokemon")]
        public void DeletePokemon([FromBody] Pokemon pokemon)
        {
            if (pokemon != null)
            {
                string FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "/Data/Pokemons.json";
                string PokemonData = System.IO.File.ReadAllText(FilePath);

                if (!string.IsNullOrEmpty(PokemonData))
                {
                    IList<Pokemon> lista = new List<Pokemon>();
                    lista = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Pokemon>>(PokemonData);

                    for (int i = 0; i < lista.Count; i++)
                    {
                        Pokemon item = lista[i];

                        if (item.Number == pokemon.Number)
                        {
                            lista[i] = pokemon;
                            lista.Remove(lista[i]);
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    string Dados = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
                    System.IO.File.WriteAllText(FilePath, Dados);

                }

            }
        }
}

    public class Pokemon
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Evolution { get; set; }
        public string? Weaknesses { get; set; }
        public int Number { get; set; }
    }

}