using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Models
{
    public class RecipeStep:Entity
    {
        public virtual int StepNo { get; set; }
        public virtual string Instructions { get; set; }
        public virtual IList<RecipeItem> RecipeItems { get; set; }
        public override Type ParentType => typeof(Recipe);
    }
}
