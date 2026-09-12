using System;

namespace DiarioPessoal
{
    public class Registro
    {
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string Data { get; set; }

        public Registro(string pergunta, string resposta)
        {
            Pergunta = pergunta;
            Resposta = resposta;
            Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        public override string ToString()
        {
            return $"{Data} | Pergunta: {Pergunta} | Resposta: {Resposta}";
        }
    }
}