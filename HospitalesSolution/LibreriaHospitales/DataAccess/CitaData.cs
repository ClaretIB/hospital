using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.DataAccess
{
    public class CitaData
    {
        private String cadenaConexion;
        private LinkedList<Reporte> reporteCitas;

        public CitaData(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public Cita Insertar(Cita cita, String opcion, int pacienteViejo, String horaVieja, String fechaVieja)
        {

            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlCommand cmdInsertarCita = new SqlCommand();
            cmdInsertarCita.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarCita.CommandText = "CRUDCITA";

            cmdInsertarCita.CommandTimeout = 0;
            cmdInsertarCita.Connection = conexion;

            //SqlParameter parNumeroP = new SqlParameter("@numero_p", paciente.NumeroP);
            //parNumeroP.Direction = System.Data.ParameterDirection.Output;

            cmdInsertarCita.Parameters.Add(new SqlParameter("@numero_p", cita.Paciente.NumeroP));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@fecha", cita.Fecha));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@DNI_m", cita.Medico.Dni));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@nombre_h", cita.Hospital.Nombre));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@hora", cita.Hora));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@operacion", opcion));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@pacienteViejo", pacienteViejo));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@horaVieja", horaVieja));
            cmdInsertarCita.Parameters.Add(new SqlParameter("@fechaVieja", fechaVieja));

            // libro.CodLibro = Int32.Parse(cmdInsertarLibro.Parameters["@cod_libro"].ToString());
            conexion.Open();
            cmdInsertarCita.ExecuteNonQuery();
            cita.Paciente.NumeroP = Int32.Parse(cmdInsertarCita.Parameters["@numero_p"].Value.ToString());
            return cita;
        }

        public LinkedList<Cita> GetCitas()
        {

            //Paso 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdCita = new SqlCommand("SELECT * FROM CITA", conexion);
            conexion.Open();
            SqlDataReader drCita = cmdCita.ExecuteReader();
            LinkedList<Cita> citas = new LinkedList<Cita>();

            while (drCita.Read())
            {
                Cita cita = new Cita();
                cita.Paciente.NumeroP = Int32.Parse(drCita["numero_p"].ToString());
                cita.Fecha = Convert.ToDateTime(drCita["fecha"].ToString());
                cita.Medico.Dni = Int32.Parse(drCita["DNI_m"].ToString());
                cita.Hospital.Nombre = drCita["nombre_h"].ToString();
                cita.Hora = drCita["hora"].ToString();
                citas.AddLast(cita);
            }//while
            conexion.Close();

            return citas;

        }
        public Cita GetCita(int numeroP)
        {
            //Paso 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdCita = new SqlCommand("SELECT * FROM CITA", conexion);
            conexion.Open();
            SqlDataReader drCita = cmdCita.ExecuteReader();
            Cita cita = new Cita();

            while (drCita.Read())
            {
                int codigo = Int32.Parse(drCita["numero_p"].ToString());
                if (codigo == numeroP)
                {

                    cita.Paciente.NumeroP = codigo;
                    cita.Fecha = Convert.ToDateTime(drCita["fecha"].ToString());
                    cita.Medico.Dni = Int32.Parse(drCita["DNI_m"].ToString());
                    cita.Hospital.Nombre = drCita["nombre_h"].ToString();
                    cita.Hora = drCita["hora"].ToString();
                }

            }//while
            conexion.Close();

            return cita;
        }

        public LinkedList<Hospital> Gethospitales()
        {

            //Paso 1
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand cmdCita = new SqlCommand("SELECT nombre_h FROM HOSPITAL", conexion);
            conexion.Open();
            SqlDataReader drCita = cmdCita.ExecuteReader();
            LinkedList<Hospital> hospitales = new LinkedList<Hospital>();

            while (drCita.Read())
            {
                Hospital hospi = new Hospital();
                hospi.Nombre = drCita["nombre_h"].ToString();
                hospitales.AddLast(hospi);

            }//while
            conexion.Close();

            return hospitales;

        }

        public LinkedList<Reporte> GetReporteCitas(int numeroP)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            SqlCommand cmdCitas = new SqlCommand();
            SqlCommand cmdGetCitas = new SqlCommand("Select numero_p, fecha, hora, examen, resultado_examen, diagnostico_paciente, estado_paciente, DNI_m from CITAS_PACIENTE", conexion);
            cmdCitas.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCitas.CommandText = "Proc_Reporte_Citas_Paciente";

            cmdCitas.CommandTimeout = 0;
            cmdCitas.Connection = conexion;

            cmdCitas.Parameters.Add(new SqlParameter("@numero_p", numeroP));

            conexion.Open();
            cmdCitas.ExecuteNonQuery();

            SqlDataReader drCitas = cmdGetCitas.ExecuteReader();
            this.reporteCitas = new LinkedList<Reporte>();

            while (drCitas.Read())
            {

                DateTime fecha = Convert.ToDateTime(drCitas["fecha"].ToString());

                reporteCitas.AddLast(new Reporte(int.Parse(drCitas["numero_p"].ToString()),
                                                  fecha, drCitas["hora"].ToString(),
                                                  drCitas["examen"].ToString(),
                                                  drCitas["resultado_examen"].ToString(),
                                                  drCitas["diagnostico_paciente"].ToString(),
                                                  drCitas["estado_paciente"].ToString(),
                                                  Int32.Parse(drCitas["DNI_m"].ToString())));
            }

            conexion.Close();
            conexion.Dispose();

            return reporteCitas;
        }
    }
}

