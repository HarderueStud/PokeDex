using System;
using System.Drawing;
using Console = Colorful.Console;

using GetWebServerData;
using DataModel;

namespace DisplayData
{
    public class DisplayConsole
    {
        // Les couleurs pour la console
        private Color color1 = Color.FromArgb(255, 255, 100, 100);
        private Color color2 = Color.FromArgb(255, 255, 150, 150);
        private Color color3 = Color.FromArgb(255, 255, 50, 50);
        private Color color4 = Color.FromArgb(255, 150, 150, 255);
        private Color color5 = Color.FromArgb(255, 100, 100, 255);
        private Color color6 = Color.FromArgb(255, 70, 70, 255);

        // L'URL où chercher les données, à changer si l'on veut prendre d'autres données
        public const string BaseUrl = "https://pokeapi.co/api/v2/";

        // Tant que l'entrée utilisateur est incorrecte -> on lui demande de réessayer
        public void CheckAnswer(ref short ans, short minAns, short maxAns)
        {
            while (!short.TryParse(Console.ReadLine(), out ans) || ans < minAns || ans > maxAns)
            {
                Console.WriteLine("Erreur... Réessayer...", color3);
                Console.Write("\n  > ", color1);
            }
        }

        // Affiche la description d'une donné
        // On doit changer T en fonction du type de donnée que nous voulons traiter. T doit avoir methodes et variables appelé dans la fonction.
        public void DisplayOneElementDescription<T>(T data) where T : Pokemon 
        {
            try
            {
                // On fait les requêtes avant pour éviter d'afficher la moitié des infos,
                // et l'autre moitié après un certain temps.

                string url = String.Concat(BaseUrl, "pokemon-species/", data.Id.ToString());
                PokemonSpecies pokemonSpecies = GetData.GetAnything<PokemonSpecies>(url);

                url = pokemonSpecies.EvolutionChain.Url;
                EvolutionChain deseriEv = GetData.GetAnything<EvolutionChain>(url);

                // P o k e m o n
                Console.Write("\n\n");
                Console.WriteLine("  Nom du Pokémon : " + data.Name, color5);
                Console.WriteLine("  ID du Pokémon : " + data.Id, color5);

                Console.Write("\n  Type(s) du Pokémon : ", color5);
                foreach (var t in data.Types)
                    Console.Write($" - {t.Type.Name}", color5);
                Console.Write(" - \n", color5);

                Console.WriteLine($"\n  Mensuration du Pokémon : Height : {data.Height} Weight : {data.Weight}", color5);

                Console.Write("\n  Chaine d'evolution : ", color5);
                Console.Write(deseriEv.Chain.Species.Name, color5);
                foreach (var t in deseriEv.Chain.EvolvesTo)
                {
                    Console.Write(" - " + t.Species.Name, color5);
                    foreach (var y in t.EvolvesTo)
                    {
                        Console.Write(" - " + y.Species.Name, color5);
                    }
                }

                Console.WriteLine("\n\n  Description du Pokémon : ", color4);
                // Plusieurs descriptions disponibles selon les Pokémons et version du jeu
                foreach (var t in pokemonSpecies.FlavorTextEntries)
                {
                    if (t.Language.Name == "fr")
                    {
                        Console.WriteLine($"\n  - Version de jeu de la description : {t.Version.Name}.", color4);
                        Console.WriteLine("  > {0}", t.FlavorText, color4);

                        // On affiche qu'une description, la premier que l'on trouve.
                        Console.WriteLine("\n  Voir une autre description si cela est possible ? (y/n)", color5);
                        Console.Write("\n > ", color2);

                        string rep3 = Console.ReadLine();
                        while (rep3 != "y" && rep3 != "n")
                        {
                            Console.WriteLine("Erreur... Réessayer...", color3);
                            Console.Write("\n > ", color2);
                            rep3 = Console.ReadLine();
                        }

                        if (rep3 == "n")
                            break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Il y a eu un problème : {0}", e.Message, color1);
            }
        }

        // Retourne l'element recherché
        public T FindOneElement<T>(string url) where T : NamedApiResource
        {
            // On va gerer les Exception au cas par cas, pas dans cette fonction
            // Requête élément (ici Pokémon)
            T data = GetData.GetAnything<T>(url);
            // Réponse de ce que l'on fait après avoir trouvé le Pokémon

            // Plusieurs choix si pokemon trouver
            Console.WriteLine($"\nLe Pokemon {data.Name} (ID : {data.Id}) a été trouvé ! ", color1);
            return data;
        }

        // On modifie l'entré utilisateur si besoin
        public string RefactorResearchInput(string rawInput)
        {
            string dataSearch = rawInput.Trim(); // On supprime les espaces
            dataSearch = dataSearch.ToLower(); // On met en minuscule si majuscules présentes
            return dataSearch;
        }

        // Fonction principale de la console
        public void DisplayConsoleApp()
        {
            Console.WriteLine("\n\t\t\tBienvenue dans l'application PokeDex !", color1);

            short mainMenuAns = -1;
            while (mainMenuAns != 0)
            {
                // Menu principal
                Console.WriteLine("\n\tRechercher un Pokémon (1)   Afficher la liste des Pokémons (2)   Informations (3)   Quitter (0)", color2);
                Console.Write("\n > ", color1);

                // On recupere se que l'on doit faire
                CheckAnswer(ref mainMenuAns, 0, 3);

                // Traitement du resultat
                if (mainMenuAns == 1) // On recherche un pokemon
                {
                    bool dataFounded = false;
                    string dataSearch = "";
                    Console.WriteLine("\nRecherche de Pokémon : Vous pouvez rechercher un Pokémon par son nom ou par son National ID.  Quitter (0)", color2);

                    while (dataSearch != "0" && !dataFounded)
                    {
                        Console.Write("\n\t> ", color2);
                        dataSearch = Console.ReadLine();
                        dataSearch = RefactorResearchInput(dataSearch);

                        if (dataSearch == "0") // On quitte (on refait un tour de boucle mais comme "0" -> on quitte)
                            continue;

                        if (dataSearch.Length == 0) // On vérifie que l'entrer de l'utilisateur n'est pas vide
                        {
                            Console.WriteLine("\tRecherche invalide...", color4);
                            continue;
                        }

                        // On fait la nouvelle URL de recherche
                        string url = String.Concat(BaseUrl, "pokemon/", dataSearch);
                        Console.WriteLine($"URL > {url}", color4);

                        try
                        {
                            short menuNavigation = 0;

                            Pokemon pokemon = FindOneElement<Pokemon>(url);

                            // Menu pour savoir ce que l'on fait
                            Console.WriteLine("\nAfficher les détails de ce Pokémon (1)    Rechercher un autre Pokémon (2)    Quitter (0)", color2);
                            Console.Write("\n\t\t> ", color1);

                            // On récupère ce que l'on doit faire
                            CheckAnswer(ref menuNavigation, 0, 2);

                            if (menuNavigation == 1)
                            {
                                DisplayOneElementDescription<Pokemon>(pokemon);
                                dataFounded = true; // On ne veut pas chercher un autre Pokémon -> on a trouvé celui que l'on voulait
                            }
                            else if (menuNavigation == 2) // dataFounded est tjr faux, on recommence
                                Console.WriteLine("\nRecherche d'un autre Pokémon : Vous pouvez rechercher un Pokemon par son nom ou par son National ID.  Quitter (0)", color2);
                            else // On quitte
                                dataSearch = "0";
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Il y a eu un problème : {0}", e.Message, color1);
                            Console.WriteLine("Pokémon introuvable ? Réessayer...", color1);
                        }
                    }
                }
                else if (mainMenuAns == 2) // On affiche la liste des données (ici des pokémon)
                {
                    short startingIndex = 1; // L'index de la liste oû l'on comence
                    short nbrDataADisplay = 20; // Le nombre de données a affiché depuis l'index

                    short repNavigList = 4; // La réponse d navigation dans la liste

                    while (repNavigList != 0)
                    {
                        string urlTemp = String.Format($"pokemon?limit={nbrDataADisplay}&offset={startingIndex-1}");
                        string url = String.Concat(BaseUrl, urlTemp);
                        PokemonList pokemonList;

                        try
                        {
                            pokemonList = GetData.GetAnything<PokemonList>(url);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Il y a eu un probléme : {0}", e.Message, color1);
                            Console.WriteLine("Retour au debut de la liste...", color1);

                            startingIndex = 0;
                            urlTemp = String.Format($"pokemon?limit={nbrDataADisplay}&offset={startingIndex}");
                            url = String.Concat(BaseUrl, urlTemp);
                            pokemonList = GetData.GetAnything<PokemonList>(url);
                        }


                        if(nbrDataADisplay > 1) // Si on affiche + d'1 element a la foi
                            Console.WriteLine($"\n   Pokémon de {startingIndex} à {startingIndex + nbrDataADisplay - 1} : \n", color6);
                        else
                            Console.WriteLine($"\n   Pokémon n°{startingIndex} : \n", color6);

                        foreach (var t in pokemonList.Pokemons) // Boucle a travers la liste de pokemons
                            Console.WriteLine($"    - {t.Name}", color5);

                        Console.WriteLine($"\n\t{nbrDataADisplay} Précédent (1)    {nbrDataADisplay} Suivant (2)    Nbr à afficher (3)    Aller à (4)    Quitter (0)", color2);
                        Console.Write("\n\t\t> ", color1);

                        //
                        CheckAnswer(ref repNavigList, 0, 4);

                        // Traitement de la navigation dans la liste
                        if (repNavigList == 1 && startingIndex >= nbrDataADisplay)
                            startingIndex -= nbrDataADisplay; // On affiche n données precedentes
                        else if (repNavigList == 2)
                            startingIndex += nbrDataADisplay; // On affiche n données suivantes
                        else if (repNavigList == 3) // Changement nbr de données affichées a chaque foi
                        {
                            short nbrADisplayUpdate = nbrDataADisplay;
                            Console.WriteLine("\nNombre de Pokémons qui s'affiche sur chaque page : {0}", nbrDataADisplay, color3);
                            Console.Write("\nNouveau nombre (entre 1 et 100) > ", color5);

                            CheckAnswer(ref nbrADisplayUpdate, 0, 100);

                            nbrDataADisplay = nbrADisplayUpdate;
                            startingIndex = 1;
                        }
                        else if (repNavigList == 4)
                        {
                            if(nbrDataADisplay > 1)
                                Console.Write("\n\nSe déplacer dans la liste à l'index n° : ", color3);
                            else
                                Console.Write("\n\nSe déplacer dans la liste à l'index (ici index = ID, ex : 25 -> Pikachu) n° : ", color3);
                            CheckAnswer(ref startingIndex, 0, short.MaxValue);
                        }
                        else // On recommence à 0
                            startingIndex = 1;
                    }
                }
                else if (mainMenuAns == 3)
                    Infos();
            }

            EndOfProgram();
        }

        public void EndOfProgram()
        {
            Console.WriteLine("\n\n Bye Bye !", color2);
            Console.WriteLine("     See u soon..", color4);
        }

        public void Infos()
        {
            Console.WriteLine("\n\n");

            Console.WriteLine("     ░█████╗░██╗░░░░░███████╗███╗░░░███╗███████╗███╗░░██╗████████╗░", color1);
            Console.WriteLine("     ██╔══██╗██║░░░░░██╔════╝████╗░████║██╔════╝████╗░██║╚══██╔══╝", color2);
            Console.WriteLine("     ██║░░╚═╝██║░░░░░█████╗░░██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░", color1);
            Console.WriteLine("     ██║░░██╗██║░░░░░██╔══╝░░██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░", color2);
            Console.WriteLine("     ╚█████╔╝███████╗███████╗██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░", color1);
            Console.WriteLine("     ░╚════╝░╚══════╝╚══════╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░", color2);

            Console.WriteLine();

            Console.WriteLine("              ██╗░░░░░", color1);
            Console.WriteLine("              ██║░░░░░", color2);
            Console.WriteLine("              ██║░░░░░", color1);
            Console.WriteLine("              ██║░░░░░", color2);
            Console.WriteLine("              ███████╗", color1);
            Console.WriteLine("              ╚══════╝", color2);

            Console.WriteLine("\n\n");
        }
    }
}
