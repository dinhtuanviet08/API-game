using Microsoft.AspNetCore.Mvc;
using BattleGameAPI.Data;
using BattleGameAPI.Models;

namespace BattleGameAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly BattleGameContext _context;

        public PlayerController(BattleGameContext context)
        {
            _context = context;
        }

        [HttpPost("registerplayer")]
        public IActionResult RegisterPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Ok(player);
        }
        
        [HttpGet("getall")]
        public IActionResult GetAllPlayers()
        {
            var players = _context.Players.ToList();
            return Ok(players);
        }
    }
}
