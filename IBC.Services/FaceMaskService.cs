using IBC.data;
using IBC.Data;
using IBC.Models.FaceMaskModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Services
{
    public class FaceMaskService //1-create constructor and a private Guid field _userId 
    {
        private readonly Guid _userId;

        public FaceMaskService(Guid userId)
        {
            _userId = userId;
        }

        //2-add CreateFaceMask method within the FaceMaskService

        public bool CreateFaceMask(FaceMaskCreate model)
        {
            var entity =
                new FaceMask() //this creates an instance of FaceMask !!
                {
                    OwnerId = _userId,
                    Style = model.Style,
                    Personalization = model.Personalization,
                    Color = model.Color,
                    Height = model.Height,
                    Weight = model.Weight,
                    Sport = model.Sport,
                    Quantity = model.Quantity
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FaceMasks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
                            //we defined this earlier. It is connected to the view/css!
        public IEnumerable<FaceMaskListItem> GetNotes() //This method shows us all the FaceMasks that belong to a specific user...
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FaceMasks
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                             e =>
                                    new FaceMaskListItem
                                    {
                                        FaceMaskId = e.FaceMaskId,
                                        Model = e.Style,
                                        Personalization = e.Personalization,
                                        Color = e.Color,
                                        Height = e.Height,
                                        Weight = e.Weight,
                                        Sport = e.Sport,
                                        Quantity = e.Quantity
                                    }
                          );

                return query.ToArray();
            }
        }
    }
}
