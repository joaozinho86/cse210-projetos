using System;

namespace MonitoramentoExercicios
{
    public class Natacao : Atividade
    {
        private int _voltas;

        public Natacao(DateTime data, int duracaoMinutos, int voltas) 
            : base(data, duracaoMinutos)
        {
            _voltas = voltas;
        }

        public override double ObterDistancia()
        {

            return _voltas * 50.0 / 1000.0;
        }

        public override double ObterVelocidade()
        {

            return (ObterDistancia() / DuracaoMinutos) * 60;
        }

        public override double ObterRitmo()
        {

            return DuracaoMinutos / ObterDistancia();
        }
    }
}