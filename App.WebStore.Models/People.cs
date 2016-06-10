using Castle.ActiveRecord;

namespace App.WebStore.Models
{
    [ActiveRecord(Table = "tbpeople", Cache = CacheEnum.ReadWrite)]
    public class People: ActiveRecordBase<People>
    {
        [PrimaryKey(PrimaryKeyType.Increment, Column = "peopleid")]
        public virtual long PeopleId { get; set; }

        [Property("name", Length = 60, NotNull = false)]
        public virtual string Name { get; set; }

        [OneToOne(Cascade = CascadeEnum.All)]
        public virtual Address Address { get; set; }
    }
}
