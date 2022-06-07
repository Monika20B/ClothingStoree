using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingStoree.Models
{
    public class Jewels
    {
        public Jewels()
        {
            this.Customers = new HashSet<Customers>();
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public  ICollection<Customers> Customers { get; set; }

    }
}