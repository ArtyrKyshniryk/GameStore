namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Address Address{ get; set; }
        public List<Product> Products { get; set; }
        public User User { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime DeliverDate { get; set; }
    }
}
