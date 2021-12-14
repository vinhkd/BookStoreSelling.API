namespace BookStoreSelling.API.Resources
{
    public class StoreWithPriceResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumberLeftStock { get; set; }
        public string UnitOfPrice { get; set; }
    }
}