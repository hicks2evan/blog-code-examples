using _2020_07_15.src.Potato;

namespace _2020_07_15.src.PotatoProviders
{
    public class PotatoDbProvider : IPotatoDbProvider
    {
        public int CreatePotato(IPotato potato)
        {
            //would typically contact a db and make a potato record
            throw new System.NotImplementedException();
        }

        public bool DeletePotato(int potatoId)
        {
            //would typically contact a db and delete a potato record
            throw new System.NotImplementedException();
        }

        public IPotato GetPotato(int potatoId)
        {
            //would typically contact a db and retrieve a potato record
            throw new System.NotImplementedException();
        }

        public bool UpdatePotato(int potatoId, IPotato potato)
        {
            //would typically contact a db and update a potato record
            throw new System.NotImplementedException();
        }
    }
}