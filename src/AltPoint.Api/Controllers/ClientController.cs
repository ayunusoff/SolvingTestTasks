﻿using AltPoint.Application.Common;
using AltPoint.Application.DTOs.Errors;
using AltPoint.Application.DTOs.Request;
using AltPoint.Application.DTOs.Response;
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

        //https://localhost:7038/api/Client?SortQuery[0].SortBy=surname&SortQuery[0].SortDir=desc&Limit=10&Page=1&Search
        //https://localhost:7038/api/Client?Limit=10&Page=1&Search&SortQuery[0].SortBy=dob&SortQuery[0].SortDir=Desc&SortQuery[1].SortBy=MonIncome&SortQuery[1].SortDir=Desc
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ClientQueryRequest parameters)
        {
            try
            {
                ClientPaginationResponse clients = await _clientService.GetAllClientsWithParam(parameters);

                return Ok(clients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{clientId}")]
        public IActionResult GetById(Guid clientId)
        {
            try
            {
                ClientWithSpouseResponse client = _clientService.GetClient(clientId);

                return Ok(client);
            }
            catch (ArgumentNullException)    
            {
                return NotFound(new Error { status = 404, code = ErrorCode.ENTITY_NOT_FOUND });
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
            catch (ValidationException e)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                return new JsonResult(GetValidationErrResponse(e));
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("{clientId}")]
        public IActionResult Patch(Guid clientId, [FromBody] string value)
        {
            try
            {
                return Ok();
            }
            catch (ValidationException e)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                return new JsonResult(GetValidationErrResponse(e));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> Put(Guid clientId, [FromBody] ClientRequest clientRequest)
        {
            try
            {
                await _clientService.UpdateClient(clientId, clientRequest);
                return Ok();
            }
            catch (ValidationException e)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                return new JsonResult(GetValidationErrResponse(e));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(Guid clientId)
        {
            try
            {
                await _clientService.DeleteClient(clientId);

                return Ok("Клиент мягко удален");
            }
            catch (ArgumentNullException)
            {
                return NotFound(new Error { status = 404, code = ErrorCode.ENTITY_NOT_FOUND });
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
