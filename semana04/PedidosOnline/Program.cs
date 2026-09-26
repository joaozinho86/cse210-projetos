using System;

class Program
{
    static void Main(string[] args)
    {
        // Pedido 1 - Cliente nos EUA
        var endereco1 = new Endereco("123 Main St", "Springfield", "IL", "USA");
        var cliente1 = new Cliente("Alice Johnson", endereco1);
        var pedido1 = new Pedido(cliente1);

        var produto1A = new Produto("Caneca", "C001", 12.50m, 2);
        var produto1B = new Produto("Camiseta", "C002", 20.00m, 1);
        pedido1.AdicionarProduto(produto1A);
        pedido1.AdicionarProduto(produto1B);

        // Pedido 2 - Cliente fora dos EUA
        var endereco2 = new Endereco("Av. Libertad 45", "Montevideo", "Montevideo", "Uruguay");
        var cliente2 = new Cliente("Carlos Perez", endereco2);
        var pedido2 = new Pedido(cliente2);

        var produto2A = new Produto("Livro", "L101", 35.75m, 1);
        var produto2B = new Produto("Caderno", "L102", 8.40m, 3);
        var produto2C = new Produto("Caneta", "L103", 1.20m, 5);
        pedido2.AdicionarProduto(produto2A);
        pedido2.AdicionarProduto(produto2B);
        pedido2.AdicionarProduto(produto2C);

        // Exibir resultados para pedido 1
        Console.WriteLine(pedido1.GerarEtiquetaEmbalagem());
        Console.WriteLine(pedido1.GerarEtiquetaEnvio());
        decimal total1 = pedido1.CalcularTotal();
        Console.WriteLine($"Total do Pedido 1: ${total1:F2}");
        Console.WriteLine();

        // Exibir resultados para pedido 2
        Console.WriteLine(pedido2.GerarEtiquetaEmbalagem());
        Console.WriteLine(pedido2.GerarEtiquetaEnvio());
        decimal total2 = pedido2.CalcularTotal();
        Console.WriteLine($"Total do Pedido 2: ${total2:F2}");
    }
}
