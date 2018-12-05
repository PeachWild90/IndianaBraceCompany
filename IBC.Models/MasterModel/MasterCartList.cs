using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.MasterModel
{
    public class MasterCartList
    {
        public int MasterCartId { get; set; }

        public int X1BladeId { get; set; }
        
        public int TKEId { get; set; }
        
        public int FaceMaskId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public TKE TKE { get; set; }

        public FaceMask FaceMask { get; set; }

        public X1Blade X1Blade { get; set; }

    }
}
//list master cart kust cart = bew kust naster cartkust

   