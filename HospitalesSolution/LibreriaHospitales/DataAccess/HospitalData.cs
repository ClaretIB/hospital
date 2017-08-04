using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.DataAccess
{
    public class HospitalData
    {
        private String cadenaConexion;
        private LinkedList<Hospital> listaHospitales;

        public HospitalData(String cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public LinkedList<Hospital> GetHospitales()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdHospitales = new SqlCommand("SELECT nombre_h, direccion, fax, num_salas from HOSPITAL", conexion);
            conexion.Open();
            SqlDataReader drHospitales = cmdHospitales.ExecuteReader();
            this.listaHospitales = new LinkedList<Hospital>();


            while (drHospitales.Read())
            {
                Examen examen = new Examen();
                Hospital hospital = new Hospital();
                hospital.Nombre = drHospitales["nombre_h"].ToString();
                hospital.Direccion = drHospitales["direccion"].ToString();
                hospital.Fax = drHospitales["fax"].ToString();
                hospital.NumSalas = Int32.Parse(drHospitales["num_salas"].ToString());


                listaHospitales.AddLast(hospital);

            }//while    
            conexion.Close();

            return listaHospitales;
        }

    }
}
