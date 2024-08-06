using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;
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
    public class QuestionsController : ControllerBase
    {

        private readonly IServiceManager _manager;

        public QuestionsController(IServiceManager manager)
        {
            _manager = manager;
        }
    }
}
