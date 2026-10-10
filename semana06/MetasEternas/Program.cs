using System;

class Program
{
    static void Main(string[] args)
    {
        // Mensagem inicial informando a mudança
        Console.WriteLine("==================================================================");
        Console.WriteLine(">>> NOVIDADE: Sistema de Níveis (Inicial, Discípulo, Mestre) adicionado! <<<");
        Console.WriteLine("==================================================================\n");

        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();
        string arquivo = "metas.txt";

        // Tenta carregar os dados ao iniciar
        gerenciador.Carregar(arquivo);

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\n--- Menu de Metas Eternas ---");
            // Exibe a pontuação E o nível atual
            Console.WriteLine($"Pontuação atual: {gerenciador.Pontuacao} | Nível: {gerenciador.NivelAtual}");
            Console.WriteLine("1. Criar nova meta");
            Console.WriteLine("2. Listar metas");
            Console.WriteLine("3. Registrar evento (Completar meta)");
            Console.WriteLine("4. Salvar metas");
            Console.WriteLine("5. Carregar metas");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");
            
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarMeta(gerenciador);
                    break;
                case "2":
                    Console.WriteLine("\n--- Lista de Metas ---");
                    gerenciador.ExibirMetas();
                    break;
                case "3":
                    Console.WriteLine("\n--- Registrar Evento ---");
                    gerenciador.ExibirMetas();
                    if (gerenciador.Metas.Count > 0)
                    {
                        Console.Write("Digite o número da meta que você completou: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            gerenciador.RegistrarEvento(index - 1);
                        }
                    }
                    break;
                case "4":
                    gerenciador.Salvar(arquivo);
                    Console.WriteLine("\nMetas salvas com sucesso!");
                    break;
                case "5":
                    gerenciador.Carregar(arquivo);
                    Console.WriteLine("\nMetas carregadas com sucesso!");
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("\nOpção inválida.");
                    break;
            }
        }
    }

    static void CriarMeta(GerenciadorDeMetas gerenciador)
    {
        Console.WriteLine("\nEscolha o tipo de meta:");
        Console.WriteLine("1. Meta Simples");
        Console.WriteLine("2. Meta Eterna");
        Console.WriteLine("3. Meta de Lista de Tarefas");
        Console.Write("Opção: ");
        string tipo = Console.ReadLine();

        Console.Write("Nome da meta: ");
        string nome = Console.ReadLine();
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();
        Console.Write("Pontos por evento: ");
        
        if (!int.TryParse(Console.ReadLine(), out int pontos))
        {
            Console.WriteLine("Valor de pontos inválido.");
            return;
        }

        if (tipo == "1")
        {
            gerenciador.AdicionarMeta(new MetaSimples(nome, descricao, pontos));
            Console.WriteLine("Meta Simples criada!");
        }
        else if (tipo == "2")
        {
            gerenciador.AdicionarMeta(new MetaEterna(nome, descricao, pontos));
            Console.WriteLine("Meta Eterna criada!");
        }
        else if (tipo == "3")
        {
            Console.Write("Quantas vezes para completar? ");
            if (!int.TryParse(Console.ReadLine(), out int alvo)) return;
            Console.Write("Pontos de bônus ao completar: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus)) return;
            
            gerenciador.AdicionarMeta(new MetaDeListaDeTarefas(nome, descricao, pontos, alvo, bonus));
            Console.WriteLine("Meta de Lista de Tarefas criada!");
        }
        else
        {
            Console.WriteLine("Tipo inválido.");
        }
    }
}