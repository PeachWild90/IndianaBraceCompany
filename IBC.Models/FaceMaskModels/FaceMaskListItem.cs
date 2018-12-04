using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.FaceMaskModels
{

   public class FaceMaskListItem //THE VIEW FACEMASK.CSHTML IS BASED ON THESE PROPERTIES LISTED 
    {
        public int FaceMaskId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public Style Model { get; set; }
        public Personalization Personalization { get; set; }
        public Color Color { get; set; }
        public string Height { get; set; }
        [Display(Name ="fatty")] //THIS CHANGES THE WAY IT SHOWS UP IN THE VIEW
        public string Weight { get; set; }
        public string Sport { get; set; }

    }
}
