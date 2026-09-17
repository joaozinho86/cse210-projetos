using System;
using System.Collections.Generic;
using System.Linq;

namespace MemorizadorEscrituras
{
    public class Escritura
    {
        private Referencia _referencia;
        private List<Palavra> _palavras;
        private Random _random = new Random();

        public Escritura(Referencia referencia, string texto)
        {
            _referencia = referencia;
            _palavras = texto.Split(' ').Select(p => new Palavra(p)).ToList();
        }

        public void OcultarPalavrasAleatorias(int numeroParaOcultar)
        {
            var visiveis = _palavras.Where(p => !p.EstaOculta()).ToList();
            for (int i = 0; i < numeroParaOcultar && visiveis.Count > 0; i++)
            {
                int index = _random.Next(visiveis.Count);
                visiveis[index].Ocultar();
                visiveis.RemoveAt(index);
            }
        }

        public string ObterTexto()
        {
            return _referencia.ObterTexto() + "\n" +
                   string.Join(" ", _palavras.Select(p => p.ObterTexto()));
        }

        public bool EstaCompletamenteOculta()
        {
            return _palavras.All(p => p.EstaOculta());
        }
    }
}