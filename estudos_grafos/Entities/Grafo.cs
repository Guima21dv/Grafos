using System;
using System.Collections.Generic;
using System.Collections;

namespace estudos_grafos.Entities

{
    class Grafo
    {
        //Atributos da classe Grafo
        public int N { get; set; } // Número de vértices
        public int M { get; set; } // Número de arestas
        private const int INDEFINIDO = -1;
        private const int INFINITO = int.MaxValue;
        
        public int[,] MatrizAdjacencia;
        public Vertice[] Vertices { get; set; } //Vetor de Rótulos dos vértices


        //CONSTRUTOR DA CLASSE
        public Grafo(int n)
        {
            //Inicialização dos atributos 
            N = n;

            MatrizAdjacencia = new int[N, N];
            
            Vertices = new Vertice[N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    MatrizAdjacencia[i, j] = INFINITO;

                }
                
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
            int indice_v = IndiceVertice(v);
            bool flag = false;
            int j = 0;
            Vertice[] aux = new Vertice[N - 1];
            if (!(indice_v == -1) && !v.IsNull())
            {
                for (int i = 0; i < Vertices.Length; i++)
                {
                    if (Vertices[i].Rotulo == v.Rotulo)
                    {
                        Vertices[i] = null;
                        flag = true;
                    }
                    if (Vertices[i] != null)
                    {
                        aux[j] = Vertices[i];
                        j++;
                    }
                }
                if (flag)
                {
                    N--;
                    MatrizAdjacencia = new int[N, N];
                    Vertices = aux;
                    Console.WriteLine("Nó removido!");
                }
                else
                {
                    Console.WriteLine("Não foi possível retirar o nó.");
                    
                }

            }
            else
            {
                Console.WriteLine("Não foi encontrado vértice correspondete!");
            }
            Console.ReadLine();
        }

        public bool AdicionaArestaPonderada(Vertice origem, Vertice destino, int valor)
        {
            int indice_origem = IndiceVertice(origem);//Verifica se o primeiro vértice existe procurando seu rótulo no vetor de vértices.
            int indice_destino = IndiceVertice(destino);//Verifica se o segundo vértice existe procurando seu rótulo no vetor de vértices.
            if (indice_origem != -1 && indice_destino != -1)
            {
                MatrizAdjacencia[indice_origem, indice_destino] = valor;
                MatrizAdjacencia[indice_destino, indice_origem] = valor;

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

        //RETORNA A LISTA DE VIZINHOS DO VERTICE v
        public List<int> GetVizinhos(Vertice v)
        {
            List<int> vizinhos = new List<int>();
            int indice_vertice = IndiceVertice(v);
            for (int i = 0; i < MatrizAdjacencia.GetLength(0); i++)
            {
                if (MatrizAdjacencia[indice_vertice, i] < INFINITO)
                {
                    vizinhos.Add(i);
                }
            }
            return vizinhos;
        }
        //RETORNA O VALOR DE UMA ARESTA
        public int GetCusto(int vertice1, int vertice2)
        {
            return MatrizAdjacencia[vertice1, vertice2];
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

        public void ImprimeVertices()
        {
            Console.WriteLine("NÓS DISPONÍVEIS: ");
            for (int i = 0; i < Vertices.Length; i++)
            {
                Console.Write("[ " + Vertices[i].Rotulo + " ]  ");
            }
        }

        //RE ROTULA O GRAFO PARA POSSIBILITAR O CALCULO DE CAMINHO MINIMO COM OS RÓTULOS CORRETOS
        private void ReRotular(int vertice)
        {
            int[] aux = new int[MatrizAdjacencia.GetLength(1)];

            for (int i = 0; i < aux.Length; i++)
            {
                aux[i] = MatrizAdjacencia[0, i];
                MatrizAdjacencia[0, i] = MatrizAdjacencia[vertice, i];
                MatrizAdjacencia[i, 0] = MatrizAdjacencia[i, vertice];
                MatrizAdjacencia[vertice, i] = aux[i];
                MatrizAdjacencia[i, vertice] = aux[i];
            }
            Vertice aux_v = Vertices[0];
            Vertices[0] = Vertices[vertice];
            Vertices[vertice] = aux_v;
        }

        public void ImprimeMatrizPonderada()//Imprime a matriz de adjacência com formatação bem furreca
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
        
        //CAMINHO MINIMO ALGORITMO DE DIJKSTRA

        public List<int> AlgoritmoDijkstra(Vertice orig, Vertice dest)
        {
            if (!(IndiceVertice(orig) == -1 || IndiceVertice(dest) == -1))
            {
                //INICIALIZAÇÃO \/----------------------------------------
                int indice_ori = IndiceVertice(orig);
                int indice_des = IndiceVertice(dest);

                ReRotular(indice_ori);//RE-ROTULA O GRAFO

                int[] antecessores = new int[N];
                int[] vetor_custos = new int[N];
                HashSet<int> conj_nao_visitado = new HashSet<int>();
                List<int> nos_antecessores = new List<int>();

                //Primeiro nó a (origem) tem custo 0
                vetor_custos[indice_ori] = 0;

                //Todos os outros tem custo infinito
                for (int i = 0; i < N; i++)
                {
                    if (i >= 1)
                    {
                        vetor_custos[i] = INFINITO;
                    }

                    antecessores[i] = INDEFINIDO;
                    conj_nao_visitado.Add(i);
                }
                //INICIALIZAÇÃO /\-----------------------------------------

                //INTERAÇÕES \/
                while (conj_nao_visitado.Count != 0)
                {
                    int near = MenorCusto(conj_nao_visitado, vetor_custos);
                    conj_nao_visitado.Remove(near);

                    foreach (int neighbor in GetVizinhos(Vertices[near]))
                    {
                        int custo_total = vetor_custos[near] + GetCusto(near, neighbor);
                        if (custo_total < vetor_custos[neighbor])
                        {
                            vetor_custos[neighbor] = custo_total;
                            antecessores[neighbor] = near;
                        }
                    }
                    if (near == indice_des)
                    {
                        ReRotular(0);
                        return CriarRotas(antecessores, near);
                    }
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado vértices correspondentes");
                ReRotular(0);
                return new List<int>();
            }
            
            return new List<int>();

        }

        private List<int> CriarRotas(int[] ant, int u)
        {
            List<int> rotas = new List<int>();
            rotas.Add(u);
            while (ant[u] != INDEFINIDO)
            {
                rotas.Add(ant[u]);
                u = ant[u];
            }
            rotas.Reverse();
            return rotas;
        }
        private int MenorCusto(HashSet<int> nao_visitado, int[] custo)
        {
            int menor = INFINITO;
            int minIndex = 0;
            foreach (int i in nao_visitado)
            {
                if (custo[i] < menor)
                {
                    menor = custo[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        private int DistanciaMinima()
        {
            return 0;
        }
    }
}