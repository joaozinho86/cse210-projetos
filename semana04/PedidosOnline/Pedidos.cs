using System;
using System.Collections.Generic;
using System.Text;

public class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        if (produto != null)
        {
            _produtos.Add(produto);
        }
    }

    public decimal CalcularTotal()
    {
        decimal somaProdutos = 0m;
        foreach (var produto in _produtos)
        {
            somaProdutos += produto.CalcularCustoTotal();
        }

        decimal custoEnvio = _cliente != null && _cliente.MoraNosEUA() ? 5m : 35m;
        return somaProdutos + custoEnvio;
    }

    public string GerarEtiquetaEmbalagem()
    {
        var builder = new StringBuilder();
        builder.AppendLine("=== Etiqueta de Embalagem ===");
        foreach (var produto in _produtos)
        {
            builder.AppendLine($"Produto: {produto.GetNome()}  |  ID: {produto.GetIdProduto()}");
        }

        return builder.ToString();
    }

    public string GerarEtiquetaEnvio()
    {
        var builder = new StringBuilder();
        builder.AppendLine("=== Etiqueta de Envio ===");
        if (_cliente != null)
        {
            builder.AppendLine(_cliente.GetNome());
            if (_cliente.GetEndereco() != null)
            {
                builder.AppendLine(_cliente.GetEndereco().FormatarEndereco());
            }
        }

        return builder.ToString();
    }

    public Cliente GetCliente()
    {
        return _cliente;
    }

    public IReadOnlyList<Produto> GetProdutos()
    {
        return _produtos.AsReadOnly();
    }
}
