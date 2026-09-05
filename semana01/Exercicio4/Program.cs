using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numeros = new List<int>();
        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        while (true)
        {
            Console.Write("Insira o número: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero == 0)
                break;

            numeros.Add(numero);
        }

        // Requisitos básicos
        int soma = numeros.Sum();
        double media = numeros.Average();
        int maior = numeros.Max();

        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");

        // Desafio adicional: menor número positivo
        var positivos = numeros.Where(n => n > 0);
        if (positivos.Any())
        {
            int menorPositivo = positivos.Min();
            Console.WriteLine($"O menor número positivo é: {menorPositivo}");
        }

        // Ordenar lista
        var ordenada = numeros.OrderBy(n => n).ToList();
        Console.WriteLine("A lista reordenada é:");
        foreach (var n in ordenada)
        {
            Console.WriteLine(n);
        }
    }
}
