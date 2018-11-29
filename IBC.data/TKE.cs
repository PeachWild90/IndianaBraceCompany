using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.data
{
    public class TKE
    {
        [Key]
        public int TKEId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Reason { get; set; } //why are you using this product?
        [Required]
        public int Quantity { get; set; }
    }
}
