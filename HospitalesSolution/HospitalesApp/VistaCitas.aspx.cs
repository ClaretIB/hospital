using LibreriaHospitales.DataAccess;
using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalesApp
{
    public partial class VistaCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            ddlMedicos.Enabled = false; ;
            ddlHoras.Enabled = false;
            tbFecha.Enabled = false;
            ddlMedicos.Items.Clear();
            ddlHoras.Items.Clear();
            tbFecha.Text = "";

            ddlHospitales.Enabled = true;
            CitaData citaData = new CitaData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<Hospital> hospitales = citaData.Gethospitales();
            ddlHospitales.DataSource = hospitales;
            ddlHospitales.DataTextField = "nombre";
            ddlHospitales.DataValueField = "nombre";
            ddlHospitales.DataBind();

            ddlPacientes.Enabled = true;
            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<PACIENTE> pacientes = pacienteData.GetPacientes();
            ddlPacientes.DataSource = pacientes;
            ddlPacientes.DataTextField = "nombreApe";
            ddlPacientes.DataValueField = "numeroP";
            ddlPacientes.DataBind();

            btnAgregar.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ddlMedicos.Items.Clear();
            ddlHoras.Items.Clear();
            tbFecha.Text = "";
            ddlMedicos.Enabled = false; ;
            ddlHoras.Enabled = false;
            tbFecha.Enabled = false;
            ddlPacientes.Enabled = false;

            ddlHospitales.Enabled = true;
            CitaData citaData = new CitaData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<Hospital> hospitales = citaData.Gethospitales();
            ddlHospitales.DataSource = hospitales;
            ddlHospitales.DataTextField = "nombre";
            ddlHospitales.DataValueField = "nombre";
            ddlHospitales.DataBind();

            ddlPacienteViejo.Enabled = false;
            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<PACIENTE> pacientes = pacienteData.GetPacientes();
            ddlPacienteViejo.DataSource = pacientes;
            ddlPacienteViejo.DataTextField = "nombreApe";
            ddlPacienteViejo.DataValueField = "numeroP";
            ddlPacienteViejo.DataBind();

            btnAgregar.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            tbFechaVieja.Enabled = true;
            tbHoraVieja.Enabled = true;
            ddlPacienteViejo.Enabled = true;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ddlMedicos.Items.Clear();
            ddlHoras.Items.Clear();
            tbFecha.Text = "";
            ddlMedicos.Enabled = false; ;
            ddlHoras.Enabled = false;
            tbFecha.Enabled = false;
            ddlPacientes.Enabled = false;
            ddlHospitales.Enabled = false;

            ddlPacienteViejo.Enabled = false;
            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<PACIENTE> pacientes = pacienteData.GetPacientes();
            ddlPacienteViejo.DataSource = pacientes;
            ddlPacienteViejo.DataTextField = "nombreApe";
            ddlPacienteViejo.DataValueField = "numeroP";
            ddlPacienteViejo.DataBind();

            btnAgregar.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = true;
            tbFechaVieja.Enabled = true;
            tbHoraVieja.Enabled = true;
            ddlPacienteViejo.Enabled = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cita cita = new Cita();
            cita.Fecha = Convert.ToDateTime(tbFecha.Text);
            cita.Hora = ddlHoras.SelectedItem.Value;
            cita.Hospital.Nombre = ddlHospitales.SelectedItem.Value;
            cita.Medico.Dni = Int32.Parse(ddlMedicos.SelectedValue);
            cita.Paciente.NumeroP = Int32.Parse(ddlPacientes.SelectedValue);

            CitaData citaData = new CitaData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            citaData.Insertar(cita, "INSERT", 0, "00:00:00", "01/01/2016");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Cita cita = new Cita();
            cita.Fecha = Convert.ToDateTime(tbFecha.Text);
            cita.Hora = ddlHoras.SelectedItem.Value;
            cita.Hospital.Nombre = ddlHospitales.SelectedItem.Value;
            cita.Medico.Dni = Int32.Parse(ddlMedicos.SelectedValue);
            cita.Paciente.NumeroP = Int32.Parse(ddlPacienteViejo.SelectedValue);

            CitaData citaData = new CitaData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            citaData.Insertar(cita, "UPDATE", Int32.Parse(ddlPacienteViejo.SelectedValue), tbHoraVieja.Text, tbFechaVieja.Text);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Cita cita = new Cita();
            cita.Fecha = Convert.ToDateTime(tbFechaVieja.Text);
            cita.Hora = tbHoraVieja.Text;
            cita.Hospital.Nombre = "";
            cita.Medico.Dni = 1;
            cita.Paciente.NumeroP = Int32.Parse(ddlPacienteViejo.SelectedValue);

            CitaData citaData = new CitaData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            citaData.Insertar(cita, "DELETE", 0, "00:00:00", "01/01/2016");

        }

        protected void ddlHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMedicos.Items.Clear();
            ddlHoras.Items.Clear();
            tbFecha.Text = "";
            ddlHoras.Enabled = false;
            tbFecha.Enabled = false;

            MedicoData medicoData = new MedicoData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<Medico> medicos = medicoData.GetMedicos();
            Medico medico = new Medico();

            foreach (Medico medicoActual in medicos)
            {
                if (medicoActual.Hospital.Nombre == ddlHospitales.SelectedItem.Value)
                {
                    ddlMedicos.Items.Add(new ListItem(medicoActual.Nombre, medicoActual.Dni+ ""));
                }
            }

            ddlPacientes.Enabled = true;
            ddlMedicos.Enabled = true;

        }

        protected void ddlPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFecha.Enabled = true;
            ddlHoras.Items.Clear();
            tbFecha.Text = "";
        }

        protected void tbFecha_TextChanged(object sender, EventArgs e)
        {
            ddlHoras.Enabled = true;
            ddlHoras.Items.Clear();
            LinkedList<String> horario = HorarioDisponible(tbFecha.Text, Int32.Parse(ddlMedicos.SelectedItem.Value));

            foreach (String horaActual in horario)
            {
                ddlHoras.Items.Add(new ListItem(horaActual, horaActual));
            }
        }

        protected LinkedList<String> HorarioDisponible(String fecha, int medico)
        {

            CitaData citaData = new CitaData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<Cita> citas = citaData.GetCitas();

            LinkedList<String> horarioComp = new LinkedList<string>();
            horarioComp.AddLast("08:00:00");
            horarioComp.AddLast("08:30:00");
            horarioComp.AddLast("09:00:00");
            horarioComp.AddLast("09:30:00");
            horarioComp.AddLast("10:00:00");
            horarioComp.AddLast("10:30:00");
            horarioComp.AddLast("11:00:00");
            horarioComp.AddLast("11:30:00");
            horarioComp.AddLast("13:00:00");
            horarioComp.AddLast("13:30:00");
            horarioComp.AddLast("14:00:00");
            horarioComp.AddLast("14:30:00");
            horarioComp.AddLast("15:00:00");
            horarioComp.AddLast("15:30:00");

            LinkedList<String> horario = new LinkedList<string>();
            horario.AddLast("08:00:00");
            horario.AddLast("08:30:00");
            horario.AddLast("09:00:00");
            horario.AddLast("09:30:00");
            horario.AddLast("10:00:00");
            horario.AddLast("10:30:00");
            horario.AddLast("11:00:00");
            horario.AddLast("11:30:00");
            horario.AddLast("13:00:00");
            horario.AddLast("13:30:00");
            horario.AddLast("14:00:00");
            horario.AddLast("14:30:00");
            horario.AddLast("15:00:00");
            horario.AddLast("15:30:00");

            foreach (String horaActual in horarioComp)
            {
                foreach (Cita citaActual in citas)
                {
                    if ((fecha == citaActual.Fecha.ToString("yyyy-MM-dd")) && citaActual.Medico.Dni == medico && citaActual.Hora == horaActual)
                    {

                        try
                        {
                            horario.Remove(horaActual);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }

            }

            return horario;
        }
    }
}