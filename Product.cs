namespace EventTicketAPI.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string ProductType { get; set; } //e.g  "Ticket", "Non-Ticket"
        // Other common product properties


    }

}  