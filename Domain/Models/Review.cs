using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public DateTime DateTimeReview { get; set; }
        public int Rate { get; set; }
        public User ReviewUser { get; set; }
        public Product Product { get; set; }
    }
}
