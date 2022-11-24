using RestSharp;
using Newtonsoft.Json;
using System.Runtime.Caching;

namespace GetWebServerData
{
    public class GetData
    {
        // Cache
        private static ObjectCache cache = MemoryCache.Default;
        private static CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();

        // Methode qui retourne n'importe quel data a partir de l'url d'une resource donnée.
        // Peut etre utiliser pour autre chose que des pokemons.
        public static T GetAnything<T>(string url)
        {
            // Si on a deja effectuer cette recherche (par url), on reprend le cache de la mémoire
            if (cache.Contains(url))
                return (T) cache.Get(url);

            // On a pas dans le cache.. On fait une requete.

            RestClient client = new RestClient(url); // On fait un nouveau client Rest a partir de l'url de la resource
            RestRequest request = new RestRequest(Method.GET); // On fait une nouvelle requete de type GET
            IRestResponse response = client.Execute(request); // On execute la requete par notre client qui nous donne une reponse

            // Console.WriteLine($"HTTP response status code: {response.StatusCode.ToString()}"); // Le resultat de la requete http

            string content = response.Content; // On recupere la reponse sous forme de chaine
            T deserialized = JsonConvert.DeserializeObject<T>(content);

            //Console.WriteLine($"\n deserialized type : {deserialized.GetType()}"); // Le type de donné que nous retournons (pokemon...)

            // On ajoute l'objet dans le cache
            cache.Add(url, deserialized, cacheItemPolicy);
            return deserialized;
        }
    }
}
