using AltPoint.Application.Common;
using AltPoint.Application.DTOs;
using AltPoint.Application.DTOs.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        //https://localhost:7038/api/Client?Limit=10&Page=1&Search=Test&SortBy=dob&SortDir=Asc
        [HttpGet]
        public async Task<IActionResult> GetClientsWithParam([FromQuery] ClientQueryDTO parameters)
        {
            ClientPaginationDTO clients = await _clientService.GetClientsWithParam(parameters);
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public IActionResult GetById(Guid clientId)
        {
            ClientWithSpouseDTO client = _clientService.GetClient(clientId);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientWithSpouseDTO clientRequest)
        {
            Guid id = await _clientService.PostClient(clientRequest)!;
            return StatusCode((int)HttpStatusCode.Created, id);
        }

        [HttpPatch("{clientId}")]
        public async Task<IActionResult> Patch(Guid clientId, [FromBody] List<PatchDTO> patchDTOs)
        {
            await _clientService.PatchClient(clientId, patchDTOs);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClientWithSpouseDTO clientRequest)
        {
            await _clientService.UpdateClient(clientRequest);
            return NoContent();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(Guid clientId)
        {
            await _clientService.DeleteClient(clientId);
            return NoContent();
        }

    }
}
