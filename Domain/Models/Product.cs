using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Photo> Photos { get; set; }
        public string Description { get; set; }
        public List<Review> Reviews { get; set; }
        public Category Category { get; set; }
        public Employeer Employeer { get; set; }
    }
}
