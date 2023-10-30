using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminService;

        public AdminController(IAdminServices adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]  //Es post?
        public IActionResult AddProduct()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;  //EN AMBOS COPIE Y PEGUE LO DE PABLO, HAY QUE PENSARLO
            if (role == "Admin")
                return Ok(_adminService.AddProduct());
            return Forbid();
        }

        [HttpPut]  //put o patch
        public IActionResult EditProduct()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;  //EN AMBOS COPIE Y PEGUE LO DE PABLO, HAY QUE PENSARLO
            if (role == "Admin")
                return Ok(_adminService.AddProduct());
            return Forbid();
        }

        [HttpDelete]  //Es put ?
        public IActionResult DeleteProduct()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
                return Ok(_adminService.DeleteProduct());
            return Forbid();
        }
    }
}
