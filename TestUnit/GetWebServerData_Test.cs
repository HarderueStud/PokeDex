/*
 * Problémes compatibilite .Net netcore .. Voir Xunit test pour les tests fonctionnels
 */

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DataModel;
using GetWebServerData;

namespace TestUnitaires
{
    [TestClass]
    public class GetWebServerData_Test
    {
        /// <summary>
        /// Test les requêtes pour vérifier que l'on reçoit bien ce que l'on veut
        /// </summary>
        [TestMethod]
        public void GetPokemon_Test()
        {
            // On essaye la fonction de récupération sur un Pokémon
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            Assert.AreEqual(25, pikachu.Id); // Pikachu ID = 25, ici on retrouve bien 25
            Assert.AreEqual("pikachu", pikachu.Name); // Test sur le nom, on récupère bien les données

            // ID 1 = Pokémon appelé Bulbasaur
            Assert.AreEqual("bulbasaur", GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/1").Name);
        }

        [TestMethod]
        public void ConcatUrl_Test()
        {
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            string url = String.Concat("https://pokeapi.co/api/v2/", "pokemon-species/", pikachu.Id.ToString());
            // Test sur l'url de PokemonSpecies
            Assert.AreEqual(url, "https://pokeapi.co/api/v2/pokemon-species/25");
        }

        [TestMethod]
        public void GetPokemonSpecies_Test()
        {
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            string url = String.Concat("https://pokeapi.co/api/v2/", "pokemon-species/", pikachu.Id.ToString());

            // On récupère PokemonSpecies
            PokemonSpecies pikachuSpecies = GetData.GetAnything<PokemonSpecies>(url);

            Assert.AreEqual(190, pikachuSpecies.CaptureRate); // Test captureRate
            Assert.AreEqual(70, pikachuSpecies.BaseHappiness); // Test baseHappiness

            url = pikachuSpecies.EvolutionChain.Url;

            // Test de l'url, sur la chaine d'evolution récupéré
            Assert.AreEqual("https://pokeapi.co/api/v2/evolution-chain/10/", url);
        }

        [TestMethod]
        public void GetEvolutionChain_Test()
        {
            Pokemon pikachu = GetData.GetAnything<Pokemon>("https://pokeapi.co/api/v2/pokemon/pikachu");
            string url = String.Concat("https://pokeapi.co/api/v2/", "pokemon-species/", pikachu.Id.ToString());

            // On récupère PokemonSpecies
            PokemonSpecies pikachuSpecies = GetData.GetAnything<PokemonSpecies>(url);

            Assert.AreEqual(12, GetData.GetAnything<EvolutionChain>("https://pokeapi.co/api/v2/evolution-chain/12/").Id);
            url = pikachuSpecies.EvolutionChain.Url;

            // Test sur la chaine d'evolution de Pikachu
            EvolutionChain deseriEv = GetData.GetAnything<EvolutionChain>(url);
            Assert.AreEqual(10, deseriEv.Id);
        }
    }
}
