using System;
using System.Collections.Generic;
using estudos_grafos.Entities;
using System.Linq;
using System.IO;

namespace estudos_grafos
{
    class Program
    {
        static void GeraTitlo()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("*******   *****   *     *  *******  *******");
            Console.WriteLine("*        *        **    *  *           *");
            Console.WriteLine("*         *       * *   *  *           *");
            Console.WriteLine("*          ****   *  *  *  ******      *");
            Console.WriteLine("*              *  *   * *  *           *");
            Console.WriteLine("*             *   *    **  *           *");
            Console.WriteLine("*******  ******   *     *  *******     *");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
        //GERAÇÃO DO GRAFO
        static Grafo grafo = new Grafo(20);
        static int[] metrica_A = new int[20];
        static int[] metrica_C = {
                2,2,3,5,10,5,2,10,2,2,15,7,16,10,10,6,6,8,6,6,4,4,3,2,3,2,3,6,7,3,5,4
            };
        static int[] metrica_B = {
                6,7,1,2,12,2,6,5,7,3,5,1,2,2,3,7,20,7,9,3,2,8,10,8,20,18,21,22,22,4,8,15
            };
        static
        static void Main(string[] args)
        {

            
            //ADICIONANDO VÉRTICES AO GRAFO
            grafo.AdicionaVertice(new Vertice("POA"));
            grafo.AdicionaVertice(new Vertice("FLO"));
            grafo.AdicionaVertice(new Vertice("BLU"));
            grafo.AdicionaVertice(new Vertice("CUR"));
            grafo.AdicionaVertice(new Vertice("LON"));
            grafo.AdicionaVertice(new Vertice("SPO"));
            grafo.AdicionaVertice(new Vertice("SJC"));
            grafo.AdicionaVertice(new Vertice("RJO"));
            grafo.AdicionaVertice(new Vertice("BHO"));
            grafo.AdicionaVertice(new Vertice("CAM"));
            grafo.AdicionaVertice(new Vertice("RBP"));
            grafo.AdicionaVertice(new Vertice("BAU"));
            grafo.AdicionaVertice(new Vertice("CPG"));
            grafo.AdicionaVertice(new Vertice("CUI"));
            grafo.AdicionaVertice(new Vertice("MAN"));
            grafo.AdicionaVertice(new Vertice("BEL"));
            grafo.AdicionaVertice(new Vertice("BSB"));
            grafo.AdicionaVertice(new Vertice("NTL"));
            grafo.AdicionaVertice(new Vertice("REC"));
            grafo.AdicionaVertice(new Vertice("SLV"));

            
            for (int i = 0; i < metrica_A.Length; i++)
            {
                metrica_A[i] = 1;
            }
            
           
            try
            {
                GeraTitlo();

                List<string> menu_options = new List<string>()
                {
                    "Calcular o caminho mínimo utilizando o Algoritmo de Dijkstra",
                    "Gerar Falha em um nó",
                    "Gerar Falha em uma aresta",
                    "Redefinir Grafo",
                    "Fechar a aplicação"

                };

                Console.CursorVisible = false;

                while (true)
                {
                    
                    string opcao_selecionada = DrawMenu(menu_options);

                    if(opcao_selecionada == "Calcular o caminho mínimo utilizando o Algoritmo de Dijkstra")
                    {
                        CalculaCaminhoMinimo();
                        GeraTitlo();
                    }
                    if(opcao_selecionada == "Gerar Falha em um nó")
                    {
                        GeraFalhaVertice();
                    }
                    if(opcao_selecionada == "Gerar Falha em uma aresta")
                    {
                        GeraFalhaAresta();
                    }
                    if(opcao_selecionada == "Fechar a aplicação")
                    {
                        Environment.Exit(1);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void GeraFalhaVertice()
        {

            grafo = new Grafo(n);
        }
        static void GeraFalhaAresta()
        {

            
        }
        static void CalculaCaminhoMinimo()
        {
            Console.Clear();
            GeraTitlo();
            while (true)
            {
                Console.Write("Digite o nó origem: ");
                string origem = Console.ReadLine();
                Console.Write("Digite o nó destino: ");
                string destino = Console.ReadLine();
                Console.Write("Digite a métrica utilizada(Digite a letra \"A\" para Hops/Digite a letra \"B\" para Distância Geográfica/Digite a letra \"C\" para Custo)");
                string metrica = Console.ReadLine();

                if (metrica == "A")
                {
                    grafo.AdicionaArestaPonderada(new Vertice("POA"), new Vertice("FLO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("POA"), new Vertice("BLU"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("FLO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("CUR"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("RJO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BLU"), new Vertice("CUR"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("CUR"), new Vertice("LON"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("CUR"), new Vertice("SPO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("LON"), new Vertice("SPO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("LON"), new Vertice("BAU"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("RJO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("CAM"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("SJC"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("SJC"), new Vertice("CAM"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("SJC"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("BHO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("SLV"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BHO"), new Vertice("SJC"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BHO"), new Vertice("BSB"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("CAM"), new Vertice("BAU"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("CAM"), new Vertice("RBP"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("RBP"), new Vertice("BSB"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BAU"), new Vertice("CPG"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("CPG"), new Vertice("CUI"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("CUI"), new Vertice("MAN"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("MAN"), new Vertice("BEL"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BEL"), new Vertice("NTL"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BSB"), new Vertice("MAN"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("BSB"), new Vertice("NTL"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("NTL"), new Vertice("REC"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("REC"), new Vertice("SLV"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("SLV"), new Vertice("NTL"), 1);
                }
                else if (metrica == "B")
                {
                    grafo.AdicionaArestaPonderada(new Vertice("POA"), new Vertice("FLO"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("POA"), new Vertice("BLU"), 7);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("FLO"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("CUR"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("RJO"), 12);
                    grafo.AdicionaArestaPonderada(new Vertice("BLU"), new Vertice("CUR"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("CUR"), new Vertice("LON"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("CUR"), new Vertice("SPO"), 5);
                    grafo.AdicionaArestaPonderada(new Vertice("LON"), new Vertice("SPO"), 7);
                    grafo.AdicionaArestaPonderada(new Vertice("LON"), new Vertice("BAU"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("RJO"), 5);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("CAM"), 1);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("SJC"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("SJC"), new Vertice("CAM"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("SJC"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("BHO"), 7);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("SLV"), 20);
                    grafo.AdicionaArestaPonderada(new Vertice("BHO"), new Vertice("SJC"), 7);
                    grafo.AdicionaArestaPonderada(new Vertice("BHO"), new Vertice("BSB"), 9);
                    grafo.AdicionaArestaPonderada(new Vertice("CAM"), new Vertice("BAU"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("CAM"), new Vertice("RBP"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("RBP"), new Vertice("BSB"), 8);
                    grafo.AdicionaArestaPonderada(new Vertice("BAU"), new Vertice("CPG"), 10);
                    grafo.AdicionaArestaPonderada(new Vertice("CPG"), new Vertice("CUI"), 8);
                    grafo.AdicionaArestaPonderada(new Vertice("CUI"), new Vertice("MAN"), 20);
                    grafo.AdicionaArestaPonderada(new Vertice("MAN"), new Vertice("BEL"), 18);
                    grafo.AdicionaArestaPonderada(new Vertice("BEL"), new Vertice("NTL"), 21);
                    grafo.AdicionaArestaPonderada(new Vertice("BSB"), new Vertice("MAN"), 22);
                    grafo.AdicionaArestaPonderada(new Vertice("BSB"), new Vertice("NTL"), 22);
                    grafo.AdicionaArestaPonderada(new Vertice("NTL"), new Vertice("REC"), 4);
                    grafo.AdicionaArestaPonderada(new Vertice("REC"), new Vertice("SLV"), 8);
                    grafo.AdicionaArestaPonderada(new Vertice("SLV"), new Vertice("NTL"), 15);
                }
                else if (metrica == "C")
                {
                    grafo.AdicionaArestaPonderada(new Vertice("POA"), new Vertice("FLO"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("POA"), new Vertice("BLU"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("FLO"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("CUR"), 5);
                    grafo.AdicionaArestaPonderada(new Vertice("FLO"), new Vertice("RJO"), 10);
                    grafo.AdicionaArestaPonderada(new Vertice("BLU"), new Vertice("CUR"), 5);
                    grafo.AdicionaArestaPonderada(new Vertice("CUR"), new Vertice("LON"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("CUR"), new Vertice("SPO"), 10);
                    grafo.AdicionaArestaPonderada(new Vertice("LON"), new Vertice("SPO"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("LON"), new Vertice("BAU"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("RJO"), 15);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("CAM"), 7);
                    grafo.AdicionaArestaPonderada(new Vertice("SPO"), new Vertice("SJC"), 16);
                    grafo.AdicionaArestaPonderada(new Vertice("SJC"), new Vertice("CAM"), 10);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("SJC"), 10);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("BHO"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("RJO"), new Vertice("SLV"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("BHO"), new Vertice("SJC"), 8);
                    grafo.AdicionaArestaPonderada(new Vertice("BHO"), new Vertice("BSB"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("CAM"), new Vertice("BAU"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("CAM"), new Vertice("RBP"), 4);
                    grafo.AdicionaArestaPonderada(new Vertice("RBP"), new Vertice("BSB"), 4);
                    grafo.AdicionaArestaPonderada(new Vertice("BAU"), new Vertice("CPG"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("CPG"), new Vertice("CUI"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("CUI"), new Vertice("MAN"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("MAN"), new Vertice("BEL"), 2);
                    grafo.AdicionaArestaPonderada(new Vertice("BEL"), new Vertice("NTL"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("BSB"), new Vertice("MAN"), 6);
                    grafo.AdicionaArestaPonderada(new Vertice("BSB"), new Vertice("NTL"), 7);
                    grafo.AdicionaArestaPonderada(new Vertice("NTL"), new Vertice("REC"), 3);
                    grafo.AdicionaArestaPonderada(new Vertice("REC"), new Vertice("SLV"), 5);
                    grafo.AdicionaArestaPonderada(new Vertice("SLV"), new Vertice("NTL"), 4);
                }

                List<int> rotas_r = grafo.AlgoritmoDijkstra(new Vertice(origem), new Vertice(destino));
                foreach(int i in rotas_r)
                {
                    Console.Write(grafo.Vertices[i].Rotulo + "-->");

                }
                Console.WriteLine();
                Console.WriteLine("Pressione enter para retornar ao menu anterior");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            
        }

        static int index = 0;
        private static string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();


            }
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1;
                }
                else
                {
                    index--;
                }
            }
            else if (ckey.Key == ConsoleKey.Enter) {
                return items[index];
            }
            else
            {
                return "";
            }
            Console.Clear();
            GeraTitlo();
            return "";
            
        }
    }
}
