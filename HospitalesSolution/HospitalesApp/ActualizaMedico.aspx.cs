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
    public partial class ActualizaMedico : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;
        private MedicoData medicoData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                medicoData = new MedicoData(chain);
                LinkedList<Medico> listaMedicos = medicoData.GetMedicos();

                ddlMedicosModificar.DataSource = listaMedicos;
                ddlMedicosModificar.DataTextField = "Dni1";
                ddlMedicosModificar.DataValueField = "Dni1";
                ddlMedicosModificar.DataBind();
            }
        }

        protected void ddlMedicosModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicoData = new MedicoData(chain);
            Medico medico = medicoData.GetMedicoPorDni(Int32.Parse(ddlMedicosModificar.SelectedItem.Value));

            tbNuevoDNI.Text =medico.Dni.ToString();
            tbNuevaEspecialidad.Text = medico.Especialidad;
            tbNuevaFechaIngreso.Text = medico.FechaIngreso.ToString();
            tbNuevoMonto.Text = medico.MontoEspecialidad.ToString();
            tbNuevoEstado.Text = medico.Estado;
        }

        protected void btnActualizaMedico_Click(object sender, EventArgs e)
        {
            medicoData = new MedicoData(chain);
            Medico medicoModificado = new Medico();
            medicoModificado.Dni = Int32.Parse(tbNuevoDNI.Text);
            medicoModificado.Especialidad = tbNuevaEspecialidad.Text;
            medicoModificado.FechaIngreso = Convert.ToDateTime(tbNuevaFechaIngreso.Text);
            medicoModificado.MontoEspecialidad = Int32.Parse(tbNuevoMonto.Text);
            medicoModificado.Estado = tbNuevoEstado.Text;

            medicoData.ActualizarMedico(medicoModificado);
        }
    }
}