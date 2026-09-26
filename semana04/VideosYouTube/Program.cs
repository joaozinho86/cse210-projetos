using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Vídeo 1
        Video video1 = new Video("Aprendendo C#", "João Silva", 600);
        video1.AdicionarComentario(new Comentario("Maria", "Excelente explicação!"));
        video1.AdicionarComentario(new Comentario("Pedro", "Muito claro e direto."));
        video1.AdicionarComentario(new Comentario("Ana", "Ajudou bastante, obrigado!"));
        videos.Add(video1);

        // Vídeo 2
        Video video2 = new Video("Introdução ao .NET", "Carla Souza", 900);
        video2.AdicionarComentario(new Comentario("Lucas", "Conteúdo muito bom!"));
        video2.AdicionarComentario(new Comentario("Fernanda", "Gostei da didática."));
        video2.AdicionarComentario(new Comentario("Rafael", "Ótimo vídeo!"));
        videos.Add(video2);

        // Vídeo 3
        Video video3 = new Video("POO na Prática", "Marcos Lima", 750);
        video3.AdicionarComentario(new Comentario("Beatriz", "Finalmente entendi POO!"));
        video3.AdicionarComentario(new Comentario("Sofia", "Explicação perfeita."));
        video3.AdicionarComentario(new Comentario("Daniel", "Muito bom mesmo."));
        videos.Add(video3);

        // Exibir todos os vídeos e seus comentários
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------");
            video.ExibirInformacoes();
            Console.WriteLine("Comentários:");
            video.ExibirComentarios();
            Console.WriteLine();
        }
    }
}
