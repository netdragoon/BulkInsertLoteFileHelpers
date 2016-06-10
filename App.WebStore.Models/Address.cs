using Castle.ActiveRecord;

namespace App.WebStore.Models
{
    [ActiveRecord(Table = "tbaddress", Cache = CacheEnum.ReadWrite)]
    public class Address: ActiveRecordBase<Address>
    {
        [PrimaryKey(PrimaryKeyType.Foreign, Column = "peopleid")]
        public virtual long PeopleId { get; set; }

        [Property("city")]
        public virtual string City { get; set; }

        [Property("state")]
        public virtual string State { get; set; }

        [OneToOne(Cascade = CascadeEnum.All)]
        public virtual People People { get; set; }
    }
}
