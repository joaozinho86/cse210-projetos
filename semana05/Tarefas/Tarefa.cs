using System;

public class Tarefa
{
    // Atributos como variáveis membro privadas
    private string _nomeEstudante;
    private string _topico;

    // Construtor que recebe nome do estudante e tópico
    public Tarefa(string nomeEstudante, string topico)
    {
        _nomeEstudante = nomeEstudante;
        _topico = topico;
    }

    // Método ObterResumo() para retornar o nome do estudante e o tópico
    public string ObterResumo()
    {
        return $"{_nomeEstudante} - {_topico}";
    }

    // Propriedade protegida para acessar o nome do estudante nas classes derivadas
    protected string NomeEstudante
    {
        get { return _nomeEstudante; }
    }

    // Alternativa: método público para obter o nome do estudante
    public string ObterNomeEstudante()
    {
        return _nomeEstudante;
    }
}