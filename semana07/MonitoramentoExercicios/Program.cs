using System;
using System.Collections.Generic;

namespace MonitoramentoExercicios
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Atividade> atividades = new List<Atividade>();

            atividades.Add(new Corrida(new DateTime(2022, 11, 3), 30, 4.8));
            atividades.Add(new Ciclismo(new DateTime(2022, 11, 4), 45, 20.5));
            atividades.Add(new Natacao(new DateTime(2022, 11, 5), 40, 60));

            Console.WriteLine("--- Resumo das Atividades ---");
            
            foreach (var atividade in atividades)
            {
                Console.WriteLine(atividade.ObterResumo());
            }
        }
    }
}