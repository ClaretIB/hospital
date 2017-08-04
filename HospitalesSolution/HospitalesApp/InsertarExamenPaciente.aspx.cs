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
    public partial class InsertarExamenPaciente : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;
        private ExamenData examenData;
        private PacienteData pacienteData;
        private HospitalData hospitalData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                examenData = new ExamenData(chain);
                pacienteData = new PacienteData(chain);
                hospitalData = new HospitalData(chain);
                LinkedList<Examen> listaExamenes = examenData.GetExamenes();
                LinkedList<PACIENTE> listaPacientes = pacienteData.GetPacientes();
                LinkedList<Hospital> listaHospitales = hospitalData.GetHospitales();

                foreach (Examen examenActual in listaExamenes)
                {
                    lbExamenesAgregar.Items.Add(new ListItem(examenActual.Tipo, examenActual.IdExamen.ToString()));
                }

                ddlPacientes.DataSource = listaPacientes;
                ddlPacientes.DataTextField = "NombreApe";
                ddlPacientes.DataValueField = "NumeroP";
                ddlPacientes.DataBind();

                ddlHospitales.DataSource = listaHospitales;
                ddlHospitales.DataTextField = "Nombre";
                ddlHospitales.DataValueField = "Nombre";
                ddlHospitales.DataBind();
            }
        }

        protected void btnAgregarExamen_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lbExamenesAgregar.Items)
            {
                if (item.Selected)
                {
                    lbExamenesElegidos.Items.Add(item);
                }
            }
        }

        protected void btnAgregarExamenPaciente_Click(object sender, EventArgs e)
        {
            PACIENTE paciente = new PACIENTE();
            examenData = new ExamenData(chain);

            paciente.NumeroP = Int32.Parse(ddlPacientes.SelectedItem.Value);

            foreach (ListItem item in lbExamenesElegidos.Items)
            {
                Examen examen = examenData.GetExamenPorID(Int32.Parse(item.Value));

                examen.Fecha = Convert.ToDateTime(tbFecha.Text);
                examen.Estado = "P";
                examen.Cita.Fecha = Convert.ToDateTime(tbFechaCita.Text);
                examen.Cita.Hospital.Nombre = ddlHospitales.SelectedItem.Value;
                examen.Resultado = null;

                paciente.ListaExamenes.AddLast(examen);
            }

            examenData = new ExamenData(chain);
            examenData.InsertarExamenPaciente(paciente);
        }
    }
}