using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Models
{
    public class RecipeItem:Entity 
    {
        public virtual string Name { get; set; }
        public virtual float Quantity { get; set; }
        public virtual string MeasurementUnit { get; set; }
        public override Type ParentType => typeof(RecipeStep);
    }
}
