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
        public int[,] MatrizAdjacencia;//Matriz de adjacência do grafo
        public int[,] MatrizAdjacenciaPonderada;
        public Vertice[] Vertices { get; set; } //Vetor de Rótulos dos vértices
        public List<Vertice> Lista_Vertices{get; set;}

        //CONSTRUTOR DA CLASSE
        public Grafo(int n)
        {
            //Inicialização dos atributos 
            N = n;            MatrizAdjacencia = new int[N, N]; 
            ListaAdjacencia = new List<int>[N];
            Vertices = new Vertice[N]; 
            Lista_Vertices = new List<Vertice>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MatrizAdjacencia[i, j] = 0;
                    MatrizAdjacenciaPonderada[i, j] = INFINITO;

                }
                ListaAdjacencia[i] = new List<int>();
            }
        }
        //ADICIONA VÉRTICE AO VETOR DE RÓTULOS. AS POSIÇÕES DESTE VETOR SERÁ UTILIZADA PARA CRIAÇÃO DA MATRIZ e LISTA DE ADJACENCIA
        public void AdicionaVertice(Vertice v)
        {
            if (!v.IsNull() && ExisteVertice(v.Rotulo) == -1)
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
                Console.WriteLine("Vértice já existe nesse!");
            }
        }

        public void RemoveVertice(Vertice v)
        {
            //Falta implementação.
        }

        public bool AdicionaAresta(string aresta) //Adiciona aresta verificando se foi enviado uma sentença correta como padrão descrito(Vertice-Vertice)
        {                                         //verificando se é um par de rótulos separados por hífen(-)
            string[] aux = aresta.Split('-');
            int posVertice1;
            int posVertice2;
            if (aux.Length != 2)
            {
                Console.WriteLine("Parâmetros incorretos para inserção de aresta.\n");
                return false;
            }
            posVertice1 = ExisteVertice(aux[0]);//Verifica se o primeiro vértice existe procurando seu rótulo no vetor de vértices.
            posVertice2 = ExisteVertice(aux[1]);//Verifica se o segundo vértice existe procurando seu rótulo no vetor de vértices.
            if (posVertice1 != -1 && posVertice2 != -1)
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

        public bool AdicionaARestaPonderada(Vertice v1, Vertice v2, int valor)
        {
            if(!(v1.IsNull() || v2.IsNull()))
            {
                int indice_v1 = IndiceVertice(v1);
                int indice_v2 = IndiceVertice(v2);

                MatrizAdjacenciaPonderada[indice_v1, indice_v2] = valor;
                MatrizAdjacenciaPonderada[indice_v2, indice_v1] = valor;

                Vertices[indice_v1].Grau++;
                Vertices[indice_v2].Grau++;

                return true;
            }
                return false;
        }

        public bool AdicionaArestaPonderada(Vertice origem, Vertice destino, int valor)
        {
            int indice_origem = IndiceVertice(origem);//Verifica se o primeiro vértice existe procurando seu rótulo no vetor de vértices.
            int indice_destino = IndiceVertice(destino);//Verifica se o segundo vértice existe procurando seu rótulo no vetor de vértices.
            if (IndiceVertice(origem) != -1 && IndiceVertice(destino) != -1)
            {
                MatrizAdjacencia[indice_origem, indice_destino] = valor;
                MatrizAdjacencia[indice_destino, indice_origem] = valor;

                Vertices[indice_origem].Grau++;
                Vertices[indice_destino].Grau++;
            }
            else
            {
                Console.WriteLine("Não foi encontrado vértices correspondentes.\n");
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
                if(MatrizAdjacenciaPonderada[indice_vertice,i] < INFINITO)
                {
                    vizinhos.Add(i);
                }
            }
            return vizinhos;
        }

        private int ExisteVertice(string rotulo)//Procura o rótulo do vértice parametrizado, se existir retorna o índice, else, retorna -1
        {
            for (int i = 0; i < N; i++)
            {
                if (!(Vertices[i] == null))
                {
                    if (Vertices[i].Rotulo == rotulo)
                    {
                        return i;
                    }
                }
            }
            foreach(Vertice v in Lista_Vertices)
            {
                if(!(v.Rotulo == rotulo))
                {
                    return Lista_Vertices.IndexOf(v);
                }
            }
            return -1;
        }


        private int IndiceVertice(Vertice vertice)//Procura o rótulo do vértice parametrizado, se existir retorna o índice, else, retorna -1
        {
            for (int i = 0; i < N; i++)
            {
                if (Vertices[i].Rotulo == vertice.Rotulo && !Vertices[i].IsNull())
                {
                    return i;
                }
            }
            return -1;
        }

        public void ImprimeMatriz()//Imprime a matriz de adjacência com formatação bem furreca
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
