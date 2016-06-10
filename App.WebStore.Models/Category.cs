using System.Collections;
using System.Collections.Generic;
using Castle.ActiveRecord;

namespace App.WebStore.Models
{
    [ActiveRecord(Table = "tbcategory", Cache = CacheEnum.ReadWrite, Lazy = true)]    
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
        public virtual long Id { get; set; }
        
        [Property(Column = "description", Length = 60)]        
        public virtual string Description { get; set; }
                
        [HasMany(typeof(Product), Table = "tbproduct", ColumnKey = "categoryid", Cascade = ManyRelationCascadeEnum.None, Lazy = true)]
        public virtual IList Product { get; set; }
    }
}
