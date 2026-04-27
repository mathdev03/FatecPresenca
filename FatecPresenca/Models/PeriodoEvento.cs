using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models
{
    internal class PeriodoEvento
    {
        public DateTime inicio { get; }
        public DateTime fim { get; }
        

        public PeriodoEvento(DateTime inicio, DateTime fim)
        {
            if (inicio == null || fim == null)
                throw new ArgumentNullException("Peridos registro inválidos!");

            if (!(inicio < fim))
                throw new ArgumentNullException($"Inicio do evento deve ser antes do fim. " +
                    $"Inicio:{inicio}, Fim:{fim}");

            this.inicio = inicio;
            this.fim = fim;
        }

        public long getDuracao() {
            TimeSpan duracao = fim - inicio;

            return (long)duracao.TotalHours;
        }

        public bool contemInstante(DateTime momento) {
            return momento >= inicio && momento <= fim;
        }

        public bool sobrepoe(PeriodoEvento outro)
        {
            return inicio < outro.fim && fim > outro.inicio;
        }
    }
}
