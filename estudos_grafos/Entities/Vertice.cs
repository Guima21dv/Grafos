using System;

namespace estudos_grafos.Entities
{
    class Vertice
    {
        public string Rotulo { get; set; } //RÓTULO DO VERTICE
        public int Valor { get; private set; }

        public Vertice(string rotulo)
        {
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
