using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{
    public class Aeroportos
    {

        public List<Aeroporto> ListaAeroportos = new List<Aeroporto>();

        public Aeroportos()
        {


        }

        public bool addAeroporto(Aeroporto aeroporto)
        {

            ListaAeroportos.Add(aeroporto);
            return true;

        }

        public Aeroporto pesquisaAeroporto(int cod){


            foreach (Aeroporto a in ListaAeroportos)
            {
                if(cod == a.IdAeroporto)
                {
                    return a;
                }

            }

            return null;

        }


    }
}
