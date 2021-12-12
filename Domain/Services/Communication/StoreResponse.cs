using BookStoreSelling.API.Domain.Models;

namespace BookStoreSelling.API.Domain.Services.Communication
{
    public class StoreResponse : BaseResponse<Store>
    {
        public StoreResponse(Store store) : base(store) { }

        public StoreResponse(string message) : base(message) { }
    }
}