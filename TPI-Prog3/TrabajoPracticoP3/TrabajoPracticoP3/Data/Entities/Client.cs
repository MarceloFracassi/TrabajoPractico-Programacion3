namespace TrabajoPracticoP3.Data.Entities
{
    public class Client : User
    {
        public string? City { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
    }
}