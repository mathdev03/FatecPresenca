using FatecPresenca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FatecPresenca.Models.Servico
{
    internal class ServicoIdentificarAluno
    {
        private readonly AlunoBD _aluno;
        private readonly TemplateBD _template;

        public ServicoIdentificarAluno()
        {
            _aluno = new AlunoBD();
            _template = new TemplateBD();
        }

        private async Task<List<int>> identificarDigital(CancellationTokenSource cancelar = default)
        {
            cancelar.Token.ThrowIfCancellationRequested();

            Captura captura = new Captura();

            List<Template> digitaisCapturados = new List<Template>();

            var d = _template.carregarTemplates();

            if (d == null) return null;

            digitaisCapturados = await captura.identificar(d, cancelar);

            cancelar.Token.ThrowIfCancellationRequested();

            //List<Template> templates = await captura.identificar(d);
            var alunos = new List<int>();

            digitaisCapturados.ForEach(x =>
            {
                alunos.Add(x.getIdUser());
            });

            return alunos;
        }


        public async Task<Aluno> identificarAluno(CancellationTokenSource cancelar = default)
        {
            cancelar.Token.ThrowIfCancellationRequested();

            List<int> idAlunos = await identificarDigital(cancelar);

            var group = idAlunos.GroupBy(x => x).ToArray();

            int idAluno = Convert.ToInt32(group.Length == 0 ? null : group.MaxBy(g => g.Count())?.Key);

            if (idAluno <= 0) return null;
            
            return await _aluno.buscarAluno(idAluno);
        }
    }
}
