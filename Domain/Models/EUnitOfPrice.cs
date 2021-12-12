using System.ComponentModel;

namespace BookStoreSelling.API.Domain.Models
{
    public enum EUnitOfPrice : byte
    {
        [Description("USD")]
        USD = 1,
        
        [Description("SGD")]
        SGD = 2,
    }
}