namespace WebApp.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public class WebAppEntities : DbContext
    {
        public WebAppEntities()
            : base("name=WebAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<People> People { get; set; }
    }
}
