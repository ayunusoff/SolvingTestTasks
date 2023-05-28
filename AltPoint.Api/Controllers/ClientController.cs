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
        ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ClientQueryRequest parameters)
        {
            ClientPaginationResponse clients = await _clientService.GetAllClientsWithParam(parameters);

            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public IActionResult Get(Guid clientId)
        {
            try
            {
                ClientResponse clientResponse = _clientService.GetClient(clientId);

                return Ok(clientResponse);
            }
            catch (Exception ex) // TODO
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientRequest clientRequest)
        {
            try
            {
                Guid id = await _clientService.PostClient(clientRequest);

                return Ok(id);
            }
            catch (Exception ex) // TODO
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{clientId}")]
        public IActionResult Patch(Guid clientId, [FromBody] ClientRequest clientRequest)
        {
            try
            {
                //Guid id = _clientService.PostClient(clientRequest); // TODO

                return Ok("Данные клиента успешо обновленны");
            }
            catch (Exception ex) // TODO
            {
                return NotFound(ex.Message);
            }
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
