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
    public partial class InsertarMedico : System.Web.UI.Page
    {
        private String chain = WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

            }

        }

        protected void btnInsertarMedico_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico();
            medico.Dni = Int32.Parse(tbDNI.Text);
            medico.Especialidad= tbEspecialidad.Text;
            medico.MontoEspecialidad = Int32.Parse(tbMonto.Text);
            medico.Estado = tbEstado.Text;
            medico.FechaIngreso = DateTime.Now;

            MedicoData medicoData = new MedicoData(chain);
            medicoData.InsertarMedico(medico);

        }
    }
}