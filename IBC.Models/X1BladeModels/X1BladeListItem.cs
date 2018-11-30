using IBC.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Models.X1BladeModels
{
    public class X1BladeListItem
    {
        public int X1BladeId { get; set; }
        public Injury Injury { get; set; }
        public string FootSize { get; set; }
        public Foot Foot { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset Created { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
