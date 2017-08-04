using LibreriaHospitales.DataAccess;
using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Business
{
    public class AdmisionBusiness
    {
        AdmisionData admisionData;

        public AdmisionBusiness(String cadenaConexion)
        {
            admisionData = new AdmisionData(cadenaConexion);
        }


        public LinkedList<PACIENTE> GetPacientes()
        {
            return admisionData.GetPacientes();
        }

        public LinkedList<Hospital> GetHospitales()
        {
            return admisionData.GetHospitales();
        }

        public LinkedList<Sala> GetSalasPorHospital(String nombreHopital)
        {
            return admisionData.GetSalasPorHospital(nombreHopital);
        }

        public Admision InsertarLibro(Admision admision)
        {
            return admisionData.InsertarLibro(admision);
        }

        public LinkedList<Admision> GetAdmisiones()
        {
            return admisionData.GetAdmisiones();
        }

        public void ElimarAdmision(int nunAdmin)
        {
          
        }

        public void ActualizarAdmision(int numAdmision, int numPaciente, String nombreHospital, int nunSala)
        {

        }
    }
}
