using FluentNHibernate.Mapping;
using MasterChefWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Mappings
{
    public class RecipeStepMap : ClassMap<RecipeStep>
    {
        public RecipeStepMap()
        {
            Id(x => x.Id, "RecipeStepId");
            Map(x => x.ParentId, "RecipeId");
            Map(x => x.StepNo);
            Map(x => x.Instructions);
            HasMany(x => x.RecipeItems).KeyColumn("RecipeStepId").Inverse().Cascade.DeleteOrphan();
            Table("RecipeSteps");
        }
    }
}
