public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos) 
        : base(nome, descricao, pontos) 
    { 
        _concluida = false; // Nunca será concluída
    }

    public override int RegistrarEvento()
    {
        // Sempre retorna os pontos, pois nunca é concluída
        return _pontos;
    }

    public override string ObterDetalhes()
    {
        return $"[ ] {_nome} ({_descricao}) - Meta Eterna";
    }

    public override string Serializar()
    {
        return $"Eterna:{_nome}:{_descricao}:{_pontos}";
    }
}