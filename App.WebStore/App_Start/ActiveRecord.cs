using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using System.Collections.Generic;
using System.Reflection;

namespace App.WebStore
{
    public class ActiveRecord
    {
        public static void LoadEntities()
        {
            IConfigurationSource source = GetSource();
            Assembly asm = Assembly.Load(new AssemblyName("App.WebStore.Models"));
            ActiveRecordStarter.Initialize(asm, source);
        }

        public static IConfigurationSource GetSource()
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();

            properties.Add("connection.driver_class", "NHibernate.Driver.MySqlDataDriver");
            properties.Add("dialect", "NHibernate.Dialect.MySQL5Dialect");
            properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            properties.Add("connection.connection_string", "Server=localhost;Database=dbactive;Uid=root;Pwd=senha;");
            properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");

            InPlaceConfigurationSource source = new InPlaceConfigurationSource();

            source.Add(typeof(ActiveRecordBase), properties);

            return source;
        }
    }
}