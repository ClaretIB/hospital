using System;

namespace LibreriaHospitales.Domain
{
    public class Hospital
    {
        private String nombre;
        private String direccion;
        private String fax;
        private int numSalas;

        public Hospital(String nombre, String direccion, String fax, int numSalas)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.fax = fax;
            this.numSalas = numSalas;
        }
        public Hospital()
        {

        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
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

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }

        public int NumSalas
        {
            get
            {
                return numSalas;
            }

            set
            {
                numSalas = value;
            }
        }

       
    }
}