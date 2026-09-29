using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Testando a classe base Tarefa ===");
        Tarefa tarefaSimples = new Tarefa("Samuel Silva", "Multiplicação");
        Console.WriteLine(tarefaSimples.ObterResumo());
        Console.WriteLine();

        Console.WriteLine("=== Testando TarefaDeMatematica ===");
        TarefaDeMatematica tarefaMatematica = new TarefaDeMatematica(
            "Roberto Rodriguez",
            "Frações",
            "7.3",
            "8-19"
        );
        Console.WriteLine(tarefaMatematica.ObterResumo());
        Console.WriteLine(tarefaMatematica.ObterListaDeTarefas());
        Console.WriteLine();

        Console.WriteLine("=== Testando TarefaDeRedacao ===");
        TarefaDeRedacao tarefaRedacao = new TarefaDeRedacao(
            "Maria Antunes",
            "História da Europa",
            "As Causas da Segunda Guerra Mundial"
        );
        Console.WriteLine(tarefaRedacao.ObterResumo());
        Console.WriteLine(tarefaRedacao.ObterInformacoesDaRedacao());
    }
}