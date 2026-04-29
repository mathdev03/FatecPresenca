using FatecPresenca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models.Servico
{
    internal class ServicoAluno
    {
        private readonly AlunoBD _aluno;

        public ServicoAluno() { 
            _aluno = new AlunoBD();
        }

        public async Task<Dictionary<int, string>> alunosPorId(IEnumerable<int> id)
        {
            var dados = new Dictionary<int, string>();

            foreach (int i in id) { 
                Aluno aluno = await _aluno.buscarAluno(i);

                dados.Add(i, aluno.getNome());
            }

            return dados;
        }
    }
}
