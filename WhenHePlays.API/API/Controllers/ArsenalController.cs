using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Parser;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/Arsenal")]
    [EnableCors("MyPolicy")]
    public class ArsenalController : Controller
    {
        ArsenalPasrser _arsenalPasrser = new ArsenalPasrser();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var content = await _arsenalPasrser.GetContent();
            return Ok(content);
        }
    }
}