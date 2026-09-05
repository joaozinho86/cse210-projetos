using System;

class Program
{
    static void Main()
    {
        // Pede o nome
        Console.Write("Qual é o seu nome? ");
        string nome = Console.ReadLine();

        // Pede o sobrenome
        Console.Write("Qual é o seu sobrenome? ");
        string sobrenome = Console.ReadLine();

        // Exibe no formato solicitado
        Console.WriteLine($"Seu nome é {sobrenome}, {nome} {sobrenome}.");
    }
}