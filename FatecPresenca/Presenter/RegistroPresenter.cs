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
    internal class RegistroPresenter
    {
        private readonly frmRegistro _view;
        private readonly ServicoRegistro _modelRegistro;
        private readonly ServicoIdentificarAluno _modelAluno;
        private CancellationTokenSource? _cts;

        public RegistroPresenter(frmRegistro view, ServicoRegistro registro, ServicoIdentificarAluno aluno)
        {
            _view = view;
            _modelRegistro = registro;
            _modelAluno = aluno;

            _view.iniciarLeitura += async (_, _) => await initAsync();
            _view.fimLeitura += (_, _) => Cancelar();
        }


        private async Task initAsync()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            MessageBox.Show("Iniciando o registro", "AVISO", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            _view.HabilitarCancelar(true);

            try
            {
                while (true)
                {
                    var aluno = await _modelAluno.identificarAluno(_cts);

                    _cts.Token.ThrowIfCancellationRequested();

                    _modelRegistro.resgitrarPassagem(aluno.getId(), _view.idEvento, TimeOnly.FromDateTime(DateTime.Now));
                }

            }catch (OperationCanceledException)
            {
                MessageBox.Show("Fechando o registro", "AVISO", MessageBoxButtons.OK,
    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancelar() => _cts?.Cancel();


        // TESTE

        //private async void identificacao()
        //{
        //    try
        //    {
        //        Captura captura = new Captura();
        //        TemplateBD bdtemp = new TemplateBD();

        //        var d = bdtemp.carregarTemplates();

        //        if (d == null) return;

        //        var templates = captura.identificar(d);
        //        var alunos = new List<int>();

        //        templates.ForEach(x =>
        //        {
        //            alunos.Add(x.getIdUser());
        //        });

        //        var group = alunos.GroupBy(x => x).ToArray();

        //        var alunoIdent = group.Length == 0 ? null : group.MaxBy(g => g.Count())?.Key;
        //        int id = Convert.ToInt32(alunoIdent);

        //        if (id <= 0) return;

        //        AlunoBD bd = new AlunoBD();

        //        var aluno = await bd.buscarAluno(id);

        //        MessageBox.Show($"Aluno identificado: {aluno.getNome()}");
        //        var servico = new ServicoRegistro();

        //        if (servico.resgitrarPassagem(aluno.getId(), _view.idEvento, TimeOnly.FromDateTime(DateTime.Now)))
        //        {
        //            MessageBox.Show("Aluno registrado!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
