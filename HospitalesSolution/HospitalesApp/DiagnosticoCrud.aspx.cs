using LibreriaHospitales.Business;
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
    public partial class DiagnosticoCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                DiagnosticoBusiness diagnosticoBusiness =
                    new DiagnosticoBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);


                LinkedList<PACIENTE> paciente = diagnosticoBusiness.GetPacientes();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (PACIENTE pacienteActual in paciente)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    ddl_paciente.Items.Add(new ListItem(pacienteActual.NumeroP + ""));
                }

                LinkedList<Medico> medico = diagnosticoBusiness.GetMedicos();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (Medico medicoActual in medico)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    ddl_medico.Items.Add(new ListItem(medicoActual.Dni + ""));
                }

                LinkedList<Hospital> HOS = diagnosticoBusiness.GetHospitales();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (Hospital HOSActual in HOS)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    ddl_hospital.Items.Add(new ListItem(HOSActual.Nombre));
                }

                ddl_estado.Items.Add("Recuperado");
                ddl_estado.Items.Add("Urgente");
                ddl_estado.Items.Add("Seguimiento");



            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            DiagnosticoBusiness db = new DiagnosticoBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ToString());

            DateTime fecha = Calendar1.SelectedDate;
            String nombreHospital = ddl_hospital.SelectedItem.Value;
            int dniM = Int32.Parse(ddl_medico.SelectedItem.Value);
            int numPaciente = Int32.Parse(ddl_paciente.SelectedItem.Value);
            String diagn = "a";
            String estad = ddl_estado.SelectedItem.Value;
            // DateTime fecha = DateTime.Today;

            Diagnostico diagnostico = new Diagnostico();
            diagnostico.FechaCita = fecha;
            diagnostico.DniMedico = dniM;
            diagnostico.NumPaciente = numPaciente;
            diagnostico.EstadoPaciente = estad;
            diagnostico.DiagnosticoP = diagn;

            try
            {
                db.InsertarDiagnostico(diagnostico);
                lbl_agregar.Text = "Diagnostico agregada con exito...";
            }
            catch (Exception exp)
            {
                throw exp;
            }




        }

        protected void ddl_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddl_hospital_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl_horas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}