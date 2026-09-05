using System;

class Programa
{
    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        return Console.ReadLine();
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        return int.Parse(Console.ReadLine());
    }

        static int ElevarAoQuadrado(int numero)
    {
        return numero * numero;
    }

        static void ExibirResultado(string nome, int numeroQuadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {numeroQuadrado}");
    }

    static void Main(string[] args)
    {
        ExibirBoasVindas();

        string nome = PerguntarNomeUsuario();
        int numeroFavorito = PerguntarNumeroFavorito();
        int resultado = ElevarAoQuadrado(numeroFavorito);

        ExibirResultado(nome, resultado);
    }
}
