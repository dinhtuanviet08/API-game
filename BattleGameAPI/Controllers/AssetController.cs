using Microsoft.AspNetCore.Mvc;
using BattleGameAPI.Data;
using BattleGameAPI.Models;

namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly BattleGameContext _context;

        public AssetController(BattleGameContext context)
        {
            _context = context;
        }

        [HttpPost("createasset")]
        public IActionResult CreateAsset(Asset asset)
        {
            _context.Assets.Add(asset);
            _context.SaveChanges();
            return Ok(asset);
        }

        [HttpGet("getall")]
        public IActionResult GetAllAssets()
        {
            var assets = _context.Assets.ToList();
            return Ok(assets);
        }
    }
}
