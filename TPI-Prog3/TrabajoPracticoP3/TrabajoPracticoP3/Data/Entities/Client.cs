namespace TrabajoPracticoP3.Data.Entities
{
    public class Client : User
    {
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
      


        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}