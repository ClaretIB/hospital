using LibreriaHospitales.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Business
{
    public class MedicoBusiness
    {
        MedicoData medicoData;

        public MedicoBusiness(String cadenaConexion)
        {
            medicoData = new MedicoData(cadenaConexion);
        }


        public void reemplazaMedico(int dniMv, int dniMn, String especialidad, int montoEspe, DateTime fechaI, String estado)
        {

        }


    }
}
