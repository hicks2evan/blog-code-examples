using _2020_07_15.src.Potato;

namespace _2020_07_15.src.PotatoProviders
{
    public interface IPotatoDbProvider
    {
         public IPotato GetPotato(int potatoId);
         public int CreatePotato(IPotato potato);
         public bool UpdatePotato(int potatoId, IPotato potato);
         public bool DeletePotato(int potatoId);
    }
}