using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Presenca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter
{
    internal class DashboardPresenter
    {
        private readonly DashboardView _view;
        private readonly EventoBD _eventoBD;
        private Evento _evento;

        public DashboardPresenter(DashboardView view)
        {
            _view = view;
            _eventoBD = new EventoBD();
            _evento = null;

            _view.CarregarEvento += (_, _) => CarregarEventoAtual();
            _view.AbrirEventos += (_, _) => AbrirEventos();
            _view.AbrirPresenca += (_, _) => AbrirPresenca();
            _view.ClicarRegistrar += (_, _) => AbrirRegistro();
            _view.ClicarSair += (_, _) => _view.FecharForm();
            _view.TickHorario += (_, _) => AtualizarHorarioEStatus();
        }

        private void CarregarEventoAtual()
        {
            var lista = _eventoBD.carregarEventos();

            foreach (var e in lista)
            {
                if (e.EstaEmAndamento())
                {
                    _evento = e;
                    break;
                }
            }

            if (_evento == null) return;

            _view.NomeEvento = _evento.Nome;
            _view.Data = DateTime.Now.ToString("dd/MM/yyyy");
            _view.HorarioInicio = _evento.Periodo.inicio.ToString("HH:mm");
            _view.HorarioFinal = _evento.Periodo.fim.ToString("HH:mm");
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
        }

        private void AbrirPresenca()
        {
            var frm = new frmPresenca();
            frm.ShowDialog();
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
