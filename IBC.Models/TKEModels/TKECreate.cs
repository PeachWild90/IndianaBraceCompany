using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.TKEModels
{
    public class TKECreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Brevity is the soul of wit...")]
        public string Reason { get; set; } //why are you using this product?
        [Required]
        public int Quantity { get; set; }
    }
}
