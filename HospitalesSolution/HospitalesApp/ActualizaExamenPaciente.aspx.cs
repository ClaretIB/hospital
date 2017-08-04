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
    public partial class ActualizaExamenPaciente : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;
        private ExamenData examenData;
        private PacienteData pacienteData;
        private HospitalData hospitalData;
        LinkedList<Examen> listaExamenes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                examenData = new ExamenData(chain);
                pacienteData = new PacienteData(chain);
                hospitalData = new HospitalData(chain);
                LinkedList<PACIENTE> listaPacientes = pacienteData.GetPacientes();
                ddlPaciente.DataSource = listaPacientes;
                ddlPaciente.DataTextField = "NombreApe";
                ddlPaciente.DataValueField = "NumeroP";
                ddlPaciente.DataBind();

                LinkedList<Examen> listaExamenes = examenData.GetExamenPorPaciente(Int32.Parse(ddlPaciente.SelectedItem.Value));

                ddlExamen.DataSource = listaExamenes;
                ddlExamen.DataTextField = "Tipo";
                ddlExamen.DataValueField = "IdExamen";
                ddlExamen.DataBind();

                Examen examen = examenData.GetExamenPacientePorID(int.Parse(ddlExamen.SelectedItem.Value));

                tbFechaExamen.Text = examen.Fecha.ToString();

                LinkedList<Hospital> listaHospitales = hospitalData.GetHospitales();

               

                //ddlHospitales.DataSource = listaHospitales;
                //ddlHospitales.DataTextField = "Nombre";
                //ddlHospitales.DataValueField = "Nombre";
                //ddlHospitales.DataBind();
            }

        }

        protected void ddlExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            examenData = new ExamenData(chain);
            Examen examen = examenData.GetExamenPacientePorID(int.Parse(ddlExamen.SelectedItem.Value));

            tbFechaExamen.Text = examen.Fecha.ToString();
            tbHospital.Text = examen.Cita.Hospital.Nombre;
            tbFechaCita.Text = examen.Cita.Fecha.ToString();

        }

        protected void ddlPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            examenData = new ExamenData(chain);
            listaExamenes = examenData.GetExamenPorPaciente(Int32.Parse(ddlPaciente.SelectedItem.Value));

            ddlExamen.DataSource = listaExamenes;
            ddlExamen.DataTextField = "Tipo";
            ddlExamen.DataValueField = "IdExamen";
            ddlExamen.DataBind();
        }

        protected void btnActualizarExamen_Click(object sender, EventArgs e)
        {
            examenData = new ExamenData(chain);
            PACIENTE paciente = new PACIENTE();
            Examen examen = new Examen();

            paciente.NumeroP = int.Parse(ddlPaciente.SelectedItem.Value);
            examen.IdExamen = int.Parse(ddlExamen.SelectedItem.Value);
            examen.Fecha = Convert.ToDateTime(tbFechaExamen.Text);
            examen.Cita.Fecha = Convert.ToDateTime(tbFechaCita.Text);
            examen.Cita.Hospital.Nombre = tbHospital.Text;
            examen.Estado = ddlEstado.SelectedItem.Value;
            examen.Resultado = txtResultado.Value;

            examenData.ActualizaExamenPaciente(paciente, examen);
        }
    }
}