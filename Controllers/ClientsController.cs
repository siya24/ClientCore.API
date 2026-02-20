using ClientCore.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateClientDTO createClientDTO)
        {
            try 
            {
                return Ok(await _clientService.AddAsync(createClientDTO));
            }
            catch
            {
                return BadRequest("An error occurred while adding the client.");
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> GetAllAsync([FromBody] CreateClientDTO createClientDTO)
        {
            try
            {
                return Ok(await _clientService.GetAllAsync());
            }
            catch
            {
                return BadRequest("An error occurred while adding the client.");
            }

        }
    }
}
