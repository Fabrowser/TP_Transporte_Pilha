using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{
    internal class Jornada
    {
        private bool JornadaAtiva = false;

        public Jornada()
        {
        }

        public bool getStatusJornada()
        {
            return JornadaAtiva;
        }

        public void setMudaStatusJOrnada()
        {
            if (JornadaAtiva == true)
            {
                JornadaAtiva = false;
            }else
            JornadaAtiva = true;
        }

        public void AtivaJOrnada()
        {
            JornadaAtiva = true;
        }

        public void DesativaJOrnada()
        {
            JornadaAtiva = false;
        }


    }
}
