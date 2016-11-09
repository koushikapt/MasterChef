using FluentNHibernate.Mapping;
using MasterChefWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Mappings
{
    public class RecipeMap : ClassMap<Recipe>
    {

        public RecipeMap()
        {
            Id(x => x.Id, "RecipeId");
            Map(x => x.Name);
            Map(x => x.Comments);
            Map(x => x.ModifyDate);
            HasMany(x => x.Steps).KeyColumn("RecipeId").Inverse().Cascade.DeleteOrphan().OrderBy("StepNo Asc");
            Table("Recipes");
        }
    }
}
