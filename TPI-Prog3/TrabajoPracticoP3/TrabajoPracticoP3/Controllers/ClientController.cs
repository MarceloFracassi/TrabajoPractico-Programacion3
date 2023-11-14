using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Implementations;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientService;
        private object userId;

        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_clientService.GetClients());
            return Forbid();
        }

        [HttpPost("NewClient")]
        public IActionResult CreateClient([FromBody] ClientPostDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString(); 
            if (role == "Client")
            {
                var client = new Client()
                {
                    Name = dto.Name,
                    SurName = dto.SurName,
                    Email = dto.Email,
                    UserName = dto.UserName,
                    Password = dto.Password,
                    UserType = "Client",
                    Adress = dto.Adress,
                    PhoneNumber = dto.PhoneNumber  
                };

                int id = _clientService.CreateClient(client);

                return Ok(id);
            }
            return Forbid();
        }

        //[HttpPut]
        //public IActionResult UpdateClient([FromBody] ClientUpdateDto updateClient)
        //{

        //    string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

        //    if (role == "Client")
        //    {
        //        Client clientChange = _clientService.GetUserById(userId);
        //        if (clientChange != null)

        //        {
        //            clientChange.Name = updateClient.Name;
        //            clientChange.SurName = updateClient.SurName;
        //            clientChange.UserName = updateClient.UserName;
        //            clientChange.UserType = "Client";
        //            clientChange.Adress = updateClient.Adress;
        //            clientChange.PhoneNumber = updateClient.PhoneNumber   /// tira error el savechange del service ---> dato con null
        //        };

        //        _clientService.UpdateClient(clientChange);  //esVoid

        //        return Ok();
        //    } else
        //        {
        //            return NotFound("Producto no encontrado");
        //        }
        //    return Forbid();
        //}




        //[HttpDelete]
        //public IActionResult DeleteClient()
        //{
        //    int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
        //    _clientService.DeleteClient(id);
        //    return NoContent();
        //}



    }
}
