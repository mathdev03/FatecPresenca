using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models
{
    internal class JanelaPresenca
    {
        public TimeOnly EntradaInicio { get; }
        public TimeOnly EntradaFim { get; }
        public TimeOnly SaidaInicio { get; }
        public TimeOnly SaidaFim { get; }

        public JanelaPresenca(
            TimeOnly entradaInicio,
            TimeOnly entradaFim,
            TimeOnly saidaInicio,
            TimeOnly saidaFim)
        {
            if (entradaInicio > entradaFim) 
                throw new ArgumentException("Janela de entrada inválida: o início não pode ser após o fim.");

            if (saidaInicio > saidaFim)
                throw new ArgumentException("Janela de saída inválida: o início não pode ser após o fim.");

            EntradaInicio = entradaInicio;
            EntradaFim = entradaFim;
            SaidaInicio = saidaInicio;
            SaidaFim = saidaFim;
        }

        public bool EstaNoHorarioEntrada(TimeOnly agora) => agora >= EntradaInicio && agora <= EntradaFim;
        

        public bool EstaNoHorarioSaida(TimeOnly agora) =>  agora >= SaidaInicio && agora <= SaidaFim;

    }
}
