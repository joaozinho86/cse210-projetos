using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Testes individuais
        Quadrado quadrado = new Quadrado("Azul", 5);
        Console.WriteLine($"Quadrado -> Cor: {quadrado.ObterCor()}, Área: {quadrado.ObterArea():F2}");

        Retangulo retangulo = new Retangulo("Vermelho", 4, 6);
        Console.WriteLine($"Retângulo -> Cor: {retangulo.ObterCor()}, Área: {retangulo.ObterArea():F2}");

        Circulo circulo = new Circulo("Verde", 3);
        Console.WriteLine($"Círculo -> Cor: {circulo.ObterCor()}, Área: {circulo.ObterArea():F2}");

        // Lista polimórfica de figuras
        List<Figura> figuras = new List<Figura>
        {
            new Quadrado("Azul", 5),
            new Retangulo("Vermelho", 4, 6),
            new Circulo("Verde", 3),
            new Quadrado("Amarelo", 2.5),
            new Retangulo("Roxo", 10, 2),
            new Circulo("Laranja", 1.5)
        };

        Console.WriteLine("\n--- Percorrendo a lista de figuras ---");

        foreach (Figura figura in figuras)
        {
            Console.WriteLine(
                $"{figura.GetType().Name} -> Cor: {figura.ObterCor()}, Área: {figura.ObterArea():F2}"
            );
        }
    }
}