using System;
using System.Collections.Generic;

namespace estudos_grafos.Entities

{
    class Grafo
    {
        //Atributos da classe Grafo
        public int N { get; set; } // Número de vértices
        public int M { get; set; } // Número de arestas
        public List<int>[] ListaAdjacencia{ get; set; } // Lista de adjacência sem rótulos
        public int[,] MatrizAdjacencia;//Matriz de adjacência do grafo
        public List<Vertice> Vertices { get; set; } //Vetor de Rótulos dos vértices
        
        //CONSTRUTOR DA CLASSE
        public Grafo(int n)
        {
            N = n;//Atribui o parâmetro de construção á propriedade "N" 
            MatrizAdjacencia = new int[N, N]; //Inicializa a matriz de adjacência 
            ListaAdjacencia = new List<int>[N]; // Inicializa a lista de adjacência(necessita implementar)
            Vertices = new List<Vertice>(); //Inicializa o vetor de rótulos dos vértices
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    MatrizAdjacencia[i, j] = 0;
                    
                }
                ListaAdjacencia[i] = new List<int>();
            }
        }
        //ADICIONA VÉRTICE AO VETOR DE RÓTULOS. AS POSIÇÕES DESTE VETOR SERÁ UTILIZADA PARA CRIAÇÃO DA MATRIZ e LISTA DE ADJACENCIA
        public void adicionaVertice(Vertice v)
        {
            if (!v.isNull() && existeVertice(v.Rotulo) == -1) {
                for (int i = 0; i < N; i++)
                {
                    if (Vertices[i] == null)
                    {
                        Vertices[i] = v;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Vértice já existe nesse!");
            }
        }

        public bool adicionaAresta(string aresta) //Adiciona aresta verificando se foi enviado uma sentença correta como padrão descrito(Vertice-Vertice)
        {                                         //verificando se é um par de rótulos separados por hífen(-)
            string[] aux = aresta.Split('-');
            int posVertice1;
            int posVertice2;
            if(aux.Length != 2)
            {
                if(aux[0] == "0")
                {
                    Console.WriteLine();
                    return false;
                }
                Console.WriteLine("Parâmetros incorretos para inserção de aresta.\n");
                return false;
            }
            posVertice1 = existeVertice(aux[0]);//Verifica se o primeiro vértice existe procurando seu rótulo no vetor de vértices.
            posVertice2 = existeVertice(aux[1]);//Verifica se o segundo vértice existe procurando seu rótulo no vetor de vértices.
            if(posVertice1 != -1 && posVertice2 != -1)
            {
                MatrizAdjacencia[posVertice1, posVertice2] = 1;
                MatrizAdjacencia[posVertice2, posVertice1] = 1;

                ListaAdjacencia[posVertice1].Add(posVertice2);
                ListaAdjacencia[posVertice2].Add(posVertice1);

                Vertices[posVertice1].Grau++;
                Vertices[posVertice2].Grau++;
            }
            else
            {
                Console.WriteLine("Não foi encontrado vértices correspondentes.\n");
                return false;
            }
            M++;
            return true;
            
        }

        public List<int> getVizinhos(Vertice v)
        {

            List<int> vizinhos = new List<int>();
            for (int i = 0; i < MatrizAdjacencia.Length; i++)
            {
                if (MatrizAdjacencia[indiceVertice(v), i] > 0)
                {
                    vizinhos.Add(i);
                }
            }
            return vizinhos;
        }

        private int indiceVertice(Vertice vertice)
        {
            for (int i = 0; i < N; i++)
            {
                if (Vertices[i].Rotulo == vertice.Rotulo && !Vertices[i].isNull())
                {
                    return i;
                }
            }
            return -1;
        }



        private int existeVertice(string rotulo)//Procura o rótulo do vértice parametrizado, se existir retorna o índice, else, retorna -1
        {
            //for(int i = 0; i < N; i++)
            //{
            //    if(Vertices[i].Rotulo == rotulo && !Vertices[i].isNull())
            //    {
            //        return i; 
            //    }
            //}
            //return -1;
            foreach (Vertice v in Vertices)
            {
                if (Vertices.Contains(v))
                {
                    return Vertices.IndexOf(v);
                }
            }
            return -1;
        }

        public void imprimeMatriz()//Imprime a matriz de adjacência com formatação bem furreca
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < N; j++)
                {
                    Console.Write(MatrizAdjacencia[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
        //MÉTODOS PARA IMPRESSÃO DA MATRIZ E LISTA DE ADJACÊNCIA

        public void imprimeLista()
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


        public void algoritmoDijkstra()
        {
            int k = 0;
            HashSet<Vertice> A;
            
        }
    }
}
