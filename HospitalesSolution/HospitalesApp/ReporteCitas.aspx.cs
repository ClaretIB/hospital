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
    public partial class ReporteCitas : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;
        private PacienteData pacienteData;
        private CitaData citaData;
        LinkedList<PACIENTE> listaPacientes;
        LinkedList<Reporte> reporte;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                pacienteData = new PacienteData(chain);
                

                listaPacientes = pacienteData.GetPacientes();

                ddlPacientes.DataSource = listaPacientes;
                ddlPacientes.DataTextField = "NombreApe";
                ddlPacientes.DataValueField = "NumeroP";
                ddlPacientes.DataBind();

            }
        }

        protected void ddlPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrid(int.Parse(ddlPacientes.SelectedItem.Value));
        }

        private void cargarGrid(int numeroP)
        {
            citaData = new CitaData(chain);
            reporte = citaData.GetReporteCitas(numeroP);

            gvCitas.DataSource = reporte;
            gvCitas.DataBind();

        }
    }
}