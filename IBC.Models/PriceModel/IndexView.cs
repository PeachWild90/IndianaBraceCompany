using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBC.data;

namespace IBC.Models.PriceModel
{
   public class IndexView
    {
        public decimal Price { get; set; }
        public IEnumerable<FaceMask> List { get; set; }
        public IEnumerable<X1Blade> XList { get; set; }
        public IEnumerable<TKE> TList { get; set; }
        public IEnumerable<MasterCart> MList { get; set; }
    }
}
