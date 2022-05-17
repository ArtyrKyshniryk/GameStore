using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employeer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartWorkDate { get; set; }
        public DateTime EndtWorkDate { get; set; }
        public List<Product> Products { get; set; }
    }
}
