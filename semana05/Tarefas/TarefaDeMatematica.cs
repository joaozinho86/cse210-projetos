using System;

public class TarefaDeMatematica : Tarefa
{
    // Atributos específicos da tarefa de matemática
    private string _capitulo;
    private string _problemas;

    // Construtor que chama o construtor da classe base
    public TarefaDeMatematica(string nomeEstudante, string topico, string capitulo, string problemas)
        : base(nomeEstudante, topico)
    {
        _capitulo = capitulo;
        _problemas = problemas;
    }

    // Método para exibir a lista de tarefas de matemática
    public string ObterListaDeTarefas()
    {
        return $"Capítulo {_capitulo} Problemas {_problemas}";
    }
}