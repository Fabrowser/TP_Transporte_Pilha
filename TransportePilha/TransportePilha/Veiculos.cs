using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{
    public class Veiculos
    {

        public List<Veiculo> listaDeVeiculos = new List<Veiculo>();


        public bool addVeiculo(Veiculo veiculo)
        {

            listaDeVeiculos.Add(veiculo);
            
            return true;

        }



    }
}
