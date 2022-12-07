using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{

    internal class Jornadas
    {

        public List<Jornada> jornadas = new List<Jornada>();

        public bool AddJornada(Jornada jornada)
        {

            jornadas.Add(jornada);

            return true;
        }


    }
}
