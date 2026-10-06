public class Retangulo : Figura
{
    private double _lado1;
    private double _lado2;

    public Retangulo(string cor, double lado1, double lado2) : base(cor)
    {
        _lado1 = lado1;
        _lado2 = lado2;
    }

    public override double ObterArea()
    {
        return _lado1 * _lado2;
    }
}