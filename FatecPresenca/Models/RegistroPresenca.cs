using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models
{
    enum StatusPresenca
    {
        Presente,
        Atrasado,
        Ausente,
        Justificado
    }


    internal class RegistroPresenca
    {
        public int Id { get; private set; }
        public int AlunoId { get; private set; }
        public int EventoId { get; private set; }
        public DateTime DataEvento { get; private set; }

        public TimeOnly? HorarioEntrada { get; private set; }
        public TimeOnly? HorarioSaida { get; private set; }
        public int TotalPassagens { get; private set; }

        public StatusPresenca Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        public RegistroPresenca(int alunoId, int eventoId, DateTime eventoData, int id = 0)
        {
            if (alunoId <= 0)
                throw new ArgumentOutOfRangeException("Aluno Inválido!", nameof(alunoId));
            if (eventoId <= 0)
                throw new ArgumentOutOfRangeException("Evento Inválido!", nameof(eventoId));


            this.Id = id;
            AlunoId = alunoId;
            EventoId = eventoId;
            DataEvento = eventoData;
            TotalPassagens = 0;
            Status = StatusPresenca.Ausente;
            DataCriacao = DateTime.Now;
        }

        public void RegistrarEntrada(TimeOnly horario, StatusPresenca status = StatusPresenca.Presente)
        {
            if (HorarioEntrada.HasValue)
                throw new InvalidOperationException("Entrada já registrada para este aluno neste evento");

            HorarioEntrada = horario;
            TotalPassagens++;
            DataAlteracao = DateTime.Now;

            // Status inicial!
            Status = status;
        }

        public void RegistrarSaida(TimeOnly horario)
        {
            if (!HorarioEntrada.HasValue)
                throw new InvalidOperationException("Não é possível registrar saída sem entrada");

            HorarioSaida = horario;
            TotalPassagens++;
            DataAlteracao = DateTime.Now;
        }

        public bool EstaAtrasado(TimeOnly limite)
        {
            if (!HorarioEntrada.HasValue)
                return false;

            return HorarioEntrada.Value > limite;
        }

        public string EstaPendente()
        {
            if (HorarioEntrada.HasValue && !HorarioSaida.HasValue)
                return "Pendente";

            return Status.ToString();
        }

        public void ValidarStatus(TimeOnly limite)
        {
            if (!HorarioEntrada.HasValue)
            {
                Status = StatusPresenca.Ausente;
                return;
            }

            if (EstaAtrasado(limite))
            {
                Status = StatusPresenca.Atrasado;
                return;
            }

            Status = StatusPresenca.Presente;
        }
    }
}
