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

        [HttpPost("AddLike")]
        public async Task<IActionResult> AddLike([FromBody] LikeDtoForInsert likeDtoForInsert)
        {
            if (likeDtoForInsert == null) return BadRequest("Like data is null.");
            var createdLike = await _manager.LikeService.CreateOneLikeAsync(likeDtoForInsert);
            var createdLikeDto = _mapper.Map<LikeDto>(createdLike);
            return StatusCode(201, createdLikeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLike(int id, [FromBody] LikeDto likeDto)
        {
            if (likeDto == null) return BadRequest("Like data is null.");
            await _manager.LikeService.UpdateOneLikeAsync(id, likeDto, true);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLike([FromQuery] int userId, [FromQuery] int questionId)
        {
            await _manager.LikeService.DeleteOneLikeAsync(userId, questionId, true);
            return NoContent();
        }
    }
}
