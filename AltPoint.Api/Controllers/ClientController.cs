using AltPoint.Application.Common;
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
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parameters)
        {
            var clients = await _clientService.GetAllClientsWithParam(parameters);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetWithSpouse(Guid id)
        {
            try
            {
                var client = _clientService.GetClientWithSpouse(id);
                return Ok(client);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            try
            {
                await _clientService.AddClient(client);
                return Ok();
            }
            catch(NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
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
