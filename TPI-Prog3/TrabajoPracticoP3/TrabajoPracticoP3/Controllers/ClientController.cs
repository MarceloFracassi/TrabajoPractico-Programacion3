using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpPost]  //Es post?
        public IActionResult SendOrders()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;  //EN AMBOS COPIE Y PEGUE LO DE PABLO, HAY QUE PENSARLO
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
