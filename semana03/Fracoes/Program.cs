class Program
{
    static void Main(string[] args)
    {
        // Usando construtor sem parâmetros
        Fracao f1 = new Fracao();
        Console.WriteLine(f1.ObterFracaoEmTexto());   // 1/1
        Console.WriteLine(f1.ObterFracaoEmDecimal()); // 1

        // Usando construtor com numerador
        Fracao f2 = new Fracao(5);
        Console.WriteLine(f2.ObterFracaoEmTexto());   // 5/1
        Console.WriteLine(f2.ObterFracaoEmDecimal()); // 5

        // Usando construtor com numerador e denominador
        Fracao f3 = new Fracao(3, 4);
        Console.WriteLine(f3.ObterFracaoEmTexto());   // 3/4
        Console.WriteLine(f3.ObterFracaoEmDecimal()); // 0.75

        Fracao f4 = new Fracao(1, 3);
        Console.WriteLine(f4.ObterFracaoEmTexto());   // 1/3
        Console.WriteLine(f4.ObterFracaoEmDecimal()); // 0.333...
    }
}
