using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateWeb.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other,
    }
    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }
    }
}
