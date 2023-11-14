using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPI_P3_grupal.Data.Enum;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Implementations;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISaleOrderLineServices _saleOrderLineServices;

        public SaleOrderLineController(ISaleOrderLineServices saleOrderLineServices)
        {
            _saleOrderLineServices = saleOrderLineServices;
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleOrderLine([FromRoute] int id)
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Admin")
            {
                var saleOrderLine = _saleOrderLineServices.GetSaleOrderLine(id);
                if (saleOrderLine != null)
                {
                    return Ok(saleOrderLine);
                }
                return NotFound();
            }
            return Forbid();
        }


        [HttpPost]
        public IActionResult AddSaleOrderLine([FromBody] SaleOrderLinePostDto saleOrderLinePostDto)
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Client")
            {

                //foreach (var saleOrderLine in saleOrderLine)
                //{
                //    saleOrderLine.SaleOrderId = order.Id;
                //}

                var product = _saleOrderLineServices.GetSaleOrderLine(saleOrderLinePostDto.ProductId);
                decimal total = product.Price * saleOrderLinePostDto.ProductQuntity;

                SaleOrderLine saleOrderLinePost = new SaleOrderLine()
                {
                    OrderId = saleOrderLinePostDto.OrderId,
                    ProductId = saleOrderLinePostDto.ProductId,
                    ProductQuntity = saleOrderLinePostDto.ProductQuntity,

                };

                _saleOrderLineServices.AddSaleOrderLine(saleOrderLinePost);
            };
            return Forbid();
        }
    }
}
