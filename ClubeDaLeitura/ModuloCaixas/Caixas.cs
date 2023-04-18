using ClubeDaLeitura.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    public class Caixas : Entidade
    {
        public static int contadorId = 1;
        public string cor;
        public string etiqueta;
        public Caixas()
        {
            
        }
        public Caixas(string cor, string etiqueta)
        {
            id = contadorId++;
            this.cor = cor;
            this.etiqueta = etiqueta;
        }


    }
}
