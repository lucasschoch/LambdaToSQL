using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //SelectSimples();
            //First();
            //FirstOrDefault();
            //Where();
            //Count();
            //Join();
            //JoinUmParaMuitos();
            //OrderBy();
        }

        private static void OrderBy()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var query = ctx.Professores.OrderBy(x => x.Pessoas.PrimeiroNome).Take(5);

                foreach (var item in query)
                {
                    Console.WriteLine("Nome: {0} | Tempo de Mercado: {1}", item.Pessoas.PrimeiroNome, item.TempoMercado);
                }
            }
            Console.ReadLine();
        }

        private static void JoinUmParaMuitos()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var query = ctx.Professores.GroupJoin(ctx.Certificacoes,
                                                      p => p.ID,
                                                      c => c.IdProfessor,
                                                      (professores, cert) => new { Professores = professores, Certificacoes = cert });

                foreach (var item in query)
                {
                    foreach (var subitem in item.Certificacoes)
                    {
                        Console.WriteLine("Certificação: {0} | Primeiro Nome: {1}", subitem.Descricao, item.Professores.Pessoas.PrimeiroNome);
                    }
                }
            }
            Console.ReadLine();
        }

        private static void Join()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var query = ctx.Pessoas.Join(ctx.Alunos,       // Tabela Filha
                                            (pessoas => pessoas.ID),   // ID da tabela Pai
                                            (alunos => alunos.IdPessoa), // ID correspondente na tabela Filha
                                            ((pessoas, alunos) => new { Pessoas = pessoas, Alunos = alunos }));

                foreach (var item in query)
                {
                    Console.WriteLine("Cargo: {0} | Primeiro Nome: {1}", item.Alunos.Cargo, item.Pessoas.PrimeiroNome);
                }
            }
            Console.ReadLine();
        }

        private static void Count()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var count = ctx.Pessoas.Where(x => x.PrimeiroNome == "Lucas").Count();

                Console.Write("Total de Lucas: " + count);
            }
            Console.ReadLine();
        }

        private static void Where()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var selectSimples = ctx.Pessoas.Where(x => x.PrimeiroNome == "Lucas");

                foreach (var item in selectSimples)
                {
                    Console.WriteLine("Primeiro Nome: {0} | Ultimo Nome: {1}", item.PrimeiroNome, item.UltimoNome);
                }
            }
            Console.ReadLine();
        }

        private static void FirstOrDefault()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var firstOrDefault = ctx.Pessoas.FirstOrDefault(x => x.PrimeiroNome == "Lucas");
                if (firstOrDefault != null)
                {
                    Console.WriteLine("Primeiro Nome: {0} | Ultimo Nome: {1}", firstOrDefault.PrimeiroNome, firstOrDefault.UltimoNome);
                }
            }
            Console.ReadLine();
        }

        private static void First()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                try
                {
                    //var first = ctx.Pessoas.First(x => x.PrimeiroNome == "Lucas");
                    var first = ctx.Pessoas.First(x => x.UltimoNome == "Schoch");
                    Console.WriteLine("Primeiro Nome: {0} | Ultimo Nome: {1}", first.PrimeiroNome, first.UltimoNome);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            Console.ReadLine();
        }

        private static void SelectSimples()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var selectSimples = ctx.Pessoas.Select(x => x);

                foreach (var item in selectSimples)
                {
                    Console.WriteLine("Primeiro Nome: {0} | Ultimo Nome: {1}", item.PrimeiroNome, item.UltimoNome);
                }
            }
            Console.ReadLine();
        }
    }
}
