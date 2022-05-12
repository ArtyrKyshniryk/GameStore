namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public Category SubCategory { get; set; }
    }
}
