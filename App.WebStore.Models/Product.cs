using Castle.ActiveRecord;
namespace App.WebStore.Models
{
    [ActiveRecord(Table = "tbproduct", Cache = CacheEnum.ReadWrite, Lazy = false)]
    public class Product : ActiveRecordBase<Product>
    {
        public Product()
        {
            
        }

        public Product(string description)
        {
            Description = description;
        }

        [PrimaryKey(Generator = PrimaryKeyType.Increment, Column = "id")]
        public virtual long Id { get; set; }

        [Property(Column = "description", Length = 80, NotNull = true)]
        public virtual string Description { get; set; }
        
        [Property(Formula = "categoryid")]
        public virtual long CategoryId { get; set; }

        [BelongsTo("categoryid", Fetch = FetchEnum.Join, Cascade = CascadeEnum.None)]
        public virtual Category Category { get; set; }
    }
}
