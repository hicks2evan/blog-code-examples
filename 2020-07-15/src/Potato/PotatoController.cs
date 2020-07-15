using System;
using Newtonsoft.Json;
using _2020_07_15.src.PotatoProviders;

namespace _2020_07_15.src.Potato
{
    public class PotatoController
    {
        IPotatoDbProvider dbProvider;
        IPotatoFilestoreProvider filestoreProvider;

        public PotatoController(IPotatoDbProvider potatoDbProvider, IPotatoFilestoreProvider potatoFilestoreProvider) {
            dbProvider = potatoDbProvider;
            filestoreProvider = potatoFilestoreProvider;
        }

        public int CreateNewPotato(string potatoName) {
            int id;
            
            try {
                id = dbProvider.CreatePotato(new Potato {
                    name = potatoName
                });
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return -1;
            }

            Console.WriteLine("Potato created: " + id);
            return id;
        }

        public IPotato GetPotato(int potatoId) {            
            IPotato potato;
            try {
                potato = dbProvider.GetPotato(potatoId);
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception("Something bad happened when trying to read from the db.");
            }
            return potato;
        }

        public int WriteProfile(string potatoName, string[] potatoInterests, string potatoBio) {
            var profile = new PotatoProfile {
                name = potatoName,
                interests = potatoInterests,
                bio = potatoBio
            };
            
            int id;

            try {
                id = filestoreProvider.WritePotatoFile(JsonConvert.SerializeObject(profile));
            }
            catch(Exception e) {                
                Console.WriteLine(e.Message);
                throw new Exception("Something bad happened when trying to write the file.");
            }

            Console.WriteLine("Potato profile inserted: " + id);
            return id;
        }
    }
}