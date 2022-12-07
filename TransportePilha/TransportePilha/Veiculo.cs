using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{
    public class Veiculo
    {

        private int IdVeiculo;
        private string ModeloVeiculo;
        private int Capacidade;



        public Veiculo (int id, string modelo, int capacidade)
        {

            IdVeiculo = id;
            ModeloVeiculo = modelo ;
            this.Capacidade = capacidade;

        }

        public int getIdVeiculo()
        {

            return IdVeiculo;

        }

        public string getModeloVeiculo()
        {

            return ModeloVeiculo;

        }

        public int getCapacidade()
        {

            return Capacidade;

        }


        public override string ToString()
        {
            return "Id: " + IdVeiculo +
                    "\nModelo: " + ModeloVeiculo +
                    "\nCapacidade: " + Capacidade;
        }


    }
}
