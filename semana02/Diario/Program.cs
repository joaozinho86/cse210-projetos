using System;

namespace DiarioPessoal
{
    class Program
    {
        static void Main(string[] args)
        {
            Diario diario = new Diario();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("=== Menu do Diário ===");
                Console.WriteLine("1. Escrever um novo registro");
                Console.WriteLine("2. Exibir o diário");
                Console.WriteLine("3. Salvar o diário em um arquivo");
                Console.WriteLine("4. Carregar o diário de um arquivo");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1": diario.NovoRegistro(); break;
                    case "2": diario.ExibirDiario(); break;
                    case "3":
                        Console.Write("Digite o nome do arquivo: ");
                        diario.SalvarDiario(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Digite o nome do arquivo: ");
                        diario.CarregarDiario(Console.ReadLine());
                        break;
                    case "5": continuar = false; break;
                    default: Console.WriteLine("Opção inválida.\n"); break;
                }
            }
        }
    }
}