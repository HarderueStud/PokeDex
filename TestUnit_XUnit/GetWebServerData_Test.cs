using System;
using Xunit;
using System.Collections.Generic;

using DataModel;
using GetWebServerData;

namespace TestUnit_XUnit
{
    public class GetWebServerData_Test
    {
        [Fact]
        public void GetPokemon_Test()
        {
            // On essaye la fonction de récupération sur un Pokémon
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            Assert.Equal(25, pikachu.Id); // Pikachu ID = 25, ici on retrouve bien 25
            Assert.Equal("pikachu", pikachu.Name); // Test sur le nom, on récupère bien les données

            //Assert.Equal(20, pikachu.Id); // Pikachu ID != 20 -> FAUX
            //Assert.Equal("pikachou", pikachu.Name); // pikachu != pikachou -> FAUX

            // ID 1 = Pokémon appelé Bulbasaur
            Assert.Equal("bulbasaur", GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/1").Name);
            //Assert.Equal("bulbasaure", GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/1").Name); // -> Faux
        }

        [Fact]
        public void ConcatUrl_Test()
        {
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            string url = String.Concat("https://pokeapi.co/api/v2/", "pokemon-species/", pikachu.Id.ToString());

            // Test sur l'url de PokemonSpecies
            Assert.Equal("https://pokeapi.co/api/v2/pokemon-species/25", url);
            //Assert.Equal("https://pokeapi.co/api/v2/pokemon-species/30", url); // -> Faux
        }

        [Fact]
        public void GetPokemonSpecies_Test()
        {
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            string url = String.Concat("https://pokeapi.co/api/v2/", "pokemon-species/", pikachu.Id.ToString());

            // On récupère PokemonSpecies
            PokemonSpecies pikachuSpecies = GetData.GetAnything<PokemonSpecies>(url);

            Assert.Equal(190, pikachuSpecies.CaptureRate); // Test captureRate
            Assert.Equal(70, pikachuSpecies.BaseHappiness); // Test baseHappiness

            //Assert.Equal(9999, pikachuSpecies.CaptureRate); // -> Faux
            //Assert.Equal(-1, pikachuSpecies.BaseHappiness); // -> Faux

            url = pikachuSpecies.EvolutionChain.Url;

            // Test de l'url, sur la chaine d'evolution récupéré
            Assert.Equal("https://pokeapi.co/api/v2/evolution-chain/10/", url);
            //Assert.Equal("https://pokeapi.co/api/v2/evolution-chain/1000/", url); // -> Faux
        }

        [Fact]
        public void GetEvolutionChain_Test()
        {
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            string url = String.Concat("https://pokeapi.co/api/v2/", "pokemon-species/", pikachu.Id.ToString());

            // On récupère PokemonSpecies
            PokemonSpecies pikachuSpecies = GetData.GetAnything<PokemonSpecies>(url);

            Assert.Equal(12, GetData.GetAnything<EvolutionChain>("https://pokeapi.co/api/v2/evolution-chain/12/").Id);
            //Assert.Equal(800, GetData.GetAnything<EvolutionChain>("https://pokeapi.co/api/v2/evolution-chain/12/").Id); // -> Faux

            url = pikachuSpecies.EvolutionChain.Url;

            // Test sur la chaine d'evolution de Pikachu
            EvolutionChain deseriEv = GetData.GetAnything<EvolutionChain>(url);
            Assert.Equal(10, deseriEv.Id);
            //Assert.Equal(214, deseriEv.Id); // -> Faux
        }
    }
}
