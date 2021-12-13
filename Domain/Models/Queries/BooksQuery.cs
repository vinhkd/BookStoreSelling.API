namespace BookStoreSelling.API.Domain.Models.Queries
{
    public class BooksQuery : Query
    {
        public int? StoreId { get; set; }

        public BooksQuery(int? storeId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            StoreId = storeId;
        }
    }
}