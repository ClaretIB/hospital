using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.DataAccess
{
    public class ExamenData
    {
        private String cadenaConexion;
        private LinkedList<Examen> listaExamenes;

        public ExamenData(String cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public void InsertaExamen(Examen examen){
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertExamen = new SqlCommand();
            cmdInsertExamen.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertExamen.CommandText = "InsertarExamen";

            cmdInsertExamen.CommandTimeout = 0;
            cmdInsertExamen.Connection = conexion;

            cmdInsertExamen.Parameters.Add(new SqlParameter("@id_examen", examen.IdExamen));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@tipo", examen.Tipo));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@precio", examen.Precio));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertExamen.Transaction = transaccion;
                cmdInsertExamen.ExecuteNonQuery();
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

        public void EliminaExamen(int idExamen)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertExamen = new SqlCommand();
            cmdInsertExamen.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertExamen.CommandText = "EliminaExamen";

            cmdInsertExamen.CommandTimeout = 0;
            cmdInsertExamen.Connection = conexion;

            cmdInsertExamen.Parameters.Add(new SqlParameter("@id_examen", idExamen));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertExamen.Transaction = transaccion;
                cmdInsertExamen.ExecuteNonQuery();
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

        public void ModificaExamen(Examen examen)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertExamen = new SqlCommand();
            cmdInsertExamen.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertExamen.CommandText = "ActualizaExamen";

            cmdInsertExamen.CommandTimeout = 0;
            cmdInsertExamen.Connection = conexion;

            cmdInsertExamen.Parameters.Add(new SqlParameter("@id_examen", examen.IdExamen));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@tipo", examen.Tipo));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@precio", examen.Precio));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertExamen.Transaction = transaccion;
                cmdInsertExamen.ExecuteNonQuery();
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

        public LinkedList<Examen> GetExamenes()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdExamenes = new SqlCommand("SELECT id_examen, tipo, precio from EXAMEN ORDER BY id_examen", conexion);
            conexion.Open();
            SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
            this.listaExamenes = new LinkedList<Examen>();


            while (drExamenes.Read())
            {
                Examen examen = new Examen();
                examen.IdExamen = Int32.Parse(drExamenes["id_examen"].ToString());
                examen.Tipo = drExamenes["tipo"].ToString();
                examen.Precio = Int32.Parse(drExamenes["precio"].ToString());

                listaExamenes.AddLast(examen);

            }//while    
            conexion.Close();

            return listaExamenes;
        }

        public Examen GetExamenPorID(int idExamen)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdExamenes = new SqlCommand("SELECT id_examen, tipo, precio from EXAMEN where id_examen="+idExamen+"ORDER BY id_examen", conexion);
            conexion.Open();
            SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
            Examen examen = new Examen();


            while (drExamenes.Read())
            {
                
                examen.IdExamen = Int32.Parse(drExamenes["id_examen"].ToString());
                examen.Tipo = drExamenes["tipo"].ToString();
                examen.Precio = Int32.Parse(drExamenes["precio"].ToString());


            }//while    
            conexion.Close();

            return examen;
        }

        public Examen GetExamenPacientePorID(int idExamen)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdExamenes = new SqlCommand("SELECT id_examen, fecha, nombre_h, fecha_cita from EXAMEN_PACIENTE where id_examen=" + idExamen + "ORDER BY id_examen", conexion);
            conexion.Open();
            SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
            Examen examen = new Examen();


            while (drExamenes.Read())
            {

                examen.IdExamen = Int32.Parse(drExamenes["id_examen"].ToString());
                examen.Fecha = Convert.ToDateTime(drExamenes["fecha"].ToString());
                examen.Cita.Hospital.Nombre = drExamenes["nombre_h"].ToString();
                examen.Cita.Fecha = Convert.ToDateTime(drExamenes["fecha_cita"].ToString());


            }//while    
            conexion.Close();

            return examen;
        }

        public LinkedList<Examen> GetExamenPorPaciente(int numeroP)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdExamenes = new SqlCommand("SELECT EXAMEN_PACIENTE.id_examen, fecha, EXAMEN.tipo from EXAMEN_PACIENTE, EXAMEN where numero_p=" + numeroP + "AND EXAMEN.id_examen = EXAMEN_PACIENTE.id_examen ORDER BY id_examen", conexion);
            conexion.Open();
            SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
            this.listaExamenes = new LinkedList <Examen>();


            while (drExamenes.Read())
            {
                Examen examen = new Examen();
                examen.IdExamen = Int32.Parse(drExamenes["id_examen"].ToString());
                examen.Tipo = drExamenes["tipo"].ToString();
                examen.Fecha = Convert.ToDateTime(drExamenes["fecha"].ToString());
                
                listaExamenes.AddLast(examen);

            }//while    
            conexion.Close();

            return listaExamenes;
        }

        public void InsertarExamenPaciente(PACIENTE paciente)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertExamen = new SqlCommand();
            cmdInsertExamen.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertExamen.CommandText = "InsertarExamenPaciente";

            cmdInsertExamen.CommandTimeout = 0;
            cmdInsertExamen.Connection = conexion;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertExamen.Transaction = transaccion;

                foreach (Examen examenActual in paciente.ListaExamenes)
                {

                    cmdInsertExamen.Parameters.Clear();
                    cmdInsertExamen.Parameters.Add(new SqlParameter("@numero_p", paciente.NumeroP));
                    cmdInsertExamen.Parameters.Add(new SqlParameter("@id_examen", examenActual.IdExamen));
                    cmdInsertExamen.Parameters.Add(new SqlParameter("@fecha", examenActual.Fecha));
                    cmdInsertExamen.Parameters.Add(new SqlParameter("@nombre_h", examenActual.Cita.Hospital.Nombre));
                    cmdInsertExamen.Parameters.Add(new SqlParameter("@estado", examenActual.Estado));
                    cmdInsertExamen.Parameters.Add(new SqlParameter("@fecha_cita", examenActual.Cita.Fecha));
                    cmdInsertExamen.ExecuteNonQuery();

                }


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

        public void EliminaExamenPaciente(int numeroP, int idExamen, DateTime fecha)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertExamen = new SqlCommand();
            cmdInsertExamen.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertExamen.CommandText = "EliminaExamenPaciente";

            cmdInsertExamen.CommandTimeout = 0;
            cmdInsertExamen.Connection = conexion;

            cmdInsertExamen.Parameters.Add(new SqlParameter("@numero_p", numeroP));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@id_examen", idExamen));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@fecha", fecha));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertExamen.Transaction = transaccion;
                cmdInsertExamen.ExecuteNonQuery();
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

        public void ActualizaExamenPaciente(PACIENTE paciente, Examen examen)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertExamen = new SqlCommand();
            cmdInsertExamen.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertExamen.CommandText = "ActualizarExamenPaciente";

            cmdInsertExamen.CommandTimeout = 0;
            cmdInsertExamen.Connection = conexion;

            cmdInsertExamen.Parameters.Add(new SqlParameter("@numero_p", paciente.NumeroP));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@id_examen", examen.IdExamen));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@fecha", examen.Fecha));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@nombre_h", examen.Cita.Hospital.Nombre));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@estado", examen.Estado));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@fecha_cita", examen.Cita.Fecha));
            cmdInsertExamen.Parameters.Add(new SqlParameter("@resultado", examen.Resultado));


            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertExamen.Transaction = transaccion;
                cmdInsertExamen.ExecuteNonQuery();
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
