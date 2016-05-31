using CAppBulkAndFileHelpers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppBulkAndFileHelpers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Contexto ctx = new Contexto())
            {

                IList<Produto> produtos = new List<Produto>();

                for (int i = 1; i <= 500000; i++)
                {

                    produtos.Add(Produto.Create(string.Format("Description {0}", i)));

                }

                Stopwatch w = new Stopwatch();
                
                Console.WriteLine("Prossiga ...");
                Console.WriteLine("");
                Console.ReadKey();

                long Init = w.Elapsed.Seconds;
                w.Start();
                ctx.Insert(produtos, new EntityFramework.BulkInsert.Extensions.BulkInsertOptions() { EnableStreaming = true });
                w.Stop();
                long End = w.Elapsed.Seconds;

                Console.WriteLine("Tempo inicial: {0}", Init);
                Console.WriteLine("Tempo final: {0}", End);
                Console.WriteLine("Tempo decorrido: {0}", End - Init);
                Console.WriteLine("");
                Console.WriteLine("Fim ...");
                Console.ReadKey();


            }   
            
        }
    }
}
