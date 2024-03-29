﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFramework.DbModels
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
