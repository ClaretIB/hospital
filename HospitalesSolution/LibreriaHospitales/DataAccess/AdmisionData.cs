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
    public class AdmisionData
    {
        private String cadenaConexion;
        public AdmisionData(string cadenaConexion)
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
            conexion.Close();
            return listAdmin;
        }

        /*************************************************GET HOSPITALES***************************************************************/
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
            conexion.Close();
            return listHospital;
        }

        /*************************************************GET SALAS POR HOSPITAL***********************************************************/
        public LinkedList<Sala> GetSalasPorHospital(String nombreHopital)
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            
            SqlCommand cmdSala = new SqlCommand("SELECT * FROM SALA ", conexion);
            conexion.Open();
            SqlDataReader drSala = cmdSala.ExecuteReader();
            LinkedList<Sala> listSala = new LinkedList<Sala>();

            while (drSala.Read())
            {
                int numeroSala = Int32.Parse(drSala["num_sala"].ToString());
                String nomHospital = drSala["nombre_h"].ToString();
                String nomEncargado = drSala["nombre_encargado"].ToString();
                int numCamas = Int32.Parse(drSala["num_camas"].ToString());
                String categoria = drSala["categoria_sala"].ToString();

                listSala.AddLast(new Sala(numeroSala));
            }//while
            conexion.Close();

            return listSala;

        }


        /********************************************GET ADMISIONES***************************************************/
        public LinkedList<Admision> GetAdmisiones()
        {
            //PASO 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdSalaa = new SqlCommand("SELECT * FROM ADMISION ", conexion);
            conexion.Open();
            SqlDataReader drSalaa = cmdSalaa.ExecuteReader();

            LinkedList<Admision> listAdmin = new LinkedList<Admision>();
            //recorrer las filas de un DataTable en el DataSet
            while (drSalaa.Read())
            {
                int numAdmin = Int32.Parse(drSalaa["num_admision"].ToString());
                DateTime fecha = DateTime.Parse(drSalaa["fecha"].ToString());
                int numPaciente = Int32.Parse(drSalaa["num_paciente"].ToString());
                String nombreH = drSalaa["nombre_h"].ToString();
                int numSala = Int32.Parse(drSalaa["num_sala"].ToString());

                listAdmin.AddLast(new Admision(numAdmin, fecha, numPaciente, numSala, nombreH));
            }//foreach
            conexion.Close();
            return listAdmin;
        }

        /***********************************************INSERTAR ADMISION**************************************************************/

        public Admision InsertarLibro(Admision admision)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);


            String StoreProcedureAdmin = "InsertarAdmision";
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();

            SqlCommand cmdInsertarAdmision = new SqlCommand(StoreProcedureAdmin, conexion);
            cmdInsertarAdmision.Transaction = transaccion;
            try
            {
                cmdInsertarAdmision.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@num_admision", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmdInsertarAdmision.Parameters.Add(parameter);
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@num_paciente", admision.NumeroPasiente));
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@nombre_h", admision.NombreHospital));
                cmdInsertarAdmision.Parameters.Add(new SqlParameter("@num_sala", admision.NumSala));
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
            return admision;
        }

 /*******************************************BORRAR ADMISION*****************************************************************/
       public void ElimarAdmision(int nunAdmin)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);


            String StoreProcedureDiagE = "EliminaAdmision";
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();

            SqlCommand cmdEliminarAdmision = new SqlCommand(StoreProcedureDiagE, conexion);
            cmdEliminarAdmision.Transaction = transaccion;
            try
            {
                cmdEliminarAdmision.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEliminarAdmision.Parameters.Add(new SqlParameter("@num_admision", nunAdmin));
                cmdEliminarAdmision.ExecuteNonQuery();
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
        }

/********************************************Actualizar Admision*****************************************************/
    
        public void ActualizarAdmision(int numAdmision, int numPaciente, String nombreHospital, int nunSala)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);


            String StoreProcedureDiagAc = "ActualizaAdmision";
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();

            SqlCommand cmdActualizarAdmision = new SqlCommand(StoreProcedureDiagAc, conexion);
            cmdActualizarAdmision.Transaction = transaccion;
            try
            {
                cmdActualizarAdmision.CommandType = System.Data.CommandType.StoredProcedure;
                cmdActualizarAdmision.Parameters.Add(new SqlParameter("@num_admision", numAdmision));
                cmdActualizarAdmision.Parameters.Add(new SqlParameter("@num_paciente", numPaciente));
                cmdActualizarAdmision.Parameters.Add(new SqlParameter("@nombre_h", nombreHospital));
                cmdActualizarAdmision.Parameters.Add(new SqlParameter("@num_sala", nunSala));
                cmdActualizarAdmision.ExecuteNonQuery();
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
        }
    }
}
