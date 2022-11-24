/*
 * Problémes compatibilite .Net netcore .. Voir Xunit test pour les tests fonctionnels
 */

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GetWebServerData;
using DataModel;
using DisplayData;



namespace TestUnitaires
{
    [TestClass]
    class DisplayData_Test
    {
        [TestMethod]
        public void FindOneElement_Test()
        {
            string url = "https://pokeapi.co/api/v2/pokemon/pikachu";

            DisplayConsole disp = new DisplayConsole();

            Pokemon pikachu = GetData.GetAnything<Pokemon>(url);
            Assert.AreEqual(pikachu, disp.FindOneElement<Pokemon>(url)); // VRAI
            Assert.AreEqual(pikachu, disp.FindOneElement<Pokemon>("https://pokeapi.co/api/v2/pokemon/25")); // VRAI
            // Assert.AreEqual(pikachu, disp.FindOneElement<Pokemon>("https://pokeapi.co/api/v2/pokemon/1")); // FAUX
        }

        [TestMethod]
        public void RefactorSearch_test()
        {
            string input = "   ABCdefGH   ";

            DisplayConsole disp = new DisplayConsole();


            Assert.AreEqual("abcdefgh", disp.RefactorResearchInput(input)); // VRAI On eneleve espaces + majuscule
            // Assert.AreEqual("   abcdefgh   ", disp.RefactorResearchInput(input)); FAUX
            // Assert.AreEqual("ABCdefGH", disp.RefactorResearchInput(input)); FAUX
        }
    }
}

