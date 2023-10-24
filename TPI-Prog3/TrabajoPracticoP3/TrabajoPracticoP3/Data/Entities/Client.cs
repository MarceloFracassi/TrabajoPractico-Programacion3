namespace TrabajoPracticoP3.Data.Entities
{
    public class Client : User
    {
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public object? Order { get; internal set; }

        //public List<Order> Orders { get; set; }
        public ICollection<Order> OrderAttended { get; set; } = new List<Order>();
    }
}