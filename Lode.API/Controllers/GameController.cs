using Lode.logic;
using Microsoft.AspNetCore.Mvc;

namespace Lode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        [HttpGet("CreateGame/{PlayerName1},{PlayerName2}")]
        public ActionResult GameCreated(string PlayerName1, string PlayerName2)
        {
            //GameManager.GameCreated(PlayerName1, PlayerName2); 
            return Ok();
        }
    }
}
