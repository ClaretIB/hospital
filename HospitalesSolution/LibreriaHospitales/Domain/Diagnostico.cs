using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Diagnostico
    {
        private PACIENTE paciente;
        private int numPaciente;
        private Medico medico;
        private int dniMedico;
        private String estadoPaciente;
        private String diagnosticoP;
        private Cita cita;
        private DateTime fechaCita;

        public Diagnostico(int numPaciente, int dniMedico, String estadoPaciente, String diagnosticoP, DateTime fechaCita)
        {
            this.NumPaciente = numPaciente;
            this.DniMedico = dniMedico;
            this.estadoPaciente = estadoPaciente;
            this.diagnosticoP = diagnosticoP;
            this.FechaCita = fechaCita;
        }

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

        public string EstadoPaciente
        {
            get
            {
                return estadoPaciente;
            }

            set
            {
                estadoPaciente = value;
            }
        }

        public string DiagnosticoP
        {
            get
            {
                return diagnosticoP;
            }

            set
            {
                diagnosticoP = value;
            }
        }

        public Cita Cita
        {
            get
            {
                return cita;
            }

            set
            {
                cita = value;
            }
        }

        public int NumPaciente
        {
            get
            {
                return numPaciente;
            }

            set
            {
                numPaciente = value;
            }
        }

        public int DniMedico
        {
            get
            {
                return dniMedico;
            }

            set
            {
                dniMedico = value;
            }
        }

        public DateTime FechaCita
        {
            get
            {
                return fechaCita;
            }

            set
            {
                fechaCita = value;
            }
        }

        public Diagnostico()
        {

        }

    }
}
