using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Examen
    {
        private int idExamen;
        private String tipo;
        private int precio;
        private String estado;
        private String resultado;
        private Cita cita;
        private DateTime fecha;

        public Examen()
        {
            this.cita = new Cita();
        }

        public int IdExamen
        {
            get
            {
                return idExamen;
            }

            set
            {
                idExamen = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public int Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Resultado
        {
            get
            {
                return resultado;
            }

            set
            {
                resultado = value;
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
    }
}
