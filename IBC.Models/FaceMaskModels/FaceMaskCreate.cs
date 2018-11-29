using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.FaceMaskModels
{
    public class FaceMaskCreate
    {
        [Key]
        public int FaceMaskId { get; set; }
        [Required]
        public Model Model { get; set; }
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
    }
}
