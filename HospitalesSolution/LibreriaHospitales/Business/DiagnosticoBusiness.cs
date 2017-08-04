using LibreriaHospitales.DataAccess;
using LibreriaHospitales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Business
{
    public class DiagnosticoBusiness
    {
        DiagnosticoData diagnosticoData;

        public DiagnosticoBusiness(String cadenaConexion)
        {
            diagnosticoData = new DiagnosticoData(cadenaConexion);
        }


        public LinkedList<Medico> GetMedicos()
        {
            return diagnosticoData.GetMedicos();
        }

        public LinkedList<PACIENTE> GetPacientes()
        {
            return diagnosticoData.GetPacientes();
        }

        public LinkedList<Hora> GetCitasDisponibles(String fecha, String nombreHopital)
        {
            return diagnosticoData.GetCitasDisponibles(fecha, nombreHopital);
        }

        public LinkedList<Hospital> GetHospitales()
        {
            return diagnosticoData.GetHospitales();
        }

        public Diagnostico InsertarDiagnostico(Diagnostico diagnostico)
        {
            return diagnosticoData.InsertarDiagnostico(diagnostico);
        }
    }
}
            