using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.DataAccess
{
    public class DiagnosticoData
    {
        private String cadenaConexion;
        public DiagnosticoData(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }
        /***********************************************GET PACIENTES***************************************************************/
        public LinkedList<PACIENTE> GetPacientes()
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdSala = new SqlCommand("SELECT * FROM PACIENTE ", conexion);
            conexion.Open();
            SqlDataReader drSala = cmdSala.ExecuteReader();

            LinkedList<PACIENTE> listAdmin = new LinkedList<PACIENTE>();
            //recorrer las filas de un DataTable en el DataSet
            while (drSala.Read())
            {
                int numPaciente = Int32.Parse(drSala["numero_p"].ToString());
                String dni = drSala["DNI"].ToString();
                String nombre = drSala["nom_ape"].ToString();
                String direccion = drSala["direccion"].ToString();
                String telefono = drSala["telefono"].ToString();
                String compania = drSala["compania"].ToString();
                String tipoSeguro = drSala["tipo_seguro"].ToString();
                int nss = Int32.Parse(drSala["n_ss"].ToString());
                float monto = float.Parse(drSala["monto_cobertura_seg"].ToString());

                listAdmin.AddLast(new PACIENTE(numPaciente, dni, nombre, direccion, telefono, compania, tipoSeguro, nss, monto));
            }//foreach
            return listAdmin;
        }

        /********************************************************GET MEDICOS*****************************************************************/
        public LinkedList<Medico> GetMedicos()
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            SqlCommand cmdSala = new SqlCommand("SELECT * FROM MEDICO ", conexion);
            conexion.Open();
            SqlDataReader drSala = cmdSala.ExecuteReader();
            

            LinkedList<Medico> listMedicos = new LinkedList<Medico>();
            //recorrer las filas de un DataTable en el DataSet
            while (drSala.Read())
            {
                int dniMedico = Int32.Parse(drSala["DNI_m"].ToString());
                String nombre = drSala["nombre"].ToString();
                String nombreH = drSala["nombre_h"].ToString();
                String espe = drSala["especialidad"].ToString();
                DateTime fecha = DateTime.Parse(drSala["fecha_ingreso"].ToString());
                int monto = Int32.Parse(drSala["monto_especialidad"].ToString());
                String estado = drSala["estado"].ToString();

                listMedicos.AddLast(new Medico(dniMedico, nombre, espe, fecha, monto, estado, nombreH));
            }//foreach
            return listMedicos;
        }
        /******************************************************************GET DIAs Y HORAS*************************************************/

        public LinkedList<Hora> GetCitasDisponibles(String fecha, String nombreHopital)
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            SqlCommand cmdSala = new SqlCommand("Select * from horasCitas inner join cita on cita.hora != horasCitas.hora where cita.nombre_h = 'Max Peralta' and cita.fecha = '20160615' ", conexion);
            conexion.Open();
            SqlDataReader drSala = cmdSala.ExecuteReader();

          
            LinkedList<Hora> listHoras = new LinkedList<Hora>();
            //recorrer las filas de un DataTable en el DataSet
            while (drSala.Read())
            {
                String horas = drSala["hora"].ToString();

                listHoras.AddLast(new Hora(horas));
            }//foreach
            return listHoras;
        }
        /***************************************************GET HOSPITALES****************************************************************/
        public LinkedList<Hospital> GetHospitales()
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            SqlCommand cmdSala = new SqlCommand("SELECT * FROM HOSPITAL ", conexion);
            conexion.Open();
            SqlDataReader drSala = cmdSala.ExecuteReader();
            

            LinkedList<Hospital> listHospital = new LinkedList<Hospital>();
            //recorrer las filas de un DataTable en el DataSet
            while (drSala.Read())
            {
                String nombre = drSala["nombre_h"].ToString();
                String direccion = drSala["direccion"].ToString();
                String fax = drSala["fax"].ToString();
                int numSalas = Int32.Parse(drSala["num_salas"].ToString());

                listHospital.AddLast(new Hospital(nombre, direccion, fax, numSalas));
            }//foreach
            return listHospital;
        }
        /******************************************************Insertar Diagnostico ***********************************************************/

        public Diagnostico InsertarDiagnostico(Diagnostico diagnostico)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);


            String StoreProcedureDiag = "InsertarDiagnosticoPaciente";
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();

            SqlCommand cmdInsertarAdmision = new SqlCommand(StoreProcedureDiag, conexion);
            cmdInsertarAdmision.Transaction = transaccion;
            try
            {
                cmdInsertarAdmision.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@numero_p", diagnostico.NumPaciente));
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@DNI_m", diagnostico.DniMedico));
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@fecha_cita", diagnostico.FechaCita));
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@diagnostico", diagnostico.DiagnosticoP));
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@estado_paciente", diagnostico.EstadoPaciente));
                cmdInsertarAdmision.ExecuteNonQuery();
                //libro.CodLibro = Int32.Parse(cmdInsertarLibro.Parameters["@cod_libro"].Value.ToString());
                transaccion.Commit();
            }
            catch (SqlException e)
            {
                transaccion.Rollback();
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return diagnostico;
        }
    }
}
