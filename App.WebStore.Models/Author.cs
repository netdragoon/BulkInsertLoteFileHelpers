using System.Collections.Generic;
using Castle.ActiveRecord;

namespace App.WebStore.Models
{
    [ActiveRecord(Table = "tbauthor", Lazy = true, Cache = CacheEnum.ReadWrite)]
    public class Author: ActiveRecordBase<Author>
    {
        public Author()
        {
            Books = new List<Book>();
        }

        [PrimaryKey(PrimaryKeyType.Increment, Column = "id")]
        public virtual long Id { get; set; }

        [Property(Column = "name", Length = 60)]
        public virtual string Name { get; set; }
        
        [HasAndBelongsToMany(typeof(Book), Table = "tbauthorbook", ColumnKey = "authorid", ColumnRef = "bookid")]
        public virtual IList<Book> Books { get; set; }
    }
}
