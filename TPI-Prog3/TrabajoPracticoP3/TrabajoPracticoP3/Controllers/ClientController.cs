using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoPracticoP3.Services.Implementations;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientService;

        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetClients()
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_clientService.GetClients());
            return Forbid();
        }

        [HttpPost]
        public IActionResult SendOrders()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;  // CLAIM ---> USER COMO IDENTIFICAR EL PRODUCTO POR EL ID
            if (role == "Client")
                return Ok(_clientService.SendOrders());
            return Forbid();
        }



        [HttpPut]  //Es put ?
        public IActionResult ModifyOrder()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Client")
                return Ok(_clientService.ModifyOrder());
            return Forbid();
        }
    }
}
