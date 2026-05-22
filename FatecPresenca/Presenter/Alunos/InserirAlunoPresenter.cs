using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca.Presenter.Alunos
{
    internal class InserirAlunoPresenter
    {
        private readonly InserirAlunoView _view;
        private readonly ServicoAluno _servicoAluno;
        private ServicoInserirAluno _turma;

        public InserirAlunoPresenter(InserirAlunoView view)
        {
            _view = view;
            _turma = new ServicoInserirAluno(new List<Aluno>());
            _servicoAluno = new ServicoAluno();

            _view.SelecionarLinha += (_, e) => SelecionarLinha(e);
            _view.InserirAluno += (_, _) => InserirAluno();
            _view.AlterarAluno += (_, _) => AlterarAluno();
            _view.DeletarAluno += (_, _) => DeletarAluno();
            _view.CadastrarAlunos += async (_, _) => await CadastrarAlunos();
            _view.ImportarExcel += (_, _) => ImportarDoExcel();
            _view.LimparCampos += (_, _) => LimparCampos();
            _view.Cancelar += (_, _) => _view.Fechar();
            _view.PesquisarAluno += (_, termo) => _view.FiltrarAlunos(termo);
        }

        private void SelecionarLinha(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var nome = _view.ObterNomeLinha(e.RowIndex);
            var email = _view.ObterEmailLinha(e.RowIndex);

            _turma.aluno = new Aluno(nome, email);
            _view.Nome = nome;
            _view.Email = email;
        }

        private void InserirAluno()
        {
            try
            {
                var nome = _view.Nome.ToUpper();
                var email = _view.Email;

                var aluno = new Aluno(nome, email);
                _turma.adicionarAluno(aluno);

                LimparCampos();

                _view.LimparGrid();
                _turma.getListaAluno().ForEach(al => _view.AdicionarLinha(al.nome, al.email));
            }
            catch (ArgumentException arg)
            {
                _view.MostrarMensagem(arg.Message);
            }
        }

        private void AlterarAluno()
        {
            try
            {
                var nome = _view.Nome.ToUpper();
                var email = _view.Email;

                var aluno = new Aluno(nome, email);

                _turma.alterarAluno(aluno);

                _view.LimparGrid();
                _turma.getListaAluno().ForEach(al => _view.AdicionarLinha(al.nome, al.email));
            }
            catch (ArgumentException arg)
            {
                _view.MostrarMensagem(arg.Message);
            }

        }

        private void DeletarAluno()
        {
            try
            {
                _turma.removerAluno();

                _turma.aluno = null;
                LimparCampos();

                _view.LimparGrid();
                _turma.getListaAluno().ForEach(al => _view.AdicionarLinha(al.nome, al.email));
            }
            catch (ArgumentException arg)
            {
                _view.MostrarMensagem(arg.Message);
            }
        }

        private async Task CadastrarAlunos()
        {
            try
            {
                string dados = await _servicoAluno.CadastrarAlunos(_turma.getListaAluno());
                _view.MostrarMensagem(dados);
                _view.Fechar();
            }
            catch (ArgumentException arg)
            {
                _view.MostrarMensagem(arg.Message);
            }
        }
        
        private void ImportarDoExcel()
        {
            _turma.ImportarAlunosDoExcel();

            _view.LimparGrid();
            _turma.getListaAluno().ForEach(al => _view.AdicionarLinha(al.nome, al.email));
        }

        private void LimparCampos()
        {
            _view.Nome = "";
            _view.Email = "";
        }
    }
}
