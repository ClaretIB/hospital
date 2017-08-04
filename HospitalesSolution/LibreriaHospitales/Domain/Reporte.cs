using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Reporte
    {
        private int numeroP;
        private DateTime fecha;
        private String hora;
        private String tipoExamen;
        private String resultado;
        private String diagnostico;
        private String estadoPaciente;
        private int DniMedico;

        public int NumeroP
        {
            get
            {
                return numeroP;
            }

            set
            {
                numeroP = value;
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

        public string TipoExamen
        {
            get
            {
                return tipoExamen;
            }

            set
            {
                tipoExamen = value;
            }
        }

        public string Diagnostico
        {
            get
            {
                return diagnostico;
            }

            set
            {
                diagnostico = value;
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

        public int DniMedico1
        {
            get
            {
                return DniMedico;
            }

            set
            {
                DniMedico = value;
            }
        }

        public Reporte(int numeroP, DateTime fecha, String hora, String tipoExamen, String resultado, String diagnostico, String estadoPaciente,
            int Dni)
        {
            this.NumeroP = numeroP;
            this.Fecha = fecha;
            this.Hora = hora;
            this.TipoExamen = tipoExamen;
            this.resultado = resultado;
            this.Diagnostico = diagnostico;
            this.EstadoPaciente = estadoPaciente;
            this.DniMedico1 = Dni;
        }
        
    }
}
