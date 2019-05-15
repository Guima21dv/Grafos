using System;
using System.Collections.Generic;

namespace estudos_grafos.Entities

{
    class Grafo
    {
        //Atributos da classe Grafo
        public int N { get; set; } // Número de vértices
        public int M { get; set; } // Número de arestas
        private const int INFINITO = int.MaxValue;
        public List<int>[] ListaAdjacencia { get; set; } // Lista de adjacência sem rótulos
        public int[,] MatrizAdjacenciaPonderada;
        public Vertice[] Vertices { get; set; } //Vetor de Rótulos dos vértices
        public List<Vertice> Lista_Vertices{get; set;}

        //CONSTRUTOR DA CLASSE
        public Grafo(int n)
        {
            //Inicialização dos atributos 
            N = n;

            MatrizAdjacenciaPonderada = new int[N, N];
            ListaAdjacencia = new List<int>[N];
            Vertices = new Vertice[N]; 
            Lista_Vertices = new List<Vertice>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    MatrizAdjacenciaPonderada[i, j] = INFINITO;

                }
                ListaAdjacencia[i] = new List<int>();
            }
        }
        //ADICIONA VÉRTICE AO VETOR DE RÓTULOS. AS POSIÇÕES DESTE VETOR SERÁ UTILIZADA PARA CRIAÇÃO DA MATRIZ e LISTA DE ADJACENCIA
        public void AdicionaVertice(Vertice v)
        {
            if (!v.IsNull() && IndiceVertice(v) == -1)
            {
                for (int i = 0; i < N; i++)
                {
                    if (Vertices[i] == null)
                    {
                        Vertices[i] = v;
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Vértice já existe!");
            }
        }

        public void RemoveVertice(Vertice v)
        {
            //Falta implementação.
        }

        

        public bool AdicionaArestaPonderada(Vertice origem, Vertice destino, int valor)
        {
            int indice_origem = IndiceVertice(origem);//Verifica se o primeiro vértice existe procurando seu rótulo no vetor de vértices.
            int indice_destino = IndiceVertice(destino);//Verifica se o segundo vértice existe procurando seu rótulo no vetor de vértices.
            if (IndiceVertice(origem) != -1 && IndiceVertice(destino) != -1)
            {
                MatrizAdjacenciaPonderada[indice_origem, indice_destino] = valor;
                MatrizAdjacenciaPonderada[indice_destino, indice_origem] = valor;

                Vertices[indice_origem].Grau++;
                Vertices[indice_destino].Grau++;
            }
            else
            {
                return false;
            }
            M++;
            return true;
        }

        public List<int> GetVizinhos(Vertice v)
        {
            List<int> vizinhos = new List<int>();
            int indice_vertice = IndiceVertice(v);
            for(int i = 0; i < MatrizAdjacenciaPonderada.GetLength(0); i++)
            {
                if(MatrizAdjacenciaPonderada[indice_vertice, i] < INFINITO)
                {
                    vizinhos.Add(i);
                }
            }
            return vizinhos;
        }

        


        private int IndiceVertice(Vertice vertice)//Procura o rótulo do vértice parametrizado, se existir retorna o índice, else, retorna -1
        {
            for (int i = 0; i < N; i++)
            {
                if (!(Vertices[i] == null))
                {
                    if (Vertices[i].Rotulo == vertice.Rotulo)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        

        public void ImprimeMatrizPonderada()//Imprime a matriz de adjacência com formatação bem furreca
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < N; j++)
                {
                    Console.Write(MatrizAdjacenciaPonderada[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
        //MÉTODOS PARA IMPRESSÃO DA MATRIZ E LISTA DE ADJACÊNCIA

        public void ImprimeLista()
        {
            for (int i = 0; i < N; i++)
            {
                string resultado = "(" + Vertices[i].Rotulo + ") ";
                foreach (int vertice in ListaAdjacencia[i])
                {
                    resultado += " -> " + Vertices[vertice].Rotulo;
                }
                Console.WriteLine(resultado);
            }
        }

        //CAMINHO MINIMO ALGORITMO DE DIJKSTRA

        public void AlgoritmoDijkstra()
        {
            //INICIALIZAÇÃO \/----------------------------------------
            int k = 0;
            Vertice r;
            int[] vetor_rotas = new int[N];
            int[] vetor_distancias = new int[N];
            vetor_distancias[0] = 0;
            HashSet<int> temporarios = new HashSet<int>();
            HashSet<int> permanentes = new HashSet<int>();
            HashSet<int> conjunto_s = new HashSet<int>();
            conjunto_s.Add(0);
            

            for (int i = 0; i < vetor_rotas.Length; i++)
            {
                if(i >= 1)
                {
                    vetor_distancias[i] = INFINITO;
                }
                vetor_rotas[i] =0;
                temporarios.Add(i);
            }
            //INICIALIZAÇÃO /\-----------------------------------------

            //INTERAÇÕES \/
            while (temporarios.Count != 0)
            {
                k++;

                for (int i = 0; ; i++)
                {

                }
            }
        }

        private int DistanciaMinima()
        {
            return 0;
        }
    }
}
