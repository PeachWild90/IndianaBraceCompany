using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.X1BladeModels
{
    public class X1BladeCreate
    {
        [Required]
        public Injury Injury { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter a valid shoe size.")]
        [MaxLength(100, ErrorMessage = "Your feet are too damn big!")]
        public string FootSize { get; set; }
        [Required]
        public Foot Foot { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
