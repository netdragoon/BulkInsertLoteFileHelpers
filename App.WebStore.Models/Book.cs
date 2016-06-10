using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.ActiveRecord;
using NHibernate.Mapping;

namespace App.WebStore.Models
{
    [ActiveRecord(Table = "tbbook", Lazy = true, Cache = CacheEnum.ReadWrite)]
    public class Book: ActiveRecordBase<Book>
    {

        public Book()
        {
           Authors = new List<Author>();
        }

        [PrimaryKey(PrimaryKeyType.Increment, Column = "id")]
        public virtual long Id { get; set; }

        [Property(Column = "title", Length = 60)]
        public virtual string Title { get; set; }

        [HasAndBelongsToMany(typeof(Author), Table = "tbauthorbook", ColumnKey = "bookid", ColumnRef = "authorid")]
        public virtual IList<Author> Authors { get; set; }
    }
}
