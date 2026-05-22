using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter.Alunos
{
    internal class AlunoUDPresenter
    {
        private readonly AlunoUDView _view;
        private readonly ServicoAluno _service;

        public AlunoUDPresenter(AlunoUDView view)
        {
            _view = view;
            _service = new ServicoAluno();

            _view.CarregarAluno += async (_, _) => await CarregarAluno();
            _view.AlterarAluno += async (_, _) => await AtualizarAluno();
            _view.ExcluirAluno += async (_, _) => await DeletarAluno();
            _view.Cancelar += (_, _) => _view.Fechar();
        }

        private async Task CarregarAluno()
        {
            try
            {
                await _service.carregarAluno(_view.AlunoId);

                _view.Nome = _service._aluno.nome;
                _view.Email = _service._aluno.email;
            }
            catch (ArgumentException arg) {
                _view.ExibirMensagem(arg.Message);
            }
        }

        private async Task AtualizarAluno()
        {
            try
            {
                var result = _view.ConfirmarAcao("ALTERAR ALUNO", "Deseja realmente alterar o aluno");

                if (result == DialogResult.No) return;

                int id = _view.AlunoId;
                string nome = _view.Nome.ToUpper();
                string email = _view.Email;

                _view.ExibirMensagem(await _service.AtualizarAluno(nome, email));
                _view.Fechar();
            }
            catch (ArgumentException arg)
            {
                _view.ExibirMensagem(arg.Message);
            }
        }

        private async Task DeletarAluno()
        {
            try
            {
                var result = _view.ConfirmarAcao("ALUNO: " + _service._aluno.nome, "Deseja realmente deletar o aluno?");

                if (result == DialogResult.No) return;

                _view.ExibirMensagem(await _service.excluirAluno());
                _view.Fechar();
            }
            catch (ArgumentException arg)
            {
                _view.ExibirMensagem(arg.Message);
            }
        }
    }
}
