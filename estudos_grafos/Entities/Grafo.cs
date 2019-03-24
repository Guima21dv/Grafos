using System;
using System.Collections.Generic;

namespace estudos_grafos.Entities

{
    class Grafo
    {
        //Atributos da classe Grafo
        public int N { get; set; } // Número de vértices
        public int M { get; set; } // Número de arestas
        public List<Vertice>[] ListaAdjacencia{ get; set; } // Lista de adjacência sem rótulos
        public int[,] MatrizAdjacencia;
        public Vertice [] Rotulos { get; set; } //Vetor de Rótulos dos vértices
        
        //CONTRUTOR DO GRAFO
        public Grafo(int n)
        {
            N = n;//Atribui o parâmetro de construção á propriedade "N" 
            MatrizAdjacencia = new int[N, N]; //Inicializa a matriz de adjacência 
            ListaAdjacencia = new List<Vertice>[N]; // Inicializa a lista de adjacência(necessita implementar)
            Rotulos = new Vertice[N]; //Inicializa o vetor de rótulos dos vértices
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    MatrizAdjacencia[i, j] = 0;
                }
            }
        }
        //ADICIONA VÉRTICE AO VETOR DE RÓTULOS. AS POSIÇÕES DESTE VETOR SERÁ UTILIZADA PARA CRIAÇÃO DA MATRIZ DE ADJACENCIA
        public void adicionaVertice(Vertice v)
        {
            if (!v.isNull()) {
                for (int i = 0; i < N; i++)
                {
                    if (Rotulos[i] == null)
                    {
                        Rotulos[i] = v;
                        break;
                    }
                }
            }
        }

        public bool adicionaAresta(string aresta)
        {
            string[] aux = aresta.Split('-');
            int posVertice1;
            int posVertice2;
            if(aux.Length != 2)
            {
                return false;
            }
            posVertice1 = existeVertice(aux[0]);
            posVertice2 = existeVertice(aux[1]);
            if(posVertice1 != -1 && posVertice2 != -1)
            {
                MatrizAdjacencia[posVertice1, posVertice2] = 1;
                MatrizAdjacencia[posVertice2, posVertice1] = 1;
            }
            else
            {
                Console.WriteLine("Não foi encontrado vértices correspondentes.");
                return false;
            }
            M++;
            return true;
            
        }

        public void imprimeMatriz()
        {
            for(int i = 0; i < N; i++)
            {
                Console.Write(Rotulos[i].Rotulo + "");
                for(int j = 0; j < N; j++)
                {
                    Console.Write(MatrizAdjacencia[i, j] + " ");
                    
                }
                Console.WriteLine();
            }
        }

        private int existeVertice(string rotulo)
        {
            for(int i = 0; i < N; i++)
            {
                if(Rotulos[i].Rotulo == rotulo && !Rotulos[i].isNull())
                {
                    return i; 
                }
            }
            return -1;
        }
    }
}
