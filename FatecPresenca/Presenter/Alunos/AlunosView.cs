using FatecPresenca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Presenter.Alunos
{
    internal interface AlunosView
    {
        event EventHandler CarregarAlunos;
        event EventHandler InserirAluno;
        event EventHandler UDAluno;
        event EventHandler AbrirBiometria;
        event EventHandler FecharForm;
        event EventHandler<string> PesquisarAluno;
        event EventHandler<int> SelecionarAluno;
        event EventHandler MostrarAluno;

        string Nome { set; }
        string Email { set; }
        int LinhaSelecionada { get; }

        void PopularGrid(List<AlunosListDTO> dto);
        string obterIdLinha(int linha);
        void Fechar();
    }
}
