using System;
using estudos_grafos.Entities;

namespace estudos_grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****INICIANDO TESTES PARA CRIAÇÃO DO GRAFO*****");
            Console.Write("Quantos vértices o grafo tem: ");
            int n = int.Parse(Console.ReadLine());
            Grafo g1 = new Grafo(n);
            Console.WriteLine("Número de vértices: " + g1.N);
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Rótulo do {i+1}º vértice: ");
                string rotulo = Console.ReadLine();
                
                g1.adicionaVertice(new Vertice(rotulo));
            }
            Console.WriteLine($"Foi adicionado ao grafo os seguintes vértices: ");
            Console.WriteLine();
            foreach (Vertice item in g1.Vertices)
            {
                Console.WriteLine(item.Rotulo);
            }

            Console.WriteLine("Indique as arestas do grafo:");
            Console.WriteLine("**PARA CANCELAR A ENTRADA DE ARESTAS ESCREVA 0**\n");
            Console.WriteLine("Utilize o rótulo do vértice, um hífen, " +
                "e o rótulo do segundo vértice.\n\nExemplo: Vertice1-Vertice2\n");

            string aresta;
            do
            {
                Console.Write("Entre com a aresta ou 0 para cancelar: ");
                aresta = Console.ReadLine();
                if (g1.adicionaAresta(aresta))
                {
                    Console.WriteLine("Aresta adicionada!");
                }
                

            } while (aresta != "0");
            Console.WriteLine("Insira o vértice pra saber seus vizinhos");
            string vertice2 = Console.ReadLine();

            g1.getVizinhos(g1.Vertices.)

            g1.imprimeMatriz();

            g1.imprimeLista();


            Console.ReadLine();



        }
    }
}
