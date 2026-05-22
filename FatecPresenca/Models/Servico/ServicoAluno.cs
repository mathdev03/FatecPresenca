using FatecPresenca.DAO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca.Models.Servico
{
    internal class ServicoAluno
    {
        private readonly AlunoBD _alunobd;
        public Aluno _aluno;

        public ServicoAluno() { 
            _alunobd = new AlunoBD();
        }

        public async Task<Dictionary<int, string>> alunosPorId(IEnumerable<int> id)
        {
            var dados = new Dictionary<int, string>();

            foreach (int i in id) { 
                Aluno aluno = await _alunobd.buscarAluno(i);

                dados.Add(i, aluno.nome);
            }

            return dados;
        }

        public async Task<List<Aluno>> listarAlunos()
        {
            var alunos = await _alunobd.pegarAlunos();
            if (alunos.Count <= 0)
                throw new ArgumentException("Não há alunos!");

            return alunos;
        }

        public async Task carregarAluno(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id inválido!");

            var aluno = await _alunobd.buscarAluno(id);

            _aluno = aluno;
        }

        public async Task<string> CadastrarAlunos(List<Aluno> alunos)
        {
            // Verificar duplicatas no BD
            alunos = await verificarDuplicatas(alunos);

            if (alunos.Count <= 0)
                throw new ArgumentException("Não é possível cadastrar sem alunos!");

            var dados = await _alunobd.iserirAluno(alunos);
            if (dados == 0)
                throw new ArgumentException("Erro ao inserir no banco!");

            return "Dados inseridos com sucesso!";
        }

        public async Task<string> AtualizarAluno(string nome, string email)
        {
            if (_aluno.nome == nome && _aluno.email == email)
                throw new ArgumentException("Mude os dados de alteração");

            Aluno aluno = new Aluno(nome, email, _aluno.id);

            bool sucesso = await _alunobd.alterarAluno(aluno);

            if (!sucesso)
                throw new ArgumentException("Aluno não Alterado!");

            return "Aluno Alterado com Sucesso!";
        }

        public async Task<string> excluirAluno()
        {
            bool sucesso = await _alunobd.deletarAluno(_aluno.id);

            if (!sucesso)
                throw new ArgumentException("Aluno não Excluido!");

            return "Aluno Excluido com Sucesso!";
        }

        private async Task<List<Aluno>> verificarDuplicatas(List<Aluno> alunos)
        {
            AlunoBD db = new AlunoBD();
            List<Aluno> cadastrados = await db.pegarAlunos();

            if (cadastrados.Count == 0)
                throw new ArgumentException("Não possui dados no bd!");

            List<Aluno> naoCadastrados = alunos
                .Where(al => !cadastrados
                    .Any(db => db.email == al.email))
                .ToList();

            return naoCadastrados;
        }
    }
}
