using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BattleGameAPI.Data;

namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly BattleGameContext _context;

        public ReportController(BattleGameContext context)
        {
            _context = context;
        }

        [HttpGet("getassetsbyplayer")]
        public IActionResult GetAssetsByPlayer()
        {
            var result = _context.PlayerAssets
                .Include(pa => pa.Player)
                .Include(pa => pa.Asset)
                .Select(pa => new
                {
                    pa.Player.PlayerName,
                    pa.Player.FullName,
                    pa.Player.Level,
                    pa.Player.Age,
                    pa.Asset.AssetName
                }).ToList();

            return Ok(result);
        }
    }
}
