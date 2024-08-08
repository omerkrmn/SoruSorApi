using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public LikesController(IMapper mapper, IServiceManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        //[HttpGet]
        //public IActionResult GetAllLikes()
        //{
        //    var likes = _manager.LikeService.GetAllLikes(false);
        //    var likeDtos = _mapper.Map<IEnumerable<LikeDto>>(likes);
        //    return Ok(likeDtos);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetLikeById(int id)
        //{
        //    var like = _manager.LikeService.GetOneLikeById(id, false);
        //    var likeDto = _mapper.Map<LikeDto>(like);
        //    return Ok(likeDto);
        //}

        [HttpPost("AddLike")]
        public IActionResult AddLike([FromBody] LikeDtoForInsert likeDtoForInsert)
        {
            if (likeDtoForInsert == null) return BadRequest("Like data is null.");
            var createdLike = _manager.LikeService.CreateOneLike(likeDtoForInsert);
            var createdLikeDto = _mapper.Map<LikeDto>(createdLike);
            return StatusCode(201, createdLikeDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLike(int id, [FromBody] LikeDto likeDto)
        {
            if (likeDto == null) return BadRequest("Like data is null.");
            _manager.LikeService.UpdateOneLike(id, likeDto, true);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteLike([FromQuery] int userId, [FromQuery] int questionId)
        {
            _manager.LikeService.DeleteOneLike(userId,questionId, true);
            return NoContent();
        }
    }
}
