using System;

public class Comentario
{
    private string _nomePessoa;
    private string _texto;

    public Comentario(string nomePessoa, string texto)
    {
        _nomePessoa = nomePessoa;
        _texto = texto;
    }

    public void ExibirComentario()
    {
        Console.WriteLine($"- {_nomePessoa}: {_texto}");
    }
}
