using System;

public class Fracao
{
    private int _numerador;
    private int _denominador;

    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    public Fracao(int numeroInteiro)
    {
        _numerador = numeroInteiro;
        _denominador = 1;
    }

    public Fracao(int numerador, int denominador)
    {
        _numerador = numerador;
        _denominador = denominador;
    }

    public string ObterFracaoEmTexto()
    {
        string texto = $"{_numerador}/{_denominador}";
        return texto;
    }

    public double ObterFracaoEmDecimal()
    {
        return (double)_numerador / (double)_denominador;
    }
}