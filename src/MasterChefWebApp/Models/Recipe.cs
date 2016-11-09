using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Models
{
    public class Recipe: Entity
    {
        public virtual string Name { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime ModifyDate { get; set; }
        public virtual IList<RecipeStep> Steps { get; set; }
    }
}
