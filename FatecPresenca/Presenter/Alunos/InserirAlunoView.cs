using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter.Alunos
{
    internal interface InserirAlunoView
    {
        event EventHandler<DataGridViewCellEventArgs>? SelecionarLinha;
        event EventHandler? InserirAluno;
        event EventHandler? AlterarAluno;
        event EventHandler? DeletarAluno;
        event EventHandler? CadastrarAlunos;
        event EventHandler? ImportarExcel;
        event EventHandler? LimparCampos;
        event EventHandler? Cancelar;
        event EventHandler<string>? PesquisarAluno;

        string Nome { get; set; }
        string Email { get; set; }
        int LinhaSelecionada { get; }
        string ObterNomeLinha(int linha);
        string ObterEmailLinha(int linha);


        void LimparGrid();
        void AdicionarLinha(string nome, string email);
        void FiltrarAlunos(string termo);
        void MostrarMensagem(string mensagem);
        void Fechar();
    }
}
