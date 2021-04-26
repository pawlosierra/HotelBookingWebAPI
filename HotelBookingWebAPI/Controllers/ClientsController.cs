using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HotelBookingWebAPI.Application.Commands.Clients.AddClient;
using HotelBookingWebAPI.Application.Commands.Clients.UpdateClient;
using HotelBookingWebAPI.Application.Queries.Clients.GetClients;
using HotelBookingWebAPI.Domain.Models.Reservation;
using HotelBookingWebAPI.DTOs.Client;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetClients());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ClientRequest clientRequest)
        {
            try
            {
                var client = _mapper.Map<Client>(clientRequest);
                var clientValidation = await _mediator.Send(new AddClient(client));
                var result = _mapper.Map<ClientValidationResponse>(clientValidation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required(ErrorMessage = "The field clientId is required")]
                                                [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
                                                int clientId,
            ClientRequest clientRequest

                                                )
        {
            try
            {
                var clientUpdateRequest = _mapper.Map<Client>(clientRequest);
                var clientValidation = await _mediator.Send(new UpdateClient(clientUpdateRequest, clientId));
                var result = _mapper.Map<ClientValidationResponse>(clientValidation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
