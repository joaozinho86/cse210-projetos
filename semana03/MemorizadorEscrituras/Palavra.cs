namespace MemorizadorEscrituras
{
    public class Palavra
    {
        private string _texto;
        private bool _estaOculta;

        public Palavra(string texto)
        {
            _texto = texto;
            _estaOculta = false;
        }

        public void Ocultar() => _estaOculta = true;

        public bool EstaOculta() => _estaOculta;

        public string ObterTexto()
        {
            return _estaOculta ? new string('_', _texto.Length) : _texto;
        }
    }
}