using System;

public class Produto
{
    private string _nome;
    private string _idProduto;
    private decimal _precoUnitario;
    private int _quantidade;

    public Produto(string nome, string idProduto, decimal precoUnitario, int quantidade)
    {
        _nome = nome;
        _idProduto = idProduto;
        _precoUnitario = precoUnitario;
        _quantidade = quantidade;
    }

    public string GetNome()
    {
        return _nome;
    }

    public string GetIdProduto()
    {
        return _idProduto;
    }

    public decimal GetPrecoUnitario()
    {
        return _precoUnitario;
    }

    public int GetQuantidade()
    {
        return _quantidade;
    }

    public void SetQuantidade(int quantidade)
    {
        _quantidade = quantidade;
    }

    public decimal CalcularCustoTotal()
    {
        return _precoUnitario * _quantidade;
    }
}
