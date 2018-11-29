using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.data
{
    //facemask enums
    public enum Style { Hoosier, Raptor, Madrid, Jaws}
    public enum Personalization {[Display(Name = "Broken Nose")] BrokenNose , [Display(Name = "Right Orbit Fracture")] OrbitRight, [Display(Name = "Left Orbit Fracture")] OrbitLeft, [Display(Name = "Broken Nose with Right Orbit Fracture")] BNOR, [Display(Name = "Broken Nose with Left Orbit Fracture")] BNOL, [Display(Name = "Left TMJ Fracture")] TMJLeft, [Display(Name = "Right TMJ Fracture")] TMJRight, [Display(Name = "Left Cheek Fracture")] CheekLeft, [Display(Name = "Right Cheek Fracture")] CheekRight, [Display(Name = "Lower Jaw Fracture - Left")] LowerJawLeft, [Display(Name = "Lower Jaw Fracture - Right")] LowerJawRight, [Display(Name = "Front Jaw Fracture")] FrontJaw }
    public enum Color { Clear, Black }

    public class FaceMask
    {
        [Key] //this attribute specifies the property that UNIQUELY identifies an entity. It is the PRIMARY KEY of the corresponding DB
        public int FaceMaskId { get; set; }   

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Style Style { get; set; }

        [Required]
        public Personalization Personalization { get; set; }

        [Required]
        public Color Color { get; set; }
  
        [Required]
        public string Height { get; set; }

        [Required]

        public string Weight { get; set; }

        [Required]
        public string Sport { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]

        public DateTimeOffset CreatedUtc { get; set; } 
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
