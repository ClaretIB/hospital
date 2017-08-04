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
    public partial class EliminarMedico : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;
        private MedicoData medicoData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                medicoData = new MedicoData(chain);
                LinkedList<Medico> listaMedicos = medicoData.GetMedicos();

                ddlMedicos.DataSource = listaMedicos;
                ddlMedicos.DataTextField = "Dni1";
                ddlMedicos.DataValueField = "Dni1";
                ddlMedicos.DataBind();
             }
        }

        protected void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            medicoData = new MedicoData(chain);
            medicoData.EliminarMedico(Int32.Parse(ddlMedicos.SelectedItem.Value));
            ddlMedicos.Items.Remove(ddlMedicos.SelectedItem.Text);

        }
    }
}