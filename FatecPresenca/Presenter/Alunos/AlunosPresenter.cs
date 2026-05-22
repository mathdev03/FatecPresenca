using FatecPresenca.Models.Servico;
using FatecPresenca.Presenca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter.Alunos
{
    public record AlunosListDTO
    {
        public int id { get; set; }
        public string NOME { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty; 
    }

    internal class AlunosPresenter
    {
        private readonly AlunosView _view;
        private readonly ServicoAluno _service;
        private List<AlunosListDTO> _list;


        public AlunosPresenter(AlunosView view)
        {
            _view = view;
            _service = new ServicoAluno();

            _view.CarregarAlunos += async (_, _) => await carregarAlunos();
            _view.InserirAluno += async (_, _) => await inserirAlunos();
            _view.UDAluno += async (_, _) => await UDAluno();
            _view.AbrirBiometria += (_, _) => biometria();
            _view.MostrarAluno += (_, _) => mostrarAluno();

            _view.FecharForm += (_, _) => _view.Fechar();
            _view.PesquisarAluno += pesquisarAluno;
        }

        private async Task carregarAlunos()
        {
            var alunos = await _service.listarAlunos();

            var lista = alunos.Select(a => new AlunosListDTO { 
                id = a.id,
                NOME = a.nome,
                EMAIL = a.email
            }).ToList();


            _list = lista;
            _view.PopularGrid(lista);
        }

        private void mostrarAluno()
        {
            var linha = _view.LinhaSelecionada;
            if (linha == -1) return;

            var id = Convert.ToInt32(_view.obterIdLinha(linha));

            var aluno = _list.FirstOrDefault(a => a.id == id);

            if(aluno == null) return;

            _view.Nome = aluno.NOME;
            _view.Email = aluno.EMAIL;
        }

        private async Task inserirAlunos()
        {
            var janelaCadastro = new frmInserirAluno();

            janelaCadastro.ShowDialog();

            await carregarAlunos();
        }

        private async Task UDAluno()
        {
            var linha = _view.LinhaSelecionada;
            if (linha == -1) return;

            var aluno = Convert.ToInt32(_view.obterIdLinha(linha));

            var janelaUpdateDelete = new frmUDAluno(aluno);
            janelaUpdateDelete.ShowDialog();

            await carregarAlunos();
        }

        private void biometria()
        {
            var linha = _view.LinhaSelecionada;
            if (linha == -1) return;

            var aluno = _view.obterIdLinha(linha);

            var janelaBiometria = new frmBiometria(aluno);
            janelaBiometria.ShowDialog();
        }

        private void pesquisarAluno(object? obj, string texto)
        {
            if (_list == null) return;

            var filtrados = string.IsNullOrWhiteSpace(texto)
                ? _list
                : _list.Where(r => r.NOME.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();

            _view.PopularGrid(filtrados);
        }
    }
}
