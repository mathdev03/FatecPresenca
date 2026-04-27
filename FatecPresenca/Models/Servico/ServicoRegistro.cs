using FatecPresenca.DAO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models.Servico
{
    internal class ServicoRegistro
    {
        private readonly RegistroAlunoBD registroBD;
        private readonly AlunoBD alunoBD;
        private readonly EventoBD eventoBD;

        public ServicoRegistro()
        {
            registroBD = new RegistroAlunoBD();
            alunoBD = new AlunoBD();
            eventoBD = new EventoBD();
        }

        public bool resgitrarPassagem(int AlunoId, int EventoId, TimeOnly horario)
        {
            try
            {
                var registro = registroBD.buscarPorAlunoEvento(AlunoId, EventoId);

                // Caso não encontra registro do aluno
                if (registro == null)
                {
                    registro = new RegistroPresenca(AlunoId, EventoId, DateTime.Now.Date);

                    registro.RegistrarEntrada(horario);

                    var evento = eventoBD.buscarEvento(EventoId);
                    registro.ValidarStatus(evento.Janela.EntradaFim);

                    return registroBD.inserir(registro);
                }

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
    }
}
