using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using FatecPresenca.Presenca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter

{
    public record EventoDTO
    {
        public int id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }

    public record DashboardDTO
    {
        public string NOME { get; set; } = string.Empty;
        public string STATUS { get; set; } = string.Empty;
    }

    internal class DashboardPresenter
    {
        private readonly DashboardView _view;
        private readonly EventoBD _eventoBD;
        private readonly RegistroAlunoBD _registroBD;
        private readonly ServicoAluno _servicoAluno;
        private readonly ServicoRegistro _servicoRegistro;
        private Evento _evento;

        public DashboardPresenter(DashboardView view)
        {
            _view = view;
            _eventoBD = new EventoBD();
            _registroBD = new RegistroAlunoBD();
            _servicoAluno = new ServicoAluno();
            _servicoRegistro = new ServicoRegistro();
            _evento = null;

            _view.CarregarEvento += (_, _) => CarregarEventos();
            _view.AbrirEventos += (_, _) => AbrirEventos();
            _view.AbrirPresenca += (_, _) => AbrirPresenca();
            _view.abrirRelatorio += (_, _) => abrirRelatorio();
            _view.ClicarRegistrar += (_, _) => AbrirRegistro();
            _view.ClicarSair += (_, _) => _view.FecharForm();
            _view.TickHorario += (_, _) => AtualizarHorarioEStatus();
            _view.EventoSelecionado += CarregarEventoAtual;
        }

        private void CarregarEventos()
        {
            var lista = _eventoBD.carregarEventos();

            if (lista.Count <= 0)
                return;

            lista.ForEach(evento =>
            {
                _servicoRegistro.VerificarAusencia(evento.Id);
            });

            var eventosAtivos = lista.Where(x => x.EstaEmAndamento() && 
                                            !x. EstaFechado()).ToList();

            var eventoInternos = eventosAtivos.Select(e => new EventoDTO
            {
                id = e.Id,
                Nome = e.Nome
            }).ToList();

            _view.ObterEventos(eventoInternos);
        }

        private async void CarregarEventoAtual(object? sender, int eventoid)
        {

            _evento = _eventoBD.buscarEvento(eventoid);

            _view.NomeEvento = _evento.Nome;
            _view.Data = DateTime.Now.ToString("dd/MM/yyyy");
            _view.HorarioInicio = _evento.Periodo.inicio.ToString("HH:mm");
            _view.HorarioFinal = _evento.Periodo.fim.ToString("HH:mm");

            var registro = _registroBD.buscarRegistrosPorEvento(eventoid, DateTime.Now.ToString("yyyy-MM-dd"));

            // Pegar nome dos alunos presente.
            var ids = registro.Select(p => p.AlunoId).Distinct().ToList();
            var nomesMap = await _servicoAluno.alunosPorId(ids);

            var lista = registro.Select(p => new DashboardDTO
            {
                NOME = nomesMap.GetValueOrDefault(p.AlunoId, "Aluno não encontrado"),
                STATUS = p.Status.ToString()
            }).ToList();

            _view.TabelaAlunos(lista);
        }

        private void AtualizarHorarioEStatus()
        {
            _view.HorarioAtual = DateTime.Now.ToString("HH:mm");

            if (_evento == null) return;

            if (!_evento.PodeRegistrar())
            {
                _view.StatusRegistroText = "REGISTRO FECHADO";
                _view.StatusRegistroForeColor = Color.Red;
            }
            else
            {
                _view.StatusRegistroText = "REGISTRO ABERTO";
                _view.StatusRegistroForeColor = Color.Green;
            }
        }

        private void AbrirEventos()
        {
            var frmEventos = new frmEventos();
            frmEventos.ShowDialog();

            CarregarEventos();
        }

        private void AbrirPresenca()
        {
            var frm = new frmAlunos();
            frm.ShowDialog();

            CarregarEventos();
        }

        private void abrirRelatorio()
        {
            var frm = new frmRelatorio();
            frm.ShowDialog();

            CarregarEventos();
        }

        private void AbrirRegistro()
        {
            if (_evento == null)
            {
                _view.MostrarMensagem("Nenhum evento em andamento!");
                return;
            }

            _view.AbrirFormRegistro(_evento.Id);
        }
    }
}
