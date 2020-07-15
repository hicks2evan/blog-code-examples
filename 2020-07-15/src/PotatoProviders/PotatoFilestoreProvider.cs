using _2020_07_15.src.Potato;

namespace _2020_07_15.src.PotatoProviders
{
    public class PotatoFileStoreProvider : IPotatoFilestoreProvider
    {
        public string ReadPotatoFile(int fileId)
        {
            //Would typically read a file from the file store
            throw new System.NotImplementedException();
        }

        public int WritePotatoFile(string json)
        {
            //Would typically write a file to the file store
            throw new System.NotImplementedException();
        }
    }
}