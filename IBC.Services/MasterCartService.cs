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
            using (var ctx = new ApplicationDbContext()) //snapshot of state of db
            {
                //TODO: Create variables for each data table
                //TODO: Verify the owner ID
                //TODO: Add objects to one list
                //TODO: Return List

                List<MasterCartList> carts = new List<MasterCartList>();

                var fmQuery =
                   ctx.FaceMasks //snapshot of fm table
                   .Where(e => e.OwnerId == _userId); //asserts we only taking out of fm when id is correct. specific collection of fm by ID


                var x1Query =
                    ctx.X1Blades
                    .Where(e => e.OwnerId == _userId);

                var tkeQuery =
                    ctx.TKEs
                    .Where(e => e.OwnerId == _userId);


                foreach (var f in fmQuery) //repackaging properties into new MasterCartList object, sending it back to index
                {
                    carts.Add(new MasterCartList
                    {
                        FaceMaskId = f.FaceMaskId,
                        Style = f.Style,
                        Quantity = f.Quantity,
                        PriceValue = (f.Quantity * 249.99m)
                    }
                    );
                }

                foreach (var x in x1Query)
                {
                    carts.Add(new MasterCartList
                    {
                        X1BladeId = x.X1BladeId,
                        Injury = x.Injury,
                        Quantity = x.Quantity,
                        PriceValue = (x.Quantity * 99.00m)
                    }
                    );
                }

                foreach (var t in tkeQuery)
                {
                    carts.Add(new MasterCartList
                    {
                        TKEId = t.TKEId,
                        Reason = t.Reason,
                        Quantity = t.Quantity,
                        PriceValue = (t.Quantity * 399.00m)
                    }
                    );
                }
                return carts;
            }
        }

        //TODO: 
        //make a list of master items ?

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
