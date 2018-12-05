using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.MasterModel
{
   public class MasterCartCreate
    {
        public int FaceMaskId { get; set; }
        public int X1BladeId { get; set; }
        public int TKEId { get; set; }
    }
}
