namespace BookStoreSelling.API.Domain.Models.Queries
{
    public class BooksQuery : Query
    {
        public int? StoreId { get; set; }
        public string? Keyword { get; set; }

        public BooksQuery(int? storeId, string? keyword, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            StoreId = storeId;
            Keyword = keyword;
        }
    }
}