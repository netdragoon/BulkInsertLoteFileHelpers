using CAppBulkAndFileHelpers.Models;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CAppBulkAndFileHelpers
{
    class Program
    {
        static void Main(string[] args)
        {
            Entity2();
        }

        public static void Entity1()
        {
            using (Contexto ctx = new Contexto())
            {

                IList<Produto> produtos = new List<Produto>();

                for (int i = 1; i <= 500000; i++)
                {

                    produtos.Add(Produto.Create($"Description {i}"));

                }

                Stopwatch w = new Stopwatch();

                Console.WriteLine("Prossiga ...");
                Console.WriteLine("");
                Console.ReadKey();

                long init = w.Elapsed.Seconds;
                w.Start();
                ctx.Insert(produtos, new EntityFramework.BulkInsert.Extensions.BulkInsertOptions { EnableStreaming = true });
                w.Stop();
                long end = w.Elapsed.Seconds;

                Console.WriteLine("Tempo inicial: {0}", init);
                Console.WriteLine("Tempo final: {0}", end);
                Console.WriteLine("Tempo decorrido: {0}", end - init);
                Console.WriteLine("");
                Console.WriteLine("Fim ...");
                Console.ReadKey();


            }
        }

        public static void Entity2()
        {
            using (Contexto ctx = new Contexto())
            {
                StreamReader strReader = new StreamReader("./txt/dados.txt");

                FileHelperEngine<Produto> engine = new FileHelperEngine<Produto>();
                Produto[] produtos = engine.ReadStream(strReader);

                Stopwatch w = new Stopwatch();

                Console.WriteLine("Prossiga ...");
                Console.WriteLine("");
                Console.ReadKey();

                long init = w.Elapsed.Seconds;
                w.Start();
                ctx.Insert(produtos, new EntityFramework.BulkInsert.Extensions.BulkInsertOptions { EnableStreaming = true });
                w.Stop();
                long end = w.Elapsed.Seconds;

                Console.WriteLine("Tempo inicial: {0}", init);
                Console.WriteLine("Tempo final: {0}", end);
                Console.WriteLine("Tempo decorrido: {0}", end - init);
                Console.WriteLine("");
                Console.WriteLine("Fim ...");
                Console.ReadKey();


            }
        }
    }
}
