using System;
using System.Collections.Generic;

namespace MemorizadorEscrituras
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- Comentário extra para demonstrar criatividade ---
            // Agora o programa trabalha com uma biblioteca de escrituras.
            // A cada execução, uma escritura é escolhida aleatoriamente.
            // Isso ajuda o usuário a memorizar diferentes passagens.
            // ------------------------------------------------------

            // Biblioteca de escrituras
            List<Escritura> biblioteca = new List<Escritura>
            {
                new Escritura(
                    new Referencia("João", 3, 16),
                    "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito, para que todo aquele que nele crê não pereça, mas tenha a vida eterna."
                ),
                new Escritura(
                    new Referencia("Provérbios", 3, 5, 6),
                    "Confia no Senhor de todo o teu coração, e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas."
                ),
                new Escritura(
                    new Referencia("Salmos", 23, 1),
                    "O Senhor é o meu pastor; nada me faltará."
                )
            };

            // Escolhe aleatoriamente uma escritura
            Random random = new Random();
            Escritura escritura = biblioteca[random.Next(biblioteca.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(escritura.ObterTexto());

                if (escritura.EstaCompletamenteOculta())
                {
                    Console.WriteLine("\nTodas as palavras foram escondidas. Programa encerrado.");
                    break;
                }

                Console.WriteLine("\nPressione Enter para continuar ou digite 'sair' para encerrar:");
                string input = Console.ReadLine();

                if (input?.ToLower() == "sair")
                    break;

                escritura.OcultarPalavrasAleatorias(3);
            }
        }
    }
}
