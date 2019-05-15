using System;
using System.Collections.Generic;
using estudos_grafos.Entities;

namespace estudos_grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("*****INICIANDO TESTES PARA CRIAÇÃO DO GRAFO*****");
            //Console.Write("Quantos vértices o grafo tem: ");
            //int n = int.Parse(Console.ReadLine());
            //Grafo g1 = new Grafo(n);
            //Console.WriteLine("Número de vértices: " + g1.N);
            //Console.WriteLine();

            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write($"Rótulo do {i+1}º vértice: ");
            //    string rotulo = Console.ReadLine();

            //    g1.AdicionaVertice(new Vertice(rotulo));
            //}
            //Console.WriteLine($"Foi adicionado ao grafo os seguintes vértices: ");
            //Console.WriteLine();
            //foreach (Vertice item in g1.Vertices)
            //{
            //    Console.WriteLine(item.Rotulo);
            //}

            //Console.WriteLine("Indique as arestas do grafo:");
            //Console.WriteLine("**PARA CANCELAR A ENTRADA DE ARESTAS ESCREVA 0**\n");
            //Console.WriteLine("Utilize o rótulo do vértice, um hífen, " +
            //    "e o rótulo do segundo vértice.\n\nExemplo: Vertice1-Vertice2\n");

            //string aresta;
            //do
            //{
            //    Console.Write("Entre com a aresta ou 0 para cancelar: ");
            //    aresta = Console.ReadLine();
            //    if (g1.AdicionaAresta(aresta))
            //    {
            //        Console.WriteLine("Aresta adicionada!");
            //    }


            //} while (aresta != "0");
            //Console.WriteLine("Insira o vértice pra saber seus vizinhos");
            //string vertice2 = Console.ReadLine();

            //List<int> teste = new List<int>();
            //teste = g1.GetVizinhos(g1.Vertices[0]);

            //foreach (int i in teste)
            //{
            //    Console.WriteLine("aqui: " + i);
            //}

            //g1.ImprimeMatriz();

            //g1.ImprimeLista();


            //Console.ReadLine();


            //GERAÇÃO DO GRAFO
            Grafo grafo = new Grafo(20);
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

            //VETORES DE MÉTRICAS
            int[] metrica_A = new int[20];
            for(int i = 0; i < metrica_A.Length; i++)
            {
                metrica_A[i] = 1;
            }
            int[] metrica_B = {
                6,7,1,2,12,2,6,5,7,3,5,1,2,2,3,7,20,7,9,3,2,8,10,8,20,18,21,22,22,4,8,15
            };
            int[] metrica_C = {
                2,2,3,5,10,5,2,10,2,2,15,7,16,10,10,6,6,8,6,6,4,4,3,2,3,2,3,6,7,3,5,4
            };

            foreach(int i in metrica_B)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(metrica_B.ToString());
            Console.WriteLine(metrica_C.ToString());




            Console.WriteLine("*****INICIANDO TESTES PARA CRIAÇÃO DO GRAFO*****");
            Console.Write("Quantos vértices o grafo tem: ");
            try
            {
                int n = int.Parse(Console.ReadLine());

                Grafo g1 = new Grafo(n);
                Console.WriteLine("Número de vértices: " + g1.N);
                Console.WriteLine();
            

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Rótulo do {i + 1}º vértice: ");
                string rotulo = Console.ReadLine();

                g1.AdicionaVertice(new Vertice(rotulo));
            }
            Console.WriteLine($"Foi adicionado ao grafo os seguintes vértices: ");
            Console.WriteLine();
            foreach (Vertice v in g1.Vertices)
            {
                Console.WriteLine(v.Rotulo);
            }

            Console.WriteLine("Indique as arestas do grafo:");
            Console.WriteLine("**PARA CANCELAR A ENTRADA DE ARESTAS ESCREVA 0**\n");
            //Console.WriteLine("Utilize o rótulo do vértice, um hífen, " +
                //"e o rótulo do segundo vértice.\n\nExemplo: Vertice1-Vertice2\n");

            string aresta1="";
            string aresta2="";
            int valor_aresta;
            while (aresta1 != "0")
            {
                Console.Write("Entre com o primeiro vertice ou 0 para cancelar: ");
                aresta1 = Console.ReadLine();
                if (aresta1 != "0")
                {
                    Console.Write("Entre com o segundo vertice ou 0 para cancelar: ");
                    aresta2 = Console.ReadLine();
                    Console.WriteLine("Digite o valor da aresta: ");
                    valor_aresta = int.Parse(Console.ReadLine());

                    if (g1.AdicionaArestaPonderada(new Vertice(aresta1), new Vertice(aresta2), valor_aresta))
                    {
                        Console.WriteLine("Aresta adicionada!");
                    }
                    else
                    {
                        Console.WriteLine("Ocorreu um problema ao tentar adicionar a resta.");
                    }
                }
            }
            Console.WriteLine("Insira o vértice pra saber seus vizinhos");
            string vertice1 = Console.ReadLine();

            List<int> teste = new List<int>();
            teste = g1.GetVizinhos(new Vertice(vertice1));

            foreach (int i in teste)
            {
                Console.WriteLine("aqui: " + i);
            }

            g1.ImprimeMatrizPonderada();

            //g1.ImprimeLista();


            Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
