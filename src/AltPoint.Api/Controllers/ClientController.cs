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

        //https://localhost:7038/api/Client?SortQuery[0].SortBy=surname&SortQuery[0].SortDir=desc&Limit=10&Page=1&Search
        //https://localhost:7038/api/Client?Limit=10&Page=1&Search&SortQuery[0].SortBy=dob&SortQuery[0].SortDir=Desc&SortQuery[1].SortBy=MonIncome&SortQuery[1].SortDir=Desc
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ClientQueryRequest parameters)
        {
            ClientPaginationResponse clients = await _clientService.GetAllClientsWithParam(parameters);
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public IActionResult GetById(Guid clientId)
        {
            try
            {
                ClientResponse client = _clientService.GetClient(clientId);
                return Ok(client);
            }
            catch(NullReferenceException e) 
            {
                return NotFound(e.Message);
            } 
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientRequest clientRequest)
        {
            try
            {
                Guid id = await _clientService.PostClient(clientRequest)!;
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
