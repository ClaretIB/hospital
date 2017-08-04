using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class PACIENTE
    {
        private int numeroP;
        private String DNI;
        private String cedula;
        private String nombreApe;
        private String direccion;
        private String telefono;
        private String compania;
        private String tipoSeguro;
        private int numeroSS;
        private float montoCobertura;
        private LinkedList<Examen> listaExamenes;

        public PACIENTE(int numeroP, string cedula, string nombreApe, string direccion, string telefono, string compania, string tipoSeguro, int numeroSS, float montoCobertura)
        {
            this.numeroP = numeroP;
            this.Cedula = cedula;
            this.nombreApe = nombreApe;
            this.direccion = direccion;
            this.telefono = telefono;
            this.compania = compania;
            this.tipoSeguro = tipoSeguro;
            this.numeroSS = numeroSS;
            this.montoCobertura = montoCobertura;
        }


        public PACIENTE()
        {
            this.listaExamenes = new LinkedList<Examen>();
        }

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
        public string NombreApe
        {
            get
            {
                return nombreApe;
            }

            set
            {
                nombreApe = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Compania
        {
            get
            {
                return compania;
            }

            set
            {
                compania = value;
            }
        }

        public string TipoSeguro
        {
            get
            {
                return tipoSeguro;
            }

            set
            {
                tipoSeguro = value;
            }
        }

        public int NumeroSS
        {
            get
            {
                return numeroSS;
            }

            set
            {
                numeroSS = value;
            }
        }

        public float MontoCobertura
        {
            get
            {
                return montoCobertura;
            }

            set
            {
                montoCobertura = value;
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }

        public LinkedList<Examen> ListaExamenes
        {
            get
            {
                return listaExamenes;
            }

            set
            {
                listaExamenes = value;
            }
        }


    }
}

