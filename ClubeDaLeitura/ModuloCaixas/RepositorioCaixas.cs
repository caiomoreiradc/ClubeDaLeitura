using ClubeDaLeitura.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixas
{
    internal class RepositorioCaixas
    {
        public static ArrayList listaCaixas = new ArrayList();

        internal static void Registrar(Caixas caixas, int id, string cor, string etiqueta)
        {
            caixas.id = id;
            caixas.cor = cor;
            caixas.etiqueta = etiqueta; 
        }
        internal static void Editar(int id, string? cor, string? etiqueta)
        {
            Caixas caixas = TelaCaixas.SelecionarCaixaComId(id);
            caixas.id = id;
            caixas.cor = cor;
            caixas.etiqueta = etiqueta;
        }
    }
}
