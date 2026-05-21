using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter
{
    public record RelatorioEventoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }

    public record RelatorioEventoDataDTO
    {
        public int Id { get; set; }
        public string data { get; set; } = string.Empty;
    }

    public record RelatorioDTO
    {
        public string NOME { get; set; } = string.Empty;
        public string HORARIOENTRADA { get; set; } = string.Empty;
        public string HORARIOSAIDA { get; set; } = string.Empty;
        public string STATUS { get; set; } = string.Empty;
    }

    internal class RelatorioPresenter
    {
        private readonly RelatorioView _view;
        private readonly EventoBD _eventoBD;
        private readonly RegistroAlunoBD _registroBD;
        private readonly ServicoAluno _servicoAluno;
        private readonly ServicoRegistro _servicoRegistro;
        private Evento _evento;
        private List<RelatorioDTO> _listaRelatorio;

        public RelatorioPresenter(RelatorioView view)
        {
            _view = view;

            _eventoBD = new EventoBD();
            _registroBD = new RegistroAlunoBD();
            _servicoAluno = new ServicoAluno();
            _servicoRegistro = new ServicoRegistro();

            _view.CarregarEvento += (_, _) => carregarEvento();
            _view.ClicarSair += (_, _) => fecharJanela();
            _view.EventoSelecionado += dataEvento;
            _view.EventoDataSelecionado += mostrarDados;
            _view.TextoPesquisaAlterado += pesquisarAluno;
        }

        private void carregarEvento()
        {
            var lista = _eventoBD.carregarEventos();

            if (lista.Count <= 0)
                return;

            var eventoInternos = lista.Select(e => new RelatorioEventoDTO
            {
                Id = e.Id,
                Nome = e.Nome
            }).ToList();

            _view.obterEventos(eventoInternos);
        }

        private void dataEvento(object? obj, int eventoId)
        {
            var listaData = _servicoRegistro.buscarDataPorEvento(eventoId);

            _evento = _eventoBD.buscarEvento(eventoId);

            var mostrarLista = listaData.Select(e => new RelatorioEventoDataDTO
            {
                data = e.Date.ToString("yyyy/MM/dd")
            }).ToList();

            _view.obterEventosData(mostrarLista);
        }

        private async void mostrarDados(object? obj, string data)
        {
            var registro = _registroBD.buscarRegistrosPorEvento(_evento.Id, data);

            var dadosStatus = _servicoRegistro.mostrarStatus(_evento.Id, data);

            if(registro.Count <= 0)
            {
                _view.tabelaAlunos(null);

                _view.TotalAluno = dadosStatus.TotalAlunos.ToString();
                _view.TotalAlunoPresente = dadosStatus.Presentes.ToString();
                _view.TotalAlunoAusente = dadosStatus.Ausente.ToString();
                return;
            }

            var ids = registro.Select(p => p.AlunoId).Distinct().ToList();
            var nomesMap = await _servicoAluno.alunosPorId(ids);

            var lista = registro.Select(e => new RelatorioDTO
            {
                NOME = nomesMap.GetValueOrDefault(e.AlunoId, "Aluno não encontrado"),
                HORARIOENTRADA = e.HorarioEntrada.ToString(),
                HORARIOSAIDA = e.HorarioSaida.ToString(),
                STATUS = e.Status.ToString()
            }).ToList();

            _view.TotalAluno = dadosStatus.TotalAlunos.ToString();
            _view.TotalAlunoPresente = dadosStatus.Presentes.ToString();
            _view.TotalAlunoAusente = dadosStatus.Ausente.ToString();

            _listaRelatorio = lista;
            _view.tabelaAlunos(lista);
        }

        private void pesquisarAluno(object? obj, string texto)
        {
            if (_listaRelatorio == null) return;

            var filtrados = string.IsNullOrWhiteSpace(texto)
                ? _listaRelatorio
                : _listaRelatorio.Where(r => r.NOME.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();

            _view.tabelaAlunos(filtrados);
        }

        private void fecharJanela()
        {
            _view.FecharForm();
        }
    }
}
