using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SaleOrderLineController : ControllerBase
{
    private readonly ISaleOrderLineServices _saleOrderLineServices;
    private readonly IOrderServices _orderServices;
    private readonly IAdminServices _adminServices;

    public SaleOrderLineController(ISaleOrderLineServices saleOrderLineServices, IOrderServices orderServices, IAdminServices adminServices)
    {
        _saleOrderLineServices = saleOrderLineServices;
        _orderServices = orderServices;
        _adminServices = adminServices;
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
            // Obtiene el ID del cliente desde las reclamaciones del usuario.
            int clientId = int.Parse(User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            // Obtiene el último ID de la orden para el cliente.
            Order latestOrder = _orderServices.GetLatestOrderForClient(clientId);
            if (latestOrder == null)
            {
                // Puedes manejar este caso según tus requisitos, por ejemplo, retornar un BadRequest
                return BadRequest("No hay órdenes para este cliente.");
            }

            int orderId = latestOrder.Id;

            // Filtra los detalles del producto por su ID utilizando el servicio de Admin
            Product product = _adminServices.GetProductById(saleOrderLinePostDto.ProductId);
            if (product == null)
            {
                // Puedes manejar este caso según tus requisitos, por ejemplo, retornar un BadRequest
                return BadRequest("Producto no encontrado.");
            }

            // Crea la línea de orden de venta incluyendo los detalles del producto
            SaleOrderLine saleOrderLinePost = new SaleOrderLine()
            {
                OrderId = orderId,
                ProductId = saleOrderLinePostDto.ProductId,
                ProductQuntity = saleOrderLinePostDto.ProductQuntity,
                Product = product // Asigna el producto a la línea de orden de venta
            };

            _saleOrderLineServices.AddSaleOrderLine(saleOrderLinePost);

            return Ok(saleOrderLinePost);
        }

        return Forbid();
    }
}
