using Microsoft.AspNetCore.Mvc;

namespace BookStoreSelling.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }
}