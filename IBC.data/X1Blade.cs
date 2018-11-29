using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.data
{
    public enum Injury { MidFootSprainArthritis, BunionPain, GreatToePainArthritis, JonesFracture, Sesamoiditis, TurfToe, NeuromaPain, PlantarFasciitis }
    public enum Foot { Right, Left, [Display (Name = "Right & Left")] RightLeft}
    public class X1Blade
    {
        [Key]
        public int X1BladeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public Injury Injury { get; set; }
        [Required]
        public string FootSize { get; set; }
        [Required]
        public Foot Foot { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
