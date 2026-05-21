using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FatecPresenca.Models;
using FatecPresenca.Presenter;

namespace FatecPresenca.Presenter
{
    internal interface RelatorioView
    {
        event EventHandler? CarregarEvento;
        event EventHandler<int>? EventoSelecionado;
        event EventHandler<string>? EventoDataSelecionado;
        event EventHandler? ClicarSair;
        event EventHandler<string>? TextoPesquisaAlterado;


        string TotalAluno { set; }
        string TotalAlunoPresente { set; }
        string TotalAlunoAusente { set; }
        int EventoId { get; }

        void obterEventos(List<RelatorioEventoDTO> dto);
        void obterEventosData(List<RelatorioEventoDataDTO> dto);
        void tabelaAlunos(List<RelatorioDTO> dto);
        void FecharForm();
    }
}
