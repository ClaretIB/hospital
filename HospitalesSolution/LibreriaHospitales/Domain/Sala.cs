namespace LibreriaHospitales.Domain
{
    public class Sala
    {

        private int numSala;

        public Sala(int numSala)
        {
            this.numSala = numSala;
        }
        public Sala()
        {

        }

        public int NumSala
        {
            get
            {
                return numSala;
            }

            set
            {
                numSala = value;
            }
        }
    }
}