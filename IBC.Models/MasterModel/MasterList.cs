using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.MasterModel
{
    public class MasterList
    {
        //X1
        public int X1BladeId { get; set; }
        public Injury Injury { get; set; }
        public string FootSize { get; set; }
        public Foot Foot { get; set; }
        public int X1Quantity { get; set; }
        public int X1Price { get; set; }

        //TKE
        public int TKEId { get; set; }
        public int TKEQuantity { get; set; }
        public int TKEPrice { get; set; }
        public string Reason { get; set; }

        //FaceMask
        public int FaceMaskId { get; set; }
        public int FMQuantity { get; set; }
        public int FMPrice { get; set; }
        public Style Model { get; set; }
        public Personalization Personalization { get; set; }
        public Color Color { get; set; }
        public string Height { get; set; }
        [Display(Name = "fatty")]
        public string Weight { get; set; }
        public string Sport { get; set; }
    }
}
