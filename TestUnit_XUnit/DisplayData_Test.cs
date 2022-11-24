using Xunit;
using DisplayData;

using DataModel;
using GetWebServerData;

namespace TestUnit_XUnit
{
    public class DisplayData_Test
    {
        [Fact]
        public void FindOneElement_Test()
        {
            string url = "https://pokeapi.co/api/v2/pokemon/pikachu";

            DisplayConsole disp = new DisplayConsole();

            Pokemon pikachu = GetData.GetAnything<Pokemon>(url);

            Pokemon random = disp.FindOneElement<Pokemon>(url);
            Assert.Equal(pikachu, random); // VRAI

            //Assert.AreEqual(pikachu, disp.FindOneElement<Pokemon>("https://pokeapi.co/api/v2/pokemon/1")); // FAUX
        }

        [Fact]
        public void RefactorSearch_test()
        {
            string input = "   ABCdefGH   ";

            DisplayConsole disp = new DisplayConsole();


            Assert.Equal("abcdefgh", disp.RefactorResearchInput(input)); // VRAI On eneleve espaces + majuscule
            // Assert.AreEqual("   abcdefgh   ", disp.RefactorResearchInput(input)); // FAUX
            // Assert.AreEqual("ABCdefGH", disp.RefactorResearchInput(input)); // FAUX
        }
    }
}