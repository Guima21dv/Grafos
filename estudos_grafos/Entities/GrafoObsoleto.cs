using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estudos_grafos.Entities
{
    class GrafoObsoleto
    {
        public int N { get; set; } // Número de vértices
        public int M { get; set; } // Número de arestas
        public int[,] MatrizAdjacencia;//Matriz de adjacência do grafo
        public List<int>[] ListaAdjacencia { get; set; } // Lista de adjacência sem rótulos
        public Vertice[] Vertices { get; set; } //Vetor de Rótulos dos vértices
        public List<Vertice> Lista_Vertices { get; set; }


        public GrafoObsoleto(int n)
        {
            ListaAdjacencia = new List<int>[N];
            Vertices = new Vertice[N];
            Lista_Vertices = new List<Vertice>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MatrizAdjacencia[i, j] = 0;

                }
                ListaAdjacencia[i] = new List<int>();
            }
            
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
            foreach (Vertice v in Lista_Vertices)
            {
                if (!(v.Rotulo == rotulo))
                {
                    return Lista_Vertices.IndexOf(v);
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
    }
}
