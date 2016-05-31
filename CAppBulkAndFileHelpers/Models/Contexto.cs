using System.Collections.Generic;
using System.Data.Entity;
using EntityFramework.BulkInsert.Extensions;
using System.Data.SqlClient;
using System.Data;

namespace CAppBulkAndFileHelpers.Models
{
    public class Contexto : DbContext
    {
        public Contexto():
            base("ConnStr")
        {
            
        }

        public DbSet<Produto> Produto { get; set; }

        public void Insert<T>(IEnumerable<T> entities, BulkInsertOptions options)
        {
            this.BulkInsert(entities, options);
        }

        public void Insert<T>(IEnumerable<T> entities, int? batchSize = null)
        {
            this.BulkInsert(entities, batchSize);
        }

        public void Insert<T>(IEnumerable<T> entities, SqlBulkCopyOptions options, int? batchSize = null)
        {
            this.BulkInsert(entities, options, batchSize);
        }

        public void Insert<T>(IEnumerable<T> entities, IDbTransaction transaction, SqlBulkCopyOptions options = SqlBulkCopyOptions.Default, int? batchSize = null)
        {
            this.BulkInsert(entities, transaction, options, batchSize);
        }

    }
}
