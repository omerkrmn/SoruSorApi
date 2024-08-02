using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoruSorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        //  list of likes (get)
        //  question like or dislike (set)
        //  question relike or redislike (delete)
    }
}
