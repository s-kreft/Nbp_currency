using Microsoft.AspNetCore.Mvc;
using Nbp_currency.Service;
using Nbp_currency.Models;


namespace Nbp_currency.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class NbpController : ControllerBase
    {
        private readonly INbpService _nbpService;

        public NbpController(INbpService nbpService)
        {
            _nbpService = nbpService;
        }

        [HttpGet]
        [Route("/get")]
        public async Task <ActionResult<List<Root>>> getCurrenciesList([FromBody]UserInput userInput)
        {
            return await _nbpService.responseCurrencyList(userInput);
        }
    }
}
