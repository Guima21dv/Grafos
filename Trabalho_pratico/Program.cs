using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_pratico.Classes;

namespace Trabalho_pratico
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_1());
            try
            {
                Grafo g = new Grafo(20);
            }catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro inesperado");
                Console.WriteLine(e.Message);
            }
        }
    }
}
