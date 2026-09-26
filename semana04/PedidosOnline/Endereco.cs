using System;
using System.Text;

public class Endereco
{
    private string _rua;
    private string _cidade;
    private string _estado;
    private string _pais;

    public Endereco(string rua, string cidade, string estado, string pais)
    {
        _rua = rua;
        _cidade = cidade;
        _estado = estado;
        _pais = pais;
    }

    public bool EhNosEUA()
    {
        // Comparação simples; assume "USA" ou "United States" como EUA.
        string paisUpper = _pais?.Trim().ToUpperInvariant() ?? string.Empty;
        return paisUpper == "USA" || paisUpper == "UNITED STATES" || paisUpper == "UNITED STATES OF AMERICA";
    }

    public string FormatarEndereco()
    {
        var builder = new StringBuilder();
        builder.AppendLine(_rua);
        builder.AppendLine($"{_cidade}, {_estado}");
        builder.Append(_pais);
        return builder.ToString();
    }

    public string GetRua()
    {
        return _rua;
    }

    public string GetCidade()
    {
        return _cidade;
    }

    public string GetEstado()
    {
        return _estado;
    }

    public string GetPais()
    {
        return _pais;
    }
}
