using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Security.Claims;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Implementations;
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
        public IActionResult AddProduct([FromBody] ProductPostDto dto)  ///PRODUCT DTO
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")

            {
                var product = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,

                };
                int id = _adminService.AddProduct(product);

                return Ok(id);
            }
            return Forbid();

        }



        [HttpPut]
        public IActionResult EditProduct([FromBody] ProductUpdateDto updateProduct)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value; //ESTO ESTA BIEN ?? 
            if (role == "Admin")
            {
                Product productUpdate = new Product()

                ///COMO HACER PARA QUE ADMIN MODIFIQUE UN PRODUCTO que no CLAIM
                {

                    Name = updateProduct.Name,
                    Price = updateProduct.Price,

                };

                _adminService.EditProduct(productUpdate);
                return Ok();

            }
            return Forbid();
        }




        [HttpDelete]
        public IActionResult DeleteProduct()   ///COMO ELIMINAR PRODUCT ID SIN CLAIM.
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                _adminService.DeleteProduct(id);
            }
            return NoContent();
        }
    }
}
