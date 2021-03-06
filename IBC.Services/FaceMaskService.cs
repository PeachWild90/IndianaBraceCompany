﻿using IBC.data;
using IBC.Data;
using IBC.Models.FaceMaskModels;
using IBC.Models.PriceModel;
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
        
        //method needs to pull all quantities from DB, then multiply for a fixed amount
        //public decimal Calculate(int quantity) 
        //{
        //    var priceValue = quantity * 249.99m;
        //    return priceValue;
             
        //}

        public decimal Calculate(int quantity, decimal price)
        {
            IndexView x = new IndexView();

            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.FaceMasks.Where(e => e.Quantity == quantity);

            x.List = query.ToArray();
            x.Price = quantity * 249.99m;

                return price;
            }
        }

                            //we defined this earlier. It is connected to the view/css!
        public IEnumerable<FaceMaskListItem> GetFaceMasks() //This method shows us all the FaceMasks that belong to a specific user...
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
                                        Style = e.Style,
                                        Personalization = e.Personalization,
                                        Color = e.Color,
                                        Height = e.Height,
                                        Weight = e.Weight,
                                        Sport = e.Sport,
                                        Quantity = e.Quantity,
                                        PriceValue = (e.Quantity * 249.99m)

                                    }
                          );

                return query.ToArray();
            }
        }

        public FaceMaskDetail GetFaceMaskById(int faceMaskId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FaceMasks
                        .Single(e => e.FaceMaskId == faceMaskId && e.OwnerId == _userId);
                return
                    new FaceMaskDetail
                    {
                        FaceMaskId = entity.FaceMaskId,
                        Style = entity.Style,
                        Personalization = entity.Personalization,
                        Color = entity.Color,
                        Height = entity.Height,
                        Weight = entity.Weight,
                        Sport = entity.Sport,
                        Quantity = entity.Quantity,
                    };
            }
        }

        public bool UpdateFaceMask(FaceMaskEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FaceMasks
                        .Single(e => e.FaceMaskId == model.FaceMaskId && e.OwnerId == _userId);

                entity.Style = model.Style;
                entity.Personalization = model.Personalization;
                entity.Color = model.Color;
                entity.Height = model.Height;
                entity.Weight = model.Weight;
                entity.Sport = model.Sport;
                entity.Quantity = model.Quantity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFaceMask(int faceMaskId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                           .FaceMasks
                           .Single(e => e.FaceMaskId == faceMaskId && e.OwnerId == _userId);

                ctx.FaceMasks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
