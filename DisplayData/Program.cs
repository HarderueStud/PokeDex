using DisplayData;

namespace MainSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://pokeapi.co/docs/v2
            // https://restsharp.dev/usage/
            // https://gitlab.com/PoroCYon/PokeApi.NET --->  Offi Wrapper .NET
            // https://github.com/mtrdp642/PokeApiNet --->  Offi Wrapper .NET
            // https://github.com/nlabiris/pokeapi/tree/master/PokeAPI
            // https://docs.microsoft.com/fr-fr/dotnet/api/system.runtime.caching.objectcache?view=dotnet-plat-ext-3.1
            // https://www.c-sharpcorner.com/UploadFile/87b416/working-with-caching-in-C-Sharp/
            // https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
            // ...

            // Création de la Class qui affichera la console et les données
            DisplayConsole dc = new DisplayConsole();
            dc.DisplayConsoleApp();
        }
    }
}