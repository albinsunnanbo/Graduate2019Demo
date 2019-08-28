using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFramework.DbModels
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
