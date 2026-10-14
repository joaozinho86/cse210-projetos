using System;

namespace MonitoramentoExercicios
{
    public class Ciclismo : Atividade
    {
        private double _velocidadeKmh;

        public Ciclismo(DateTime data, int duracaoMinutos, double velocidadeKmh) 
            : base(data, duracaoMinutos)
        {
            _velocidadeKmh = velocidadeKmh;
        }

        public override double ObterDistancia()
        {
            return (_velocidadeKmh * DuracaoMinutos) / 60;
        }

        public override double ObterVelocidade() => _velocidadeKmh;

        public override double ObterRitmo()
        {

            return 60 / _velocidadeKmh;
        }
    }
}