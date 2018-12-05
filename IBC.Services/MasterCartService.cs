using IBC.data;
using IBC.Data;
using IBC.Models.MasterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Services
{
   public class MasterCartService
    {
        private readonly Guid _userId;

        public MasterCartService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCart(MasterCartCreate model)
        {
            var entity =
                new MasterCart() //this creates an instance of Cart !!
                {
                    OwnerId = _userId,
                    FaceMaskId = model.FaceMaskId,
                    TKEId = model.TKEId,
                    X1BladeId = model.X1BladeId
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MasterCarts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MasterCartList> GetMasterCarts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MasterCarts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                             e =>
                                    new MasterCartList
                                    {
                                        X1BladeId = e.X1BladeId,
                                        //Injury = e.Injury,
                                        //FootSize = e.FootSize,
                                        //Foot = e.Foot,
                                        //X1Quantity = e.X1Quantity,

                                        TKEId = e.TKEId,
                                        //Reason = e.Reason,
                                        //TKEQuantity = e.TKEQuantity,

                                        FaceMaskId = e.FaceMaskId,
                                        //Style = e.Style,
                                        //Personalization = e.Personalization,
                                        //Color = e.Color,
                                        //Height = e.Height,
                                        //Weight = e.Weight,
                                        //Sport = e.Sport,
                                        //FMQuantity = e.FMQuantity
                                    }
                          );

                var query2 =
                    ctx
                        .FaceMasks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                                    new MasterCartList
                                    {
                                        FaceMaskId = e.FaceMaskId,
                                    }
                           );


                var query3 =
                    ctx
                        .TKEs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                                    new MasterCartList
                                    {
                                        TKEId = e.TKEId,
                                    }
                                    );


                var query4 =
                    ctx
                        .X1Blades
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                                e =>
                                    new MasterCartList
                                    {
                                        X1BladeId = e.X1BladeId,
                                    }
                                    );

                return query.ToArray();
            }
        }

        public bool DeleteMasterCart(int masterCartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                           .MasterCarts
                           .Single(e => e.FaceMaskId == masterCartId && e.OwnerId == _userId);

                ctx.MasterCarts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
