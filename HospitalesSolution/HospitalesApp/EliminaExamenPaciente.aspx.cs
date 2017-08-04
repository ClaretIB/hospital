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
    public partial class EliminaExamenPaciente : System.Web.UI.Page
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
            }

        }

        protected void btnEliminarExamen_Click(object sender, EventArgs e)
        {
            int idExamen = Int32.Parse(ddlExamen.SelectedItem.Value);
            int numeroP = Int32.Parse(ddlPaciente.SelectedItem.Value);
            DateTime fecha = Convert.ToDateTime(tbFechaExamen.Text);

            examenData = new ExamenData(chain);
            examenData.EliminaExamenPaciente(numeroP, idExamen, fecha);
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

        protected void ddlExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
    }
}