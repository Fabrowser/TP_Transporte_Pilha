using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using TransportePilha;

public class Program
{


    private static void Main(string[] args)
    {
        Jornada jornada = new Jornada();
        Veiculos veiculos = new Veiculos();
        Aeroporto aeroporto = new Aeroporto();
        Aeroportos aeroportos = new Aeroportos();
        Viagens viagens = new Viagens();

        string opcao = "";

        aeroportos.addAeroporto(new Aeroporto(1, "CONGONHAS"));
        aeroportos.addAeroporto(new Aeroporto(2, "GUARULHOS"));

        veiculos.addVeiculo(new Veiculo(1, "VAN 1", 8));
        veiculos.addVeiculo(new Veiculo(2, "VAN 2", 5));
        veiculos.addVeiculo(new Veiculo(3, "VAN 3", 4));
        veiculos.addVeiculo(new Veiculo(4, "VAN 4", 7));
        veiculos.addVeiculo(new Veiculo(5, "VAN 5", 6));
        veiculos.addVeiculo(new Veiculo(6, "VAN 6", 5));
        veiculos.addVeiculo(new Veiculo(7, "VAN 7", 4));
        veiculos.addVeiculo(new Veiculo(8, "VAN 8", 8));


        while (opcao != "0")
        {
            Console.WriteLine("0. Finalizar\n1. Cadastrar veículo\n2. Cadastrar garagem\n" +
            "3. Iniciar jornada\n4. Encerrar jornada\n5. Liberar viagem de uma determinada origem para um determinado destino\r\n" +
            "6. Listar veículos em determinada garagem\n7. Quantidade de viagens(Origem e Destino)\n" +
            "8. Listar Viagens(Origem e Destino)\n9. Quantidade de passageiros transportados(Origem e Destino)");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    {

                        if (jornada.getStatusJornada() == false)
                        {
                            Console.WriteLine("CADASTRAR VEICULO: \n----------------");
                            Console.WriteLine("Digite o Cod. Veiculo");
                            int cod = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o modelo do Veiculo");
                            string modelo = Console.ReadLine();
                            Console.WriteLine("Digite a capacidade:");
                            int capacidade = int.Parse(Console.ReadLine());

                            // Adiciona à lista s veiculos
                            veiculos.addVeiculo(new Veiculo(cod, modelo, capacidade));

                        }
                        else
                        {
                            Console.WriteLine("Encerrar a jornada para usar essa função![opção 4]\n");
                        }

                        break;

                    }

                case "2":
                    {
                        if (jornada.getStatusJornada() == false)
                        {
                            Console.WriteLine("CADASTRAR GARAGEM: \n----------------");
                            Console.WriteLine("Digite o Cod. Garagem");
                            int cod = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o nome do Aeroporto");
                            string nome_garagem = Console.ReadLine();
                            Aeroporto aeroporto1 = new Aeroporto(cod, nome_garagem);
                            aeroportos.addAeroporto(aeroporto1);
                        }
                        else
                        {
                            Console.WriteLine("Desativar a jornada para usar essa função![opção 4]\n");
                        }
                        break;
                    }

                case "3":
                    {
                        if (jornada.getStatusJornada() == true)
                        {
                            Console.WriteLine("Jornada ja esta ATIVA!");
                        }
                        else
                        {
                            jornada.AtivaJOrnada();
                            distribuiCarros();
                            Console.WriteLine("JORNADA FOI ATIVADA!\n");
                        }

                        break;

                    }

                case "4":
                    {
                        if (jornada.getStatusJornada() == false)
                        {
                            Console.WriteLine("Jornada ja esta INATIVA!\n");
                        }
                        else
                        {
                            Console.WriteLine("JORNADA FOI INATIVADA!\n");
                        }

                        break;

                    }

                case "5":
                    {
                        if (jornada.getStatusJornada() == true)
                        {
                            novaViagem();
                        }
                        else
                        {
                            Console.WriteLine("Ativar a jornada para essa função![opção 3]");
                        }

                        break;

                    }

                case "6":
                    {
                        mostraListaToda();
                        break;
                    }
                case "7":
                    {
                        Console.WriteLine("Lista Viagens:\n");
                        mostraListaViagens();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            void novaViagem()
            {

                //CARRO SAINDO E CHEGANDO AO DESTINO

                Console.WriteLine("Aeroportos");
                Console.WriteLine("----------------\n");
                mostralistaAeroportos();
                Console.WriteLine("----------------\n");
                Console.WriteLine("Nova Viagem\n");

                Console.WriteLine("Digite a ORIGEM");
                int cod_origem = int.Parse(Console.ReadLine());


                Console.WriteLine("Aeroportos");
                Console.WriteLine("----------\n");
                mostralistaAeroportos();
                Console.WriteLine("----------------\n");
                Console.WriteLine("Nova Viagem\n");


                Console.WriteLine("Digite o DESTINO");
                int cod_destino = int.Parse(Console.ReadLine());


                foreach (Aeroporto a in aeroportos.ListaAeroportos)
                {
                    Console.WriteLine("Aeroporto: " + a.IdAeroporto +
                        "\nNome: " + a.NomeAeroporto);
                }

                Aeroporto aeroporto_encontrado_destino = aeroportos.pesquisaAeroporto(cod_destino);
                Aeroporto aeroporto_encontrado_origem = aeroportos.pesquisaAeroporto(cod_origem);


                //Pesquisando Aeroporto Origem e Destino
                if (aeroporto_encontrado_destino != null & aeroporto_encontrado_origem != null)
                {
                    //Entra o carro no destino

                    Veiculo primeiro_da_pilha_origem;
                    Veiculo primeiro_da_pilha_destino;

                    if (aeroporto_encontrado_origem.pilhaVeiculo.Count > 0)
                    {
                        primeiro_da_pilha_origem = aeroporto_encontrado_origem.pilhaVeiculo.First();
                        aeroporto_encontrado_destino.entrarVeiculo(primeiro_da_pilha_origem);
                        primeiro_da_pilha_destino = aeroporto_encontrado_destino.pilhaVeiculo.First();

                        //Adiciona Viagem

                        viagens.addViagem(new Viagem(viagens.ListaDeViagens.Count+1,aeroporto_encontrado_origem, aeroporto_encontrado_destino, DateTime.Now, primeiro_da_pilha_origem, primeiro_da_pilha_origem.getCapacidade()));

                        aeroporto_encontrado_origem.sairVeiculo(primeiro_da_pilha_origem);

                    }
                    else
                    {
                        Console.WriteLine("Não há carros na fila da Garagem de: " + aeroporto_encontrado_origem.NomeAeroporto); 

                    }





                }
            }

            void mostraListaViagens()
            {
                foreach (Viagem v in viagens.ListaDeViagens)
                {
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("         VIAGEM  "+ v.getId());
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine(v);
                    Console.WriteLine("-----------------------------");


                }
            }

            void mostralistaAeroportos()
            {
                foreach (Aeroporto a in aeroportos.ListaAeroportos)
                {
                    Console.WriteLine("Aeroporto: " + a.IdAeroporto +

                        "\nNome: " + a.NomeAeroporto);
                }
            }




            void mostraListaToda()
            {
                foreach (Aeroporto a in aeroportos.ListaAeroportos)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Aeroporto:            |");
                    Console.WriteLine("-----------------------" + a);
                    Console.WriteLine("-----------------------");


                    foreach (Veiculo v in a.pilhaVeiculo)
                    {
                        Console.WriteLine(v);
                        Console.WriteLine("------------------");
                    }

                }
            }

            void distribuiCarros()
            {

                if (jornada.getStatusJornada() == true)
                {
                    //Distribui os Veiculos existentes aos dois aeroportos
                    for (int i = 0; i < veiculos.listaDeVeiculos.Count(); i++)
                    {

                        foreach (Aeroporto a in aeroportos.ListaAeroportos)
                        {

                            if (i < veiculos.listaDeVeiculos.Count)
                            {
                                //Console.WriteLine("i: " + i + "- Veiculo: " + veiculos.listaDeVeiculos[i].getModeloVeiculo() + "Adicionado ao aeroporto: " + a.NomeAeroporto);
                                a.entrarVeiculo(veiculos.listaDeVeiculos[i]);
                                i++;
                            }

                        }
                        i--;

                    }

                }
                else
                {
                    Console.WriteLine("Ativar a jornada para essa função![opção 3]");
                }

            }

        }

    }
}


