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
    public partial class AdmisionCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {

                AdmisionBusiness admisionBusiness =
                     new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);


                LinkedList<PACIENTE> paciente = admisionBusiness.GetPacientes();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (PACIENTE pacienteActual in paciente)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    DropDownList1.Items.Add(new ListItem(pacienteActual.NumeroP + ""));
                }

                LinkedList<Hospital> hospital = admisionBusiness.GetHospitales();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (Hospital hospiActual in hospital)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    DropDownList2.Items.Add(new ListItem(hospiActual.Nombre));
                }

                ddl_eliminar.Visible = false;
                btn_Accion_eliminar.Visible = false;
                ddlCambiaPaciente.Visible = false;
                ddl_cambia_hospital.Visible = false;
                ddl_cambia_sala.Visible = false;
                btn_Accion_Actualizar.Visible = false;
                lb_hospital.Visible = false;
                lb_paciente.Visible = false;
                lb_sala.Visible = false;
            }//if

        }

        protected void Btn_Agregar_Click(object sender, EventArgs e)
        {
            AdmisionBusiness adminBusinness = new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ToString());

            String nombreHospital = DropDownList2.SelectedItem.Value;
            int numPaciente = Int32.Parse(DropDownList1.SelectedItem.Value);
            int numSala = Int32.Parse(DropDownList3.SelectedItem.Value);
            // DateTime fecha = DateTime.Today;

            Admision admision = new Admision();
            admision.NumSala = numSala;
            admision.NumeroPasiente = numPaciente;
            admision.NombreHospital = nombreHospital;
            // admision.Fecha = fecha;

            try
            {
                adminBusinness.InsertarLibro(admision);
                lbl_agregar.Text = "Admision agregada con exito...";
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String nombreHospital = DropDownList2.SelectedItem.Value;

            AdmisionBusiness admisionBusiness =
                     new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);

            LinkedList<Sala> sala = admisionBusiness.GetSalasPorHospital(nombreHospital);
            //como llenar el DropDownList al agregar varios ListItem
            foreach (Sala salaActual in sala)
            {//recordar ejemplo de que muestro el nombre pero mando el carne
                DropDownList3.Items.Add(new ListItem(salaActual.NumSala + ""));
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_borrar_Click(object sender, EventArgs e)
        {
            ddl_eliminar.Visible = true;
            btn_Accion_eliminar.Visible = true;


            ddlCambiaPaciente.Visible = false;
            ddl_cambia_hospital.Visible = false;
            ddl_cambia_sala.Visible = false;
            btn_Accion_Actualizar.Visible = false;
            lb_hospital.Visible = false;
            lb_paciente.Visible = false;
            lb_sala.Visible = false;

            btn_actualizar.Visible = false;
            btn_borrar.Visible = false;

            AdmisionBusiness admisionBusiness =
                     new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);

                LinkedList<Admision> admision = admisionBusiness.GetAdmisiones();
                //como llenar el DropDownList al agregar varios ListItem
                foreach (Admision adActual in admision)
                {//recordar ejemplo de que muestro el nombre pero mando el carne
                    int numAdmin = adActual.NumAdmision;
                    String nombreHospital = adActual.NombreHospital;
                    int numPaciente = adActual.NumeroPasiente;
                    int numSala = adActual.NumSala;

                    String conjunto ="#"+numAdmin+ "Hopital: " + nombreHospital + " Paciente:" + numPaciente + " Sala: " + numSala;
                
                    ListItem Item = new ListItem();
                    Item.Value = numAdmin+"";
                    Item.Text = conjunto;
                    ddl_eliminar.Items.Add(Item);

            }

        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            ddl_eliminar.Visible = true;
            ddlCambiaPaciente.Visible = true;
            ddl_cambia_hospital.Visible = true;
            ddl_cambia_sala.Visible = true;
            btn_Accion_Actualizar.Visible = true;
            lb_hospital.Visible = true;
            lb_paciente.Visible = true;
            lb_sala.Visible = true;
            
            btn_Accion_eliminar.Visible = false;

            btn_actualizar.Visible = false;
            btn_borrar.Visible = false;

            AdmisionBusiness admisionBusiness =
                 new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);

            LinkedList<Admision> admision = admisionBusiness.GetAdmisiones();
            //como llenar el DropDownList al agregar varios ListItem
            foreach (Admision adActual in admision)
            {//recordar ejemplo de que muestro el nombre pero mando el carne
                int numAdmin = adActual.NumAdmision;
                String nombreHospital = adActual.NombreHospital;
                int numPaciente = adActual.NumeroPasiente;
                int numSala = adActual.NumSala;

                String conjunto = "#" + numAdmin + "Hopital: " + nombreHospital + " Paciente:" + numPaciente + " Sala: " + numSala;

                ListItem Item = new ListItem();
                Item.Value = numAdmin + "";
                Item.Text = conjunto;
                ddl_eliminar.Items.Add(Item);

            }

            LinkedList<PACIENTE> paciente = admisionBusiness.GetPacientes();
            //como llenar el DropDownList al agregar varios ListItem
            foreach (PACIENTE pacienteActual in paciente)
            {//recordar ejemplo de que muestro el nombre pero mando el carne
                ddlCambiaPaciente.Items.Add(new ListItem(pacienteActual.NumeroP + ""));
            }

            LinkedList<Hospital> hospital = admisionBusiness.GetHospitales();
            //como llenar el DropDownList al agregar varios ListItem
            foreach (Hospital hospiActual in hospital)
            {//recordar ejemplo de que muestro el nombre pero mando el carne
                ddl_cambia_hospital.Items.Add(new ListItem(hospiActual.Nombre));
            }

        }

        protected void btn_Accion_eliminar_Click(object sender, EventArgs e)
        {
            AdmisionBusiness adminBusinness = new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ToString());

            int numAdmin = Int32.Parse(ddl_eliminar.SelectedItem.Value);

            try
            {
                adminBusinness.ElimarAdmision(numAdmin);
                lbl_agregar.Text = "Admision eliminada con exito..."+ numAdmin;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void btn_Accion_Actualizar_Click(object sender, EventArgs e)
        {
            AdmisionBusiness adminBusinness = new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ToString());

            int numAdmin = Int32.Parse(ddl_eliminar.SelectedItem.Value);
            String nombreHospital = ddl_cambia_hospital.SelectedItem.Value;
            int numPaciente = Int32.Parse(ddlCambiaPaciente.SelectedItem.Value);
            int numSala = Int32.Parse(ddl_cambia_sala.SelectedItem.Value);

            try
            {
                adminBusinness.ActualizarAdmision(numAdmin, numPaciente, nombreHospital, numSala);
                lbl_agregar.Text = "Admision actualizada con exito..." + numAdmin;
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        protected void ddl_cambia_hospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            String nombreHospital = ddl_cambia_hospital.SelectedItem.Value;

            AdmisionBusiness admisionBusiness =
                     new AdmisionBusiness(WebConfigurationManager.ConnectionStrings["ProyectoHospitales"].ConnectionString);

            LinkedList<Sala> sala = admisionBusiness.GetSalasPorHospital(nombreHospital);
            //como llenar el DropDownList al agregar varios ListItem
            foreach (Sala salaActual in sala)
            {//recordar ejemplo de que muestro el nombre pero mando el carne
                ddl_cambia_sala.Items.Add(new ListItem(salaActual.NumSala + ""));
            }
        }
    }
}