using System;

public abstract class Meta
{
    // Encapsulamento: variáveis privadas/protegidas
    protected string _nome;
    protected string _descricao;
    protected int _pontos;
    protected bool _concluida;

    public Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
        _concluida = false;
    }

    // Propriedades públicas para acesso controlado (Encapsulamento)
    public string Nome => _nome;
    public bool Concluida => _concluida;
    public int Pontos => _pontos;

    // Métodos abstratos que serão sobrescritos (Polimorfismo)
    public abstract int RegistrarEvento();
    public abstract string ObterDetalhes();
    public abstract string Serializar();
}