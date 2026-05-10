using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca.Models
{
    internal class Evento
    {
        public int Id { get; }
        public string Nome { get; }
        public string Descricao { get; }
        public PeriodoEvento Periodo { get; }
        public JanelaPresenca Janela { get; }

        public Evento(
                string nome,
                string descricao,
                PeriodoEvento periodo,
                JanelaPresenca janela,
                int id = 0
            ) {

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("Nome do evento é obrigatório!");

            if (periodo == null)
                throw new ArgumentNullException("Período do evento é obrigatório!");

            if (janela == null)
                throw new ArgumentNullException("Janela de presença é obrigatório!");

            Id = id;
            Nome = nome;
            Descricao = descricao ?? string.Empty;
            Periodo = periodo;
            Janela = janela;
        }

        public bool EstaEmAndamento() => Periodo.contemInstante(DateTime.Now);

        public bool EstaEncerrado() => DateTime.Now > Periodo.fim;

        public bool EstaFechado() => DateTime.Now.TimeOfDay > Periodo.fim.TimeOfDay;

        public bool PodeRegistrar() {
            if (!EstaEmAndamento()) return false;

            var agora = TimeOnly.FromDateTime(DateTime.Now);
            
            return Janela.EstaNoHorarioEntrada(agora) || Janela.EstaNoHorarioSaida(agora);
        }

        public long ObterDuracao() => Periodo.getDuracao();
    }
}
