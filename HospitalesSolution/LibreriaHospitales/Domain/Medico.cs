using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Medico
    {
        private int dni;
        private String nombre;
        private String especialidad;
        private DateTime fechaIngreso;
        private int montoEspecialidad;
        private String estado;
        private String nombreHospital;
        private Hospital hospital;

        public Medico(int Dni, String nombre, String especialidad, DateTime fechaIngreso, int montoEspecialidad, String estado, String nombreHospital)
        {
            this.Dni = Dni;
            this.nombre = nombre;
            this.especialidad = especialidad;
            this.fechaIngreso = fechaIngreso;
            this.montoEspecialidad = montoEspecialidad;
            this.estado = estado;
            this.NombreHospital = nombreHospital;
        }

        public Medico()
        {
            this.Hospital = new Hospital();

        }



        public string Especialidad
        {
            get
            {
                return especialidad;
            }

            set
            {
                especialidad = value;
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return FechaIngreso1;
            }

            set
            {
                FechaIngreso1 = value;
            }
        }

        public DateTime FechaIngreso1
        {
            get
            {
                return fechaIngreso;
            }

            set
            {
                fechaIngreso = value;
            }
        }

        public int MontoEspecialidad
        {
            get
            {
                return montoEspecialidad;
            }

            set
            {
                montoEspecialidad = value;
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

        public int Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }
    }
}
