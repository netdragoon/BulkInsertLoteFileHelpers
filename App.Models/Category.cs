using System.Collections;
using System.Collections.Generic;
using Castle.ActiveRecord;

namespace App.Models
{
    [ActiveRecord(Table = "tbcategory", Cache = CacheEnum.ReadWrite)]    
    public class Category: ActiveRecordBase<Category>
    {
        public Category()
        {
            Product = new List<Product>();
        }

        public Category(string description)
        {
            Description = description;
        }

        [PrimaryKey(Generator = PrimaryKeyType.Increment, Column = "id")]
        public long Id { get; set; }
        
        [Property(Column = "description", Length = 60, NotNull = true)]        
        public string Description { get; set; }
                
        [HasMany(typeof(Product), Table = "tbproduct", ColumnKey = "categoryid")]
        public IList Product { get; set; }
    }
}
