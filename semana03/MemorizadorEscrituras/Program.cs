using System;

namespace MemorizadorEscrituras
{
    class Program
    {
        static void Main(string[] args)
        {
            Referencia referencia = new Referencia("João", 3, 16);
            string texto = "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito, " +
                           "para que todo aquele que nele crê não pereça, mas tenha a vida eterna.";

            Escritura escritura = new Escritura(referencia, texto);

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