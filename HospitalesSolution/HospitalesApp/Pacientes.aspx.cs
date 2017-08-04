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
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PACIENTE paciente = new PACIENTE();
            paciente.NumeroP = Int32.Parse(tbNumero.Text);
            paciente.Cedula = tbDNI.Text;
            paciente.Direccion = tbDireccion.Text;
            paciente.Compania = tbCompania.Text;
            paciente.Telefono = tbTelefono.Text;
            paciente.NombreApe = tbNombre.Text;
            paciente.NumeroSS = Int32.Parse(tbNSS.Text);
            paciente.TipoSeguro = tbTipoSeguro.Text;
            paciente.MontoCobertura = float.Parse(tbMontoCobertura.Text);

            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            pacienteData.Insertar(paciente, "INSERT");
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            tbNumero.Enabled = true;
            tbDNI.Enabled = true;
            tbNombre.Enabled = true;
            tbTelefono.Enabled = true;
            tbTipoSeguro.Enabled = true;
            tbMontoCobertura.Enabled = true;
            tbCompania.Enabled = true;
            tbDireccion.Enabled = true;
            tbNSS.Enabled = true;
            btnAgregar.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            ddlPaciente.Enabled = false;
            tbNumero.Text = "";
            tbCompania.Text = "";
            tbDireccion.Text = "";
            tbDNI.Text = "";
            tbMontoCobertura.Text = "";
            tbNombre.Text = "";
            tbNSS.Text = "";
            tbTelefono.Text = "";
            tbTipoSeguro.Text = "";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<PACIENTE> pacientes = pacienteData.GetPacientes();

            ddlPaciente.Enabled = true;

            ddlPaciente.DataSource = pacientes;
            ddlPaciente.DataTextField = "NombreApe";
            ddlPaciente.DataValueField = "NumeroP";
            ddlPaciente.DataBind();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            btnAgregar.Enabled = false;
            tbNumero.Enabled = false;
        }

        protected void ddlPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            PACIENTE paciente = pacienteData.GetPaciente(Int32.Parse(ddlPaciente.SelectedItem.Value));
            tbNumero.Text = paciente.NumeroP + "";
            tbCompania.Enabled = true;
            tbCompania.Text = paciente.Compania;
            tbDireccion.Enabled = true;
            tbDireccion.Text = paciente.Direccion;
            tbDNI.Enabled = true;
            tbDNI.Text = paciente.Cedula;
            tbMontoCobertura.Enabled = true;
            tbMontoCobertura.Text = paciente.MontoCobertura + "";
            tbNombre.Enabled = true;
            tbNombre.Text = paciente.NombreApe;
            tbNSS.Enabled = true;
            tbNSS.Text = paciente.NumeroSS + "";
            tbTelefono.Enabled = true;
            tbTelefono.Text = paciente.Telefono;
            tbTipoSeguro.Enabled = true;
            tbTipoSeguro.Text = paciente.TipoSeguro;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            PACIENTE paciente = new PACIENTE();
            paciente.NumeroP = Int32.Parse(tbNumero.Text);
            paciente.Cedula = tbDNI.Text;
            paciente.Direccion = tbDireccion.Text;
            paciente.Compania = tbCompania.Text;
            paciente.Telefono = tbTelefono.Text;
            paciente.NombreApe = tbNombre.Text;
            paciente.NumeroSS = Int32.Parse(tbNSS.Text);
            paciente.TipoSeguro = tbTipoSeguro.Text;
            paciente.MontoCobertura = float.Parse(tbMontoCobertura.Text);

            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            pacienteData.Insertar(paciente, "UPDATE");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            PACIENTE paciente = new PACIENTE();
            paciente.NumeroP = Int32.Parse(tbNumero.Text);
            paciente.Cedula = tbDNI.Text;
            paciente.Direccion = tbDireccion.Text;
            paciente.Compania = tbCompania.Text;
            paciente.Telefono = tbTelefono.Text;
            paciente.NombreApe = tbNombre.Text;
            paciente.NumeroSS = Int32.Parse(tbNSS.Text);
            paciente.TipoSeguro = tbTipoSeguro.Text;
            paciente.MontoCobertura = float.Parse(tbMontoCobertura.Text);

            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            pacienteData.Insertar(paciente, "DELETE");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            PacienteData pacienteData = new PacienteData(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);
            LinkedList<PACIENTE> pacientes = pacienteData.GetPacientes();

            ddlPaciente.Enabled = true;

            ddlPaciente.DataSource = pacientes;
            ddlPaciente.DataTextField = "NombreApe";
            ddlPaciente.DataValueField = "NumeroP";
            ddlPaciente.DataBind();
            btnDelete.Enabled = true;
            btnAgregar.Enabled = false;
            btnUpdate.Enabled = false;
            tbNumero.Enabled = false;
        }
    }
}