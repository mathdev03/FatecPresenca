using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatecPresenca.Models;

namespace FatecPresenca.Presenter
{
    internal interface DashboardView
    {
        // Eventos do Form
        event EventHandler CarregarEvento;
        event EventHandler AbrirEventos;
        event EventHandler AbrirPresenca;
        event EventHandler abrirRelatorio;
        event EventHandler ClicarRegistrar;
        event EventHandler ClicarSair;
        event EventHandler TickHorario;
        event EventHandler<int>? EventoSelecionado;

        // Parametros
        string NomeEvento { set; }
        string Data { set; }
        string HorarioInicio { set; }
        string HorarioFinal { set; }
        string HorarioAtual { set; }
        string StatusRegistroText { set; }
        Color StatusRegistroForeColor { set; }
        int EventoId { get; }

        void MostrarMensagem(string mensagem);
        void AbrirFormRegistro(int idEvento);
        void ObterEventos(List<EventoDTO> ev);
        void TabelaAlunos(IEnumerable<DashboardDTO> dto);
        void FecharForm();
    }
}
