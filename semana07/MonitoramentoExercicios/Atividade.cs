using System;

namespace MonitoramentoExercicios
{
    public abstract class Atividade
    {
        private DateTime _data;
        private int _duracaoMinutos;

        public DateTime Data { get { return _data; } }
        public int DuracaoMinutos { get { return _duracaoMinutos; } }

        public Atividade(DateTime data, int duracaoMinutos)
        {
            _data = data;
            _duracaoMinutos = duracaoMinutos;
        }

        public abstract double ObterDistancia();
        public abstract double ObterVelocidade();
        public abstract double ObterRitmo();

        public virtual string ObterResumo()
        {
            return $"{Data:dd MMM yyyy} {this.GetType().Name} ({DuracaoMinutos} min) - " +
                   $"Distância {ObterDistancia():F1} km, " +
                   $"Velocidade {ObterVelocidade():F1} km/h, " +
                   $"Ritmo: {ObterRitmo():F2} min por km";
        }
    }
}