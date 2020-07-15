namespace _2020_07_15.src.PotatoProviders
{
    public interface IPotatoFilestoreProvider
    {
         public string ReadPotatoFile(int fileId);
         public int WritePotatoFile(string json);
    }
}