namespace EventTicketAPI.Core
{
    public class Tickets
    {

        public int Id { get; set; }
        public string QRCode { get; set; }
        public bool IsUsed { get; set; }
        //Additional properties specific to tickets
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
