using IBC.data;
using IBC.Data;
using IBC.Models.TKEModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Services //push and pull TKE's from the database
{
    public class TKEService
    {
        private readonly Guid _userId;

        public TKEService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTKE(TKECreate model)
        {
            var entity =
                new TKE()
                {
                    OwnerId = _userId,
                    Reason = model.Reason,
                    Quantity = model.Quantity
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TKEs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

       public IEnumerable
    }

    
}
