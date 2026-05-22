using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter
{
    public class RegistroDTO
    {
        public string nome { set; get; } = string.Empty;
        public string entrada { get; set; } = string.Empty;
        public string saida { set; get; } = string.Empty;
    }

    internal class RegistroPresenter
    {
        private readonly frmRegistro _view;
        private readonly ServicoRegistro _serviceRegistro;
        private readonly ServicoIdentificarAluno _serviceIdentificarAluno;
        private readonly ServicoAluno _serviceAluno;
        private CancellationTokenSource? _cts;

        public RegistroPresenter(frmRegistro view, ServicoRegistro registro, ServicoIdentificarAluno ident,
            ServicoAluno aluno)
        {
            _view = view;
            _serviceRegistro = registro;
            _serviceIdentificarAluno = ident;
            _serviceAluno = aluno;

            _view.carregarLista += async (_, _) => await carregarLista();
            _view.iniciarLeitura += async (_, _) => await initAsync();
            _view.fimLeitura += (_, _) => Cancelar();
            _view.fecharJanela += (_, _) => FecharJanela();
        }


        private async Task initAsync()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            MessageBox.Show("Iniciando o registro", "AVISO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _view.HabilitarCancelar(true);

            while (true)
            {
                var agora = DateTime.Now;

                try
                {
                    // Identificação
                    var aluno = await _serviceIdentificarAluno.identificarAluno(_cts);

                    // Cancela caso aperte o botão
                    _cts.Token.ThrowIfCancellationRequested();

                    // Registrar aluno
                    bool registro = _serviceRegistro.resgitrarPassagem(aluno.id, _view.idEvento, 
                        TimeOnly.FromDateTime(agora));

                    // Mostrar na tela
                    _view.MostrarNome(aluno.nome);
                    _view.MensagemStatus(true, $"REGISTRO SUCESSO: {agora.ToString("HH:mm:ss")}");

                    // Atualizar a lista
                    await carregarLista();
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Fechando o registro", "AVISO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    _view.MensagemStatus(false, $"REGISTRO FALHA: {agora.ToString("HH:mm:ss")}");
                }
            }
        }

        private void Cancelar() => _cts?.Cancel();

        private async Task carregarLista()
        {
            var presenca = _serviceRegistro.todosRegistros(_view.idEvento);

            // Pegar nome dos alunos presente.
            var ids = presenca.Select(p => p.AlunoId).Distinct().ToList();
            var nomesMap = await _serviceAluno.alunosPorId(ids);

            var lista = presenca.Select(p => new RegistroDTO
            {
                nome = nomesMap.GetValueOrDefault(p.AlunoId, "Aluno não encontrado"),
                entrada = p.HorarioEntrada.ToString(),
                saida = p.HorarioSaida.ToString()
            }).ToList();

            _view.AtualizarTabela(lista);
        }

        private void FecharJanela()
        {
            _cts?.Cancel();
            _view.Close();
        }
    }
}
