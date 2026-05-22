using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter.Alunos
{
    internal interface AlunoUDView
    {
        event EventHandler CarregarAluno;
        event EventHandler AlterarAluno;
        event EventHandler ExcluirAluno;
        event EventHandler Cancelar;

        int AlunoId { get; }
        string Nome { get; set; }
        string Email { get; set; }
        string Titulo { set; }

        void HabilitarCampos(bool habilitado);
        DialogResult ConfirmarAcao(string titulo, string mensagem);
        void ExibirMensagem(string mensagem);
        void Fechar();
    }
}
