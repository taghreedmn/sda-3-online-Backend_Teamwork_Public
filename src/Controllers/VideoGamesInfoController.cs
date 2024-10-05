using System.Security.Claims;
using FusionTech.src.Services.VideoGamesInfo;
using FusionTech.src.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FusionTech.src.DTO.VideoGameInfoDTO;

namespace FusionTech.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VideoGamesInfoController : ControllerBase
    {
        private readonly IVideoGameInfoService _videoGameInfoService;

        public VideoGamesInfoController(IVideoGameInfoService videoGameInfoService)
        {
            _videoGameInfoService = videoGameInfoService;
        }

        // Get all video games
        [HttpGet]
        public async Task<ActionResult> GetVideoGames([FromQuery] SearchParameters searchParameters)
        {
            var videoGames = await _videoGameInfoService.GetAllAsync(searchParameters);
            return Ok(videoGames);
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVideoGameById(Guid id)
        {
            var videoGame = await _videoGameInfoService.GetVideoGameVersionByIdAsync(id);
            return Ok(videoGame);
        }

        [Authorize(Policy = "admin")]
        // Add a new video game
        [HttpPost]
        public async Task<ActionResult> CreateVideoGame(VideoGameInfoCreateDto newVideoGameDto)
        {
            string? userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
            {
                throw CustomException.Forbidden("Admin not authorized");
            }

            var createdVideoGame = await _videoGameInfoService.CreateOneAsync(
                newVideoGameDto,
                userEmail
            );

            return CreatedAtAction(
                nameof(GetVideoGameById),
                new { id = createdVideoGame.VideoGameInfoId },
                createdVideoGame
            );
        }

        [Authorize(Policy = "admin")]
        // Delete video game
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVideoGame(Guid id)
        {
            await _videoGameInfoService.DeleteAsync(id);
            return NoContent();
        }

        [Authorize(Policy = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGameName(Guid id, string newGameName)
        {
            await _videoGameInfoService.UpdateGameNameAsync(id, newGameName);
            return NoContent();
        }

        [Authorize(Policy = "admin")]
        [HttpPut("{id}/year")]
        public async Task<ActionResult> UpdateYearOfRelease(Guid id, string newYearOfRelease) //Check string formatting using regex
        {
            var isUpdated = await _videoGameInfoService.UpdateYearOfReleaseAsync(
                id,
                newYearOfRelease
            );
            return NoContent();
        }
    }
}
