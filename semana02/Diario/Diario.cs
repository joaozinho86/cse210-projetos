using System;
using System.Collections.Generic;
using System.IO;

namespace DiarioPessoal
{
    public class Diario
    {
        private List<Registro> registros = new List<Registro>();
        private List<string> perguntas = new List<string>
        {
            "Quem foi a pessoa mais interessante com quem interagi hoje?",
            "Qual foi a melhor parte do meu dia?",
            "Como vi a mão do Senhor em minha vida hoje?",
            "Qual foi a emoção mais forte que senti hoje?",
            "Se eu pudesse fazer uma coisa hoje, o que seria?"
        };

        private Random random = new Random();

        public void NovoRegistro()
        {
            string pergunta = perguntas[random.Next(perguntas.Count)];
            Console.WriteLine(pergunta);
            Console.Write("Sua resposta: ");
            string resposta = Console.ReadLine();
            registros.Add(new Registro(pergunta, resposta));
            Console.WriteLine("Registro adicionado!\n");
        }

        public void ExibirDiario()
        {
            if (registros.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.\n");
                return;
            }

            Console.WriteLine("=== Diário ===");
            foreach (var registro in registros)
            {
                Console.WriteLine(registro);
            }
            Console.WriteLine();
        }

        public void SalvarDiario(string nomeArquivo)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                foreach (var registro in registros)
                {
                    writer.WriteLine($"{registro.Data}|{registro.Pergunta}|{registro.Resposta}");
                }
            }
            Console.WriteLine("Diário salvo!\n");
        }

        public void CarregarDiario(string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
            {
                Console.WriteLine("Arquivo não encontrado.\n");
                return;
            }

            registros.Clear();
            foreach (var linha in File.ReadAllLines(nomeArquivo))
            {
                string[] partes = linha.Split('|');
                if (partes.Length == 3)
                {
                    Registro registro = new Registro(partes[1], partes[2])
                    {
                        Data = partes[0]
                    };
                    registros.Add(registro);
                }
            }
            Console.WriteLine("Diário carregado!\n");
        }
    }
}