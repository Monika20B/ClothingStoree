using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingStoree.Models
{
    public class BoughtJewels
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customers Customers { get; set; }
        public int JewelId { get; set; }

        public Jewels Jewels { get; set; }
    }
}