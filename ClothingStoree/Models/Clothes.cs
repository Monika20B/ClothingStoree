using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace ClothingStoree.Models
{
    public class Clothes
    {
        [Key]
        public int Clothes_ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
       
        public double Price { get; set; }

        public  ICollection<Customers> Customers { get; set; }

    }
}