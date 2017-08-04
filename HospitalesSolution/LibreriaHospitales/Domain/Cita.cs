using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Cita
    {
        private PACIENTE paciente;
        private DateTime fecha;
        private String hora;
        private Medico medico;
        private Hospital hospital;

        public PACIENTE Paciente
        {
            get
            {
                return paciente;
            }

            set
            {
                paciente = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
            }
        }

        public Medico Medico
        {
            get
            {
                return medico;
            }

            set
            {
                medico = value;
            }
        }

        public Hospital Hospital
        {
            get
            {
                return hospital;
            }

            set
            {
                hospital = value;
            }
        }

        public Cita()
        {

            this.Paciente = new PACIENTE();
            this.Medico = new Medico();
            this.Hospital = new Hospital();

        }
    }
}
