using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Internamiento
    {
        private int numInter;
        private DateTime fecha;
        private PACIENTE paciente;
        private Sala sala;
        private Hospital hospital;

        public int NumInter
        {
            get
            {
                return numInter;
            }

            set
            {
                numInter = value;
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

        internal Sala Sala
        {
            get
            {
                return sala;
            }

            set
            {
                sala = value;
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

        public Internamiento()
        {

        }
    }
}
