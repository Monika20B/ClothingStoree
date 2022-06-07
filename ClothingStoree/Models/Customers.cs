using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingStoree.Models
{
    public class Customers
    {
        public Customers()
        {
            this.Jewels = new HashSet<Jewels>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int Clothes_ID { get; set; }
        public virtual Clothes Clothes { get; set; }
        public ICollection<Jewels> Jewels { get; set; }
    }
}