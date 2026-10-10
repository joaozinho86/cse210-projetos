public class MetaSimples : Meta
{
    public MetaSimples(string nome, string descricao, int pontos, bool concluida = false) 
        : base(nome, descricao, pontos)
    {
        _concluida = concluida;
    }

    public override int RegistrarEvento()
    {
        if (_concluida) return 0; // Não ganha pontos se já foi concluída
        
        _concluida = true;
        return _pontos;
    }

    public override string ObterDetalhes()
    {
        string check = _concluida ? "[X]" : "[ ]";
        return $"{check} {_nome} ({_descricao})";
    }

    public override string Serializar()
    {
        return $"Simples:{_nome}:{_descricao}:{_pontos}:{_concluida}";
    }
}