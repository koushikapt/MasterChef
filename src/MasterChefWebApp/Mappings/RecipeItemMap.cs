using FluentNHibernate.Mapping;
using MasterChefWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Mappings
{
    public class RecipeItemMap : ClassMap<RecipeItem>
    {
        public RecipeItemMap()
        {
            Id(x => x.Id, "ItemId");
            Map(x => x.Name);
            Map(x => x.Quantity);
            Map(x => x.MeasurementUnit);
            Map(x => x.ParentId, "RecipeStepId");
            Table("RecipeItems");
        }
    }
}
