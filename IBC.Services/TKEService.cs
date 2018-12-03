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

        public IEnumerable<TKEListItem> GetTKEs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TKEs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TKEListItem
                                {
                                    TKEId = e.TKEId,
                                    Reason = e.Reason,
                                    Quantity = e.Quantity,
                                }
                       );

                return query.ToArray();
            }
        }

        public TKEDetail GetTKEById(int tKEId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TKEs
                        .Single(e => e.TKEId == tKEId && e.OwnerId == _userId);
                return
                    new TKEDetail
                    {
                        TKEId = entity.TKEId,
                        Reason = entity.Reason,
                        Quantity = entity.Quantity
                    };
            }
        }

        public bool UpdateTKE(TKE_Edit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TKEs
                        .Single(e => e.TKEId == model.TKEId && e.OwnerId == _userId);

                entity.Reason = model.Reason;
                entity.Quantity = model.Quantity;

                return ctx.SaveChanges() == 1;
            }
        }
    }


}
