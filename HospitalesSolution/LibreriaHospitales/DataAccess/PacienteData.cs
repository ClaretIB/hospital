using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.DataAccess
{
    public class PacienteData
    {
        private String cadenaConexion;

        public PacienteData(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public PACIENTE Insertar(PACIENTE paciente, String opcion)
        {

            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlTransaction transaccion = null;

            SqlCommand cmdInsertarPaciente = new SqlCommand();
            cmdInsertarPaciente.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarPaciente.CommandText = "CRUDPACIENTE";

            cmdInsertarPaciente.CommandTimeout = 0;
            cmdInsertarPaciente.Connection = conexion;

            //SqlParameter parNumeroP = new SqlParameter("@numero_p", paciente.NumeroP);
            //parNumeroP.Direction = System.Data.ParameterDirection.Output;

            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@numero_p", paciente.NumeroP));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@DNI", paciente.Cedula));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@nombre_ape", paciente.NombreApe));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@direccion", paciente.Direccion));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@telefono", paciente.Telefono));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@compania", paciente.Compania));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@tipo_seguro", paciente.TipoSeguro));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@n_ss", paciente.NumeroSS));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@monto_cobertura", paciente.MontoCobertura));
            cmdInsertarPaciente.Parameters.Add(new SqlParameter("@operacion", opcion));

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();
                cmdInsertarPaciente.Transaction = transaccion;
                cmdInsertarPaciente.ExecuteNonQuery();
                paciente.NumeroP = Int32.Parse(cmdInsertarPaciente.Parameters["@numero_p"].Value.ToString());
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

            // libro.CodLibro = Int32.Parse(cmdInsertarLibro.Parameters["@cod_libro"].ToString());

            return paciente;
        }

        public LinkedList<PACIENTE> GetPacientes()
        {

            //Paso 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdLibro = new SqlCommand("SELECT numero_p, nom_ape, n_ss, telefono, tipo_seguro, DNI, compania, direccion, monto_cobertura_seg FROM PACIENTE", conexion);
            conexion.Open();
            SqlDataReader drLibro = cmdLibro.ExecuteReader();
            LinkedList<PACIENTE> pacientes = new LinkedList<PACIENTE>();

            while (drLibro.Read())
            {
                PACIENTE paciente = new PACIENTE();
                paciente.NumeroP = Int32.Parse(drLibro["numero_p"].ToString());
                paciente.NombreApe = drLibro["nom_ape"].ToString();
                paciente.NumeroSS = Int32.Parse(drLibro["n_ss"].ToString());
                paciente.Telefono = drLibro["telefono"].ToString();
                paciente.TipoSeguro = drLibro["tipo_seguro"].ToString();
                paciente.Cedula = drLibro["DNI"].ToString();
                paciente.Compania = drLibro["compania"].ToString();
                paciente.Direccion = drLibro["direccion"].ToString();
                paciente.MontoCobertura = float.Parse(drLibro["monto_cobertura_seg"].ToString());
                pacientes.AddLast(paciente);
            }//while
            conexion.Close();

            return pacientes;

        }
        public PACIENTE GetPaciente(int numeroP)
        {

            //Paso 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdLibro = new SqlCommand("SELECT numero_p, nom_ape, n_ss, telefono, tipo_seguro, DNI, compania, direccion, monto_cobertura_seg FROM PACIENTE", conexion);
            conexion.Open();
            SqlDataReader drLibro = cmdLibro.ExecuteReader();
            PACIENTE paciente = new PACIENTE();

            while (drLibro.Read())
            {

                int codigo = Int32.Parse(drLibro["numero_p"].ToString());
                if (codigo == numeroP)
                {

                    paciente.NumeroP = Int32.Parse(drLibro["numero_p"].ToString());
                    paciente.NombreApe = drLibro["nom_ape"].ToString();
                    paciente.NumeroSS = Int32.Parse(drLibro["n_ss"].ToString());
                    paciente.Telefono = drLibro["telefono"].ToString();
                    paciente.TipoSeguro = drLibro["tipo_seguro"].ToString();
                    paciente.Cedula = drLibro["DNI"].ToString();
                    paciente.Compania = drLibro["compania"].ToString();
                    paciente.Direccion = drLibro["direccion"].ToString();
                    paciente.MontoCobertura = float.Parse(drLibro["monto_cobertura_seg"].ToString());
                }
            }//while
            conexion.Close();

            return paciente;

        }
    }
}


