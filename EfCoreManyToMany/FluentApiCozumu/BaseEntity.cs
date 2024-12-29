using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreManyToMany.FluentApiCozumu
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
    }
}
