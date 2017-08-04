using LibreriaHospitales.Business;
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
    public partial class RemplazoMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                DiagnosticoBusiness diagnosticoBusiness =
                     new DiagnosticoBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);

                LinkedList<Medico> medico = diagnosticoBusiness.GetMedicos();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (Medico medicoActual in medico)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    ddl_medicos.Items.Add(new ListItem(medicoActual.Dni + ""));
                }


            }
        }
        protected void btn_remplazar_Click(object sender, EventArgs e)
        {
            int dniMedicoAremplazar = Int32.Parse(ddl_medicos.SelectedItem.Value);
            int dniMedico = Int32.Parse(tb_medico.Text);
            String especialidad = tb_especialidad.Text;
            int montoE = Int32.Parse(tb_medico.Text);
            DateTime fechaI = Calendar1.SelectedDate;
            String estado = tb_estado.Text;
            

        }
    }
}