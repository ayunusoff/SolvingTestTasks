using AltPoint.Application.Common;
using AltPoint.Application.DTOs;
using AltPoint.Application.DTOs.Errors;
using AltPoint.Application.Services;
using AltPoint.Domain.Common;
using AltPoint.Domain.Entities;
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

        //https://localhost:7038/api/Client?Limit=10&Page=1&Search=Test&SortQuery[0].SortBy=dob&SortQuery[0].SortDir=Asc&SortQuery[1].SortBy=MonIncome&SortQuery[1].SortDir=Desc
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ClientQueryDTO parameters)
        {
            try
            {
                ClientPaginationDTO clients = await _clientService.GetAllClientsWithParam(parameters);
                return Ok(clients);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Error { code = ErrorCode.INTERNAL_SERVER_ERROR, status = 500 });
            }
        }

        [HttpGet("{clientId}")]
        public IActionResult GetById(Guid clientId)
        {
            try
            {
                ClientWithSpouseDTO client = _clientService.GetClient(clientId);
                return Ok(client);
            }
            catch (ArgumentNullException)    
            {
                return NotFound(new Error { status = 404, code = ErrorCode.ENTITY_NOT_FOUND });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Error { code = ErrorCode.INTERNAL_SERVER_ERROR, status = 500 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientWithSpouseDTO clientRequest)
        {
            try
            {
                Guid id = await _clientService.PostClient(clientRequest)!;
                return StatusCode((int)HttpStatusCode.Created, id);
            }
            catch (ValidationException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, GetValidationErrResponse(e));
            }
            catch (Exception) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Error { code = ErrorCode.INTERNAL_SERVER_ERROR, status = 500 });
            }
        }

        [HttpPatch("{clientId}")]
        public async Task<IActionResult> Patch(Guid clientId, [FromBody] ClientWithSpouseDTO clientRequest)
        {
            try
            {
                await _clientService.PatchClient(clientId, clientRequest);
                return Ok();
            }
            catch (ValidationException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, GetValidationErrResponse(e));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Error { code = ErrorCode.INTERNAL_SERVER_ERROR, status = 500 });
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ClientWithSpouseDTO clientRequest)
        {
            try
            {
                await _clientService.UpdateClient(clientRequest);
                return NoContent();
            }
            catch (ValidationException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, GetValidationErrResponse(e));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Error { code = ErrorCode.INTERNAL_SERVER_ERROR, status = 500 });
            }
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(Guid clientId)
        {
            try
            {
                await _clientService.DeleteClient(clientId);
                return StatusCode((int)HttpStatusCode.NoContent, "Клиент мягко удален");
            }
            catch (ArgumentNullException)
            {
                return NotFound(new Error { status = 404, code = ErrorCode.ENTITY_NOT_FOUND });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new Error { code = ErrorCode.INTERNAL_SERVER_ERROR, status = 500 });
            }
        }

        private ValidationError GetValidationErrResponse(ValidationException e)
        {
            var errors = e.Errors.Select(x => new ValidationExceptions
            {
                field = x.PropertyName,
                rule = x.ErrorCode,
                message = x.ErrorMessage
            }).ToList();

            return new ValidationError { status = (int)HttpStatusCode.UnprocessableEntity, code = ErrorCode.VALIDATION_EXCEPTION, exceptions = errors };
        }
    }
}
