using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca
{
    public partial class frmRegistro : Form
    {
        bool ligado = true;
        int idEvento = 0;

        public frmRegistro(int idEvento)
        {
            InitializeComponent();
            this.idEvento = idEvento;
        }

        //private static int? EncontrarAluno(this IEnumerable<int> alunos)
        //{
        //    if (alunos == null) throw new ArgumentNullException(nameof(alunos));

        //    var groups = alunos.GroupBy(x => x).ToArray();
        //    return groups.Length == 0 ? null : groups.MaxBy(g => g.Count())?.Key;
        //}

        private async void identificarAluno()
        {
            try
            {
                Captura captura = new Captura();
                TemplateBD bdtemp = new TemplateBD();

                var d = bdtemp.carregarTemplates();

                if (d == null) return;

                var templates = captura.identificar(d);
                var alunos = new List<int>();

                templates.ForEach(x =>
                {
                    alunos.Add(x.getIdUser());
                });

                var group = alunos.GroupBy(x => x).ToArray();

                var alunoIdent = group.Length == 0 ? null : group.MaxBy(g => g.Count())?.Key;
                int id = Convert.ToInt32(alunoIdent);

                if (id <= 0) return;

                AlunoBD bd = new AlunoBD();

                var aluno = await bd.buscarAluno(id);

                MessageBox.Show($"Aluno identificado: {aluno.getNome()}");

                var servico = new ServicoRegistro();

                if (servico.resgitrarPassagem(aluno.getId(), idEvento, TimeOnly.FromDateTime(DateTime.Now)))
                {
                    ligado = true;
                    MessageBox.Show("Aluno registrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIniciarIdent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Començando a captura", "AVISO", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            tmrCaptura.Start();
        }

        private void btnPararIdent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Parando a captura", "AVISO", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            tmrCaptura.Stop();
        }

        private void tmrCaptura_Tick(object sender, EventArgs e)
        {

            if (ligado)
            {
                ligado = false;
                identificarAluno();
            }
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
