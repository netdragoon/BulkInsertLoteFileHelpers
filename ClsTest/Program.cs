using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App.WebStore.Models;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using NHibernate.Criterion;
//https://github.com/castleproject/ActiveRecord/blob/master/docs/relations-mapping.md#onetoone
namespace ClsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadEntities();

            long a1 = 2;
            Book b1 = Book.Find(a1);

            long a2 = 3;
            Book b2 = Book.Find(a2);

            long a3 = 2;
            Author au = Author.Find(a3);
            Book[] bs = au.Books.ToArray();



            System.Console.WriteLine("Gravado com sucesso !!!");
            System.Console.ReadKey();
        }
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

//People p = new People();
//p.Name = "ALEXADRE LUFEGO";
//p.Address = new Address();
//p.Address.People = p;
//p.Address.City = "PRESIDENTE PRUDENTE";
//p.Address.State = "SP";

//p.Create();
////p.Address.CreateAndFlush();

//long Id = 1;
//People g = People.Find(Id);

//People p1 = People.FindFirst(NHibernate.Criterion.Expression.Where<People>(c => c.PeopleId == 1));
//People p2 = People.FindFirst(NHibernate.Criterion.Expression.Where<People>(c => c.PeopleId == 2));
////p2.Address = new Address()
////{
////    People = p2,
////    PeopleId = p2.PeopleId,
////    City = "PIRAPOZINHO",
////    State = "SP"
////};
////p2.Address.CreateAndFlush();
//People p3 = People.FindFirst(NHibernate.Criterion.Expression.Where<People>(c => c.PeopleId == 3));
