namespace EfCoreManyToMany.FluentApiCozumu
{
    public class Category :BaseEntity
    {

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryProduct> Products { get; set; } = new HashSet<CategoryProduct>();
    }
}