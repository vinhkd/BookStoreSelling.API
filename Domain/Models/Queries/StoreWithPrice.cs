namespace BookStoreSelling.API.Domain.Models.Queries
{
    public class StoreWithPrice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumberLeftStock { get; set; }
        public EUnitOfPrice UnitOfPrice { get; set; }
        
    }
}