using System;

namespace Trabalho_pratico.Classes
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
            return this.Equals(null);
        }
    }
}
