public class MetaDeListaDeTarefas : Meta
{
    private int _contadorAtual;
    private int _contadorAlvo;
    private int _bonus;

    public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int alvo, int bonus, int atual = 0) 
        : base(nome, descricao, pontos)
    {
        _contadorAlvo = alvo;
        _bonus = bonus;
        _contadorAtual = atual;
        if (_contadorAtual >= _contadorAlvo) _concluida = true;
    }

    public override int RegistrarEvento()
    {
        if (_concluida) return 0;

        _contadorAtual++;
        int pontosGanhos = _pontos;

        if (_contadorAtual >= _contadorAlvo)
        {
            _concluida = true;
            pontosGanhos += _bonus; // Ganha o bônus na última vez
        }

        return pontosGanhos;
    }

    public override string ObterDetalhes()
    {
        string check = _concluida ? "[X]" : "[ ]";
        return $"{check} {_nome} ({_descricao}) -- Concluída {_contadorAtual}/{_contadorAlvo} vezes";
    }

    public override string Serializar()
    {
        return $"Lista:{_nome}:{_descricao}:{_pontos}:{_bonus}:{_contadorAtual}:{_contadorAlvo}";
    }
}