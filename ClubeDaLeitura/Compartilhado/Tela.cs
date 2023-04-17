using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Compartilhado
{
    internal class Tela
    {
        public static void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ResetColor();
            Console.Write(mensagem, Console.ForegroundColor = cor);
        }
    }
}
