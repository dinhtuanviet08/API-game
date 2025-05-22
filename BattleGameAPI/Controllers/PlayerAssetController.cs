using Microsoft.AspNetCore.Mvc;
using BattleGameAPI.Data;
using BattleGameAPI.Models;
using BattleGameAPI.DTOs;


namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerAssetController : ControllerBase
    {
        private readonly BattleGameContext _context;

        public PlayerAssetController(BattleGameContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult AddPlayerAsset([FromBody] PlayerAssetDto dto)
        {
            var player = _context.Players.Find(dto.PlayerId);
            var asset = _context.Assets.Find(dto.AssetId);

            if (player == null || asset == null)
            {
                return BadRequest("Invalid PlayerId or AssetId");
            }

            var playerAsset = new PlayerAsset
            {
                PlayerId = dto.PlayerId,
                AssetId = dto.AssetId
            };

            _context.PlayerAssets.Add(playerAsset);
            _context.SaveChanges();

            var resultDto = new PlayerAssetDto
            {
                Id = playerAsset.Id,
                PlayerId = playerAsset.PlayerId,
                AssetId = playerAsset.AssetId
            };

            return Ok(resultDto);
        }



    }
}
