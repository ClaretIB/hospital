using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.DataAccess
{
    public class MedicoData
    {
        private String cadenaConexion;
        private LinkedList<Medico> listaMedicos;

        public MedicoData(String cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public Medico InsertarMedico(Medico medico)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertarMedico = new SqlCommand();
            cmdInsertarMedico.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarMedico.CommandText = "InsertarMedico";

            cmdInsertarMedico.CommandTimeout = 0;
            cmdInsertarMedico.Connection = conexion;

            cmdInsertarMedico.Parameters.Add(new SqlParameter("@DNI_m", medico.Dni));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@especialidad", medico.Especialidad));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@fecha_ingreso", medico.FechaIngreso));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@monto_especialidad", medico.MontoEspecialidad));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@estado", medico.Estado));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertarMedico.Transaction = transaccion;
                cmdInsertarMedico.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }



            return medico;

        }

        public void EliminarMedico(int DNI)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertarMedico = new SqlCommand();
            cmdInsertarMedico.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarMedico.CommandText = "EliminaMedico";

            cmdInsertarMedico.CommandTimeout = 0;
            cmdInsertarMedico.Connection = conexion;

            cmdInsertarMedico.Parameters.Add(new SqlParameter("@DNI_m", DNI));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertarMedico.Transaction = transaccion;
                cmdInsertarMedico.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        public LinkedList<Medico> GetMedicos()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdMedicos = new SqlCommand("SELECT DNI_m, nombre, especialidad, fecha_ingreso, monto_especialidad, estado, nombre_h from MEDICO ORDER BY DNI_m", conexion);
            conexion.Open();
            SqlDataReader drMedicos = cmdMedicos.ExecuteReader();
            this.listaMedicos = new LinkedList<Medico>();


            while (drMedicos.Read())
            {
                Medico medico = new Medico();
                medico.Dni = Int32.Parse(drMedicos["DNI_m"].ToString());
                medico.Especialidad = drMedicos["especialidad"].ToString();
                medico.FechaIngreso = Convert.ToDateTime(drMedicos["fecha_ingreso"].ToString());
                medico.MontoEspecialidad = Int32.Parse(drMedicos["monto_especialidad"].ToString());
                medico.Estado = drMedicos["estado"].ToString();
                medico.Hospital.Nombre = drMedicos["nombre_h"].ToString();
                medico.Nombre = drMedicos["nombre"].ToString();

                listaMedicos.AddLast(medico);

            }//while    
            conexion.Close();

            return listaMedicos;
        }

        public Medico ActualizarMedico(Medico medico)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertarMedico = new SqlCommand();
            cmdInsertarMedico.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarMedico.CommandText = "ActualizaMedico";

            cmdInsertarMedico.CommandTimeout = 0;
            cmdInsertarMedico.Connection = conexion;

            cmdInsertarMedico.Parameters.Add(new SqlParameter("@DNI_m", medico.Dni));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@especialidad", medico.Especialidad));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@fecha_ingreso", medico.FechaIngreso));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@monto_especialidad", medico.MontoEspecialidad));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@estado", medico.Estado));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertarMedico.Transaction = transaccion;
                cmdInsertarMedico.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }



            return medico;

        }

        public Medico GetMedicoPorDni(int DNI)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdMedicos = new SqlCommand("SELECT DNI_m, especialidad, fecha_ingreso, monto_especialidad, estado from MEDICO where DNI_m="+DNI+"ORDER BY DNI_m", conexion);
            conexion.Open();
            SqlDataReader drMedicos = cmdMedicos.ExecuteReader();
            Medico medico = new Medico();


            while (drMedicos.Read())
            {
                medico.Dni = Int32.Parse(drMedicos["DNI_m"].ToString());
                medico.Especialidad = drMedicos["especialidad"].ToString();
                medico.FechaIngreso = Convert.ToDateTime(drMedicos["fecha_ingreso"].ToString());
                medico.MontoEspecialidad = Int32.Parse(drMedicos["monto_especialidad"].ToString());
                medico.Estado = drMedicos["estado"].ToString();

            }//while    
            conexion.Close();

            return medico;
        }

/**************************************************Remplazo Medico**********************************************************/

        public void reemplazaMedico(int dniMv, int dniMn, String especialidad, int montoEspe, DateTime fechaI, String estado)
        {

            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertarMedico = new SqlCommand();
            cmdInsertarMedico.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarMedico.CommandText = "Proc_Reemplazo_Medico";

            cmdInsertarMedico.CommandTimeout = 0;
            cmdInsertarMedico.Connection = conexion;

            cmdInsertarMedico.Parameters.Add(new SqlParameter("@DNI_m_viejo", dniMv));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@DNI_m", dniMn));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@especialidad", especialidad));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@fecha_ingreso", fechaI));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@monto_especialidad", montoEspe));
            cmdInsertarMedico.Parameters.Add(new SqlParameter("@estado", estado));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertarMedico.Transaction = transaccion;
                cmdInsertarMedico.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }

            

        }
    }
}
