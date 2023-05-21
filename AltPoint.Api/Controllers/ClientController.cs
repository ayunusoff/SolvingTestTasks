using AltPoint.Application.Common;
using AltPoint.Application.Services;
using AltPoint.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace AltPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] QueryParameters parameters)
        {
            var clients = _clientService.GetAllClientsWithParam(parameters);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPatch("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{clientId}")]
        public IActionResult Delete(Guid clientId)
        {
            try
            {
                _clientService.DeleteClient(clientId);

                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
