using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{
    internal class Viagens
    {

        public List<Viagem> ListaDeViagens = new List<Viagem>();
        private int QuantidadeViagens;

        public Viagens()
        {
        }

        public void addViagem(Viagem viagem)
        {
            ListaDeViagens.Add(viagem);
            QuantidadeViagens++;

        }


    }
}
