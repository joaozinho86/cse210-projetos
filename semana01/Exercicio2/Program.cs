using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite sua nota numérica: ");
        int nota = int.Parse(Console.ReadLine());

        string letra;

        if (nota >= 90)
        {
            letra = "A";
        }
        else if (nota >= 80)
        {
            letra = "B";
        }
        else if (nota >= 70)
        {
            letra = "C";
        }
        else if (nota >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        // Determinar sinal
        string sinal = "";
        int ultimoDigito = nota % 10;

        if (letra != "A" && letra != "F") // evitar A+ e F+/F-
        {
            if (ultimoDigito >= 7)
            {
                sinal = "+";
            }
            else if (ultimoDigito < 3)
            {
                sinal = "-";
            }
        }

        Console.WriteLine($"Sua nota conceitual é: {letra}{sinal}");

        if (nota >= 70)
        {
            Console.WriteLine("Parabéns, você foi aprovado!");
        }
        else
        {
            Console.WriteLine("Não foi desta vez, continue se esforçando!");
        }
    }
}