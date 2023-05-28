using AltPoint.Application.Common;
using AltPoint.Application.DTOs.Request;
using AltPoint.Application.DTOs.Response;
using AltPoint.Application.Services;
using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AltPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ClientQueryRequest parameters)
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

                return Ok("Клиент мягко удален");
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
