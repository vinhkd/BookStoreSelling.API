namespace BookStoreSelling.API.Resources
{
    public class BooksQueryResource : QueryResource
    {
        public int? StoreId { get; set; }
        public string? Keyword { get; set; }
    }
}