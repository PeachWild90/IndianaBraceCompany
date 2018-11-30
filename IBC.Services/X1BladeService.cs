﻿using IBC.data;
using IBC.Data;
using IBC.Models.X1BladeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBC.Services
{
   public class X1BladeService
    {
        private readonly Guid _userId;

        public X1BladeService(Guid userId) //1 i want to make an x1 blade, so you need a guid
        {
            _userId = userId; 
        }

        public bool CreateX1Blade(X1BladeCreate model) //This method creates an INSTANCE of "X1Blade"
        {
            var entity =                        //Entities: corresponds to an object instance, commonly related to database representation of the table, should contain ID Attribute 
                new X1Blade()
                {
                    OwnerId = _userId,
                    Injury = model.Injury,
                    FootSize = model.FootSize,
                    Foot = model.Foot,
                };

            using (var ctx = new ApplicationDbContext()) //saves it to DB
            {
                ctx.X1Blades.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<X1BladeListItem> GetX1Blades() //Allows us to see all X1Blades of a particular user (They have to sign in, member?)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .X1Blades
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new X1BladeListItem
                                {
                                    X1BladeId = e.X1BladeId,
                                    Injury = e.Injury,
                                    FootSize = e.FootSize,
                                    Foot = e.Foot
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
