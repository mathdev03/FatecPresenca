using FatecPresenca.DAO;
using FatecPresenca.Presenter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca.Models.Servico
{

    internal class ServicoRegistro
    {
        private readonly RegistroAlunoBD registroBD;
        private readonly AlunoBD alunoBD;
        private readonly EventoBD eventoBD;
        private readonly ServicoAluno _servicoAluno;

        public record StatusRegistro
        {
            public int TotalAlunos { get; init; }
            public int Presentes { get; init; }

            public int Ausente { get; init; }
        }

        public ServicoRegistro()
        {
            registroBD = new RegistroAlunoBD();
            alunoBD = new AlunoBD();
            eventoBD = new EventoBD();
            _servicoAluno = new ServicoAluno();
        }

        public bool resgitrarPassagem(int AlunoId, int EventoId, TimeOnly horario)
        {
            try
            {
                string data = DateTime.Now.ToString("yyyy-MM-dd");

                var registro = registroBD.buscarPorAlunoEvento(AlunoId, EventoId, data); // Buscar registro
                var evento = eventoBD.buscarEvento(EventoId); // Buscar evento

                // Caso não encontra registro do aluno
                if (registro == null)
                {
                    registro = new RegistroPresenca(AlunoId, EventoId, DateTime.Now.Date);
                    registro.RegistrarEntrada(horario);

                    // Caso não está no evento da saída!
                    if (!evento.Janela.EstaNoHorarioSaida(horario))
                    {
                        registro.ValidarStatus(evento.Janela.EntradaFim); // Validar Atraso!
                    }

                    return registroBD.inserir(registro);
                }

                if (!evento.Janela.EstaNoHorarioSaida(horario)) // Não registra saída sem estar na hora
                    throw new ArgumentException("Não é possível registrar a saída fora de horário!");

                if (registro.Status == StatusPresenca.Ausente) // Verifica se está ausente
                    return true;

                if (!(registro.Status == StatusPresenca.Atrasado)) // Verifica se está atrasado
                    registro.ValidarStatus();

                // Tirar a pendência

                registro.RegistrarSaida(horario);

                return registroBD.atualizar(registro);
            }
            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException invalid)
            {
                MessageBox.Show(invalid.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public void VerificarAusencia(int eventoId) 
        {
            try
            {
                //string data = DateTime.Now.ToString("yyyy-MM-dd");
                var evento = eventoBD.buscarEvento(eventoId);
                if (!evento.EstaFechado())
                    return;

                // Pegando todas as datas!
                List<string> dadosData = new List<string>();

                for (DateTime d = evento.Periodo.inicio.Date; d <= evento.Periodo.fim.Date; d = d.AddDays(1))
                {
                    dadosData.Add(d.ToString("yyyy-MM-dd"));
                }

                // Ausentar aqueles que estão fora de horário!
                dadosData.ForEach(x =>
                {
                    var registros = registroBD.buscarRegistrosPorEvento(eventoId, x);

                    registros.ForEach(x =>
                    {
                        if (x.Status == StatusPresenca.Pendente)
                        {
                            x.AlunoAusente();
                            registroBD.atualizar(x);
                        }
                    });
                });

            }
            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException invalid)
            {
                MessageBox.Show(invalid.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<RegistroPresenca> todosRegistros(int eventoId)
        {

            var registros = registroBD.buscarRegistrosPorEvento(eventoId, DateTime.Now.ToString("yyyy-MM-dd"));

            if(registros.Count == 0)
                MessageBox.Show("Nenhum registro no evento!"); 

            return registros;
        }

        public StatusRegistro mostrarStatus(int eventoId, string data)
        {
            var registros = registroBD.buscarRegistrosPorEvento(eventoId, data);

            if (registros.Count == 0)
            {
                return new StatusRegistro
                {
                    TotalAlunos = 0,
                    Ausente = 0,
                    Presentes = 0
                };
            }

            int totalAlunos = 0;
            int presentes = 0;
            int ausentes = 0;

            foreach (var re in registros)
            {
                totalAlunos++;

                if (re.Status == StatusPresenca.Ausente)
                    ausentes++;
                if(re.Status == StatusPresenca.Presente)
                    presentes++;
            }

            return new StatusRegistro { 
                TotalAlunos = totalAlunos,
                Ausente = ausentes,
                Presentes = presentes
            };
        }

        public List<DateTime> buscarDataPorEvento(int eventoId)
        {
            var evento = eventoBD.buscarEvento(eventoId);

            var dataInicio = evento.Periodo.inicio.Date;
            var dataFim = evento.Periodo.fim.Date;

            var datas = new List<DateTime>();
            for (DateTime data = dataInicio; data <= dataFim; data = data.AddDays(1))
            {
                datas.Add(data);
            }

            return datas;
        } 

        
    }
}
