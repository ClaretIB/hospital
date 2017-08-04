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
    public partial class ActualizarExamen : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;
        private ExamenData examenData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                examenData = new ExamenData(chain);
                LinkedList<Examen> listaExamenes = examenData.GetExamenes();

                ddlExamenes.DataSource = listaExamenes;
                ddlExamenes.DataTextField = "IdExamen";
                ddlExamenes.DataValueField = "IdExamen";
                ddlExamenes.DataBind();
            }
        }

        protected void ddlExamenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            examenData = new ExamenData(chain);
            Examen examen = examenData.GetExamenPorID(Int32.Parse(ddlExamenes.SelectedItem.Value));

            tbNuevoID.Text = examen.IdExamen.ToString();
            tbNuevoTipo.Text = examen.Tipo;
            tbPrecio.Text = examen.Precio.ToString();
        }
    }
}