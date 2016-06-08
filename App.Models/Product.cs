using Castle.ActiveRecord;

namespace App.Models
{
    [ActiveRecord(Table = "tbproduct", Cache = CacheEnum.ReadWrite)]
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
        public long Id { get; set; }

        [Property(Column = "description", Length = 80, NotNull = true)]
        public string Description { get; set; }

        //[Property(Column = "categoryid")]        
        //public long CategoryId { get; set; }

        [BelongsTo("categoryid", Fetch = FetchEnum.Join)]
        public virtual Category Category { get; set; }
    }
}
