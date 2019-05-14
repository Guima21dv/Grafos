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



            Console.WriteLine("*****INICIANDO TESTES PARA CRIAÇÃO DO GRAFO*****");
            Console.Write("Quantos vértices o grafo tem: ");
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

            string aresta1;
            string aresta2;
            do
            {
                Console.Write("Entre com o primeiro vertice ou 0 para cancelar: ");
                aresta1 = Console.ReadLine();
                Console.Write("Entre com o segundo vertice ou 0 para cancelar: ");
                aresta2 = Console.ReadLine();
                if (g1.AdicionaArestaPonderada(new Vertice(aresta1), new Vertice(aresta2),2))
                {
                    Console.WriteLine("Aresta adicionada!");
                }


            } while (aresta != "0");
            Console.WriteLine("Insira o vértice pra saber seus vizinhos");
            string vertice2 = Console.ReadLine();

            List<int> teste = new List<int>();
            teste = g1.GetVizinhos(g1.Vertices[0]);

            foreach (int i in teste)
            {
                Console.WriteLine("aqui: " + i);
            }

            g1.ImprimeMatriz();

            g1.ImprimeLista();


            Console.ReadLine();


        }
    }
}
