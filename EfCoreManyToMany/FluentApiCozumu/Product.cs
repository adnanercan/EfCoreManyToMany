using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreManyToMany.FluentApiCozumu
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public ICollection<CategoryProduct> Categories { get; set; } = new HashSet<CategoryProduct>();
    }
}
