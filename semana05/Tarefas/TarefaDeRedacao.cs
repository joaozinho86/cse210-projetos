using System;

public class TarefaDeRedacao : Tarefa
{
    // Atributo específico da tarefa de redação
    private string _titulo;

    // Construtor que chama o construtor da classe base
    public TarefaDeRedacao(string nomeEstudante, string topico, string titulo)
        : base(nomeEstudante, topico)
    {
        _titulo = titulo;
    }

    // Método para obter as informações da redação
    // Usa a propriedade protegida NomeEstudante da classe base
    public string ObterInformacoesDaRedacao()
    {
        return $"{_titulo}, por {NomeEstudante}";
    }
}