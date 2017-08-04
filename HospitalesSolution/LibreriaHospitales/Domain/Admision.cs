using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
   public class Admision
    {
        private int numAdmision;
        private DateTime fecha;
        private int numeroPasiente;
        private int numSala;
        private String nombreHospital;
        private Hospital hospital;

        public Admision(int numAdmision, DateTime fecha, int numeroPasiente, int numSala, String nombreHospital)
        {
            this.numAdmision = numAdmision;
            this.fecha = fecha;
            this.numeroPasiente = numeroPasiente;
            this.NumSala = numSala;
            this.NombreHospital = nombreHospital;

        }
        public Admision()
        {

        }

        public int NumAdmision
        {
            get
            {
                return numAdmision;
            }

            set
            {
                numAdmision = value;
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

        public int NumeroPasiente
        {
            get
            {
                return numeroPasiente;
            }

            set
            {
                numeroPasiente = value;
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

        public int NumSala
        {
            get
            {
                return numSala;
            }

            set
            {
                numSala = value;
            }
        }

        public string NombreHospital
        {
            get
            {
                return nombreHospital;
            }

            set
            {
                nombreHospital = value;
            }
        }

    }
}
