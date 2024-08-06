using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        // 
        // list of likes (get)
        // question like or dislike (set)
        // question relike or redislike (delete)
        private readonly IServiceManager _manager;

        public LikesController(IServiceManager manager)
        {
            _manager = manager;
        }
    }
}
