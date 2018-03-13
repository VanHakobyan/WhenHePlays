using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Parser;

namespace API.Controllers
{
    [Produces("application/json")]
    [EnableCors("MyPolicy")]
    public class ArsenalController : Controller
    {
        ArsenalPasrser _arsenalPasrser = new ArsenalPasrser();
        LineupsParser _lineupsParser=new LineupsParser();

        [HttpGet, Route("api/Arsenal")]
        public async Task<IActionResult> Get()
        {
            var content = await _arsenalPasrser.GetContent();
            return Ok(content);
        }

        [Route("api/Arsenal/lineups"), HttpGet]
        public async Task<IActionResult> GetLineups()
        {
            var lineups = await _lineupsParser.GetLineups();
            return Ok(lineups);
        }
    }
}