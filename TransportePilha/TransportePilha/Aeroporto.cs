using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportePilha
{
    public class Aeroporto
    {

        public int IdAeroporto { get; set; }
        public string NomeAeroporto { get; set; }

        public Stack<Veiculo> pilhaVeiculo = new Stack<Veiculo>();

        public Aeroporto()
        {
        }

        public Aeroporto(int id, string nome)
        {
            IdAeroporto = id;
            NomeAeroporto = nome;
        }


        public bool entrarVeiculo(Veiculo veiculo)
        {
            pilhaVeiculo.Push(veiculo);
            return true;
        }

        public bool sairVeiculo(Veiculo veiculo)
        {
            pilhaVeiculo.Pop();
            Console.WriteLine("EXCLUIDO");
            return true;
        }



        public Veiculo pesquisarVeiculo(Veiculo veiculo)
        {
            foreach (Veiculo v in pilhaVeiculo)
            {
                if (veiculo.getIdVeiculo == v.getIdVeiculo)
                {
                    return v;
                }
            }

            return null;
        }

        public bool despacharVeiculo(Veiculo veiculo)
        {

            pilhaVeiculo.Pop();
            return true;

        }

        public override string ToString()
        {

            return "\nId:" + IdAeroporto +
                   "\nNome: " + NomeAeroporto;
                   //"\n------------------------"; 
        }


    }
}
