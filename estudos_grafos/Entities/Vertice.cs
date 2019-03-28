using System;

namespace estudos_grafos.Entities
{
    class Vertice
    {
        public string Rotulo { get; set; } //RÓTULO DO VERTICE
        public int Valor { get; private set; } //VALOR DO VÉRTICE
        public int Grau { get; set; } //GRAU DO VÉRTICE

        public Vertice(string rotulo)
        {
            Grau = 0;
            Rotulo = rotulo;
        }

        public bool isNull()
        {
            if(this.Equals(null))
            {
                return true;
            }
            return false;
        }
    }
}
