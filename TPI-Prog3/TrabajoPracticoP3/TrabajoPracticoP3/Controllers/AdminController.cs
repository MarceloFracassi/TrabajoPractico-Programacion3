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
        public IActionResult EditProduct(int productId, [FromBody] ProductUpdateDto updateProduct)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "Admin")
            {
                // Recuperar el producto existente por su ID
                Product existingProduct = _adminService.GetProductById(productId);

                if (existingProduct != null)
                {
                    // Aplicar las actualizaciones
                    existingProduct.Name = updateProduct.Name;
                    existingProduct.Price = updateProduct.Price;

                    // Guardar los cambios
                    _adminService.EditProduct(existingProduct);
                    return Ok();
                }
                else
                {
                    return NotFound("Producto no encontrado"); // Puedes personalizar el mensaje de acuerdo a tus necesidades
                }
            }
            return Forbid();
        }



        [HttpDelete]
        public IActionResult DeleteProduct(int productId)   ///COMO ELIMINAR PRODUCT ID SIN CLAIM.
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                Product productToDelete = _adminService.GetProductById(productId);

                if (productToDelete != null)
                {
                    _adminService.DeleteProduct(productToDelete);
                }
                else
                {
                    return NotFound("producto no encontrado");
                }
            }
            return NoContent();
        }
    }
}
