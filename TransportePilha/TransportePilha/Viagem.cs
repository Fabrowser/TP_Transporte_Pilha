using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TransportePilha
{
    internal class Viagem
    {
        public int IdViagem;
        public Aeroporto Origem;
        public Aeroporto Destino;
        public DateTime DataViagem;
        public Veiculo Veiculo;
        public int QuantidadePassageiros;

        public Viagem(int id, Aeroporto origem, Aeroporto destino, DateTime dataViagem, Veiculo veiculo, int quantidadePassageiros)
        {
            IdViagem = id;
            Origem = origem;
            Destino = destino;
            DataViagem = dataViagem;
            Veiculo = veiculo;
            QuantidadePassageiros = quantidadePassageiros;
        }

        public override string ToString()
        {
            return "\nOrigem:" + Origem.NomeAeroporto +
                    "\nDestino:" + Destino.NomeAeroporto +
                    "\nData: " + DataViagem +
                    "\n-----------------------------" +
                    "\nId. Veiculo: " + Veiculo+
                    "\nPassageiros transportados: " + QuantidadePassageiros;
        }

        public int getId()
        {
            return IdViagem;
        }
    }
}
