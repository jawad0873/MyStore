namespace MyStore.Models
{
    public class AdminViewModel
    {
        public int Id { get; set; }  // You can use an ID field if needed
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

    }
}
