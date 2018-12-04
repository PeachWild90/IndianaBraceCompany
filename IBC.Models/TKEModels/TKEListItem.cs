using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.TKEModels
{
    public class TKEListItem
    {
        public int TKEId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Reason { get; set; }

    }
}
