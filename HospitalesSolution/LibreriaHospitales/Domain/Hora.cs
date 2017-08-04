using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaHospitales.Domain
{
    public class Hora
    {
        private string horas;

        public string Horas
        {
            get
            {
                return horas;
            }

            set
            {
                horas = value;
            }
        }

        public Hora(string horas)
        {
            this.Horas = horas;
        }
        public Hora()
        {

        }
    }
}
