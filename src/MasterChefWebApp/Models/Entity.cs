using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChefWebApp.Models
{
    public class Entity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid? ParentId { get; set; }
        public virtual Type ParentType => null;
    }
}
