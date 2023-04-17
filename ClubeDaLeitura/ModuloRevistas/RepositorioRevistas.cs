using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class RepositorioRevistas
    {
        private static ArrayList listaRevistas = new ArrayList();

        internal static void Registrar(Revistas revistas, int id, string? nome, int numero, int ano, int caixaId)
        {
            revistas.id = id;
            revistas.nome = nome;
            revistas.numero = numero;
            revistas.ano = ano;
            revistas.caixaId = caixaId;
        }
        internal static void Editar(int id, string? nome, int numero, int ano, int caixaId)
        {
            Revistas revistas = TelaRevistas.SelecionarRevistasComId(id);
            revistas.id = id;
            revistas.nome = nome;
            revistas.numero = numero;
            revistas.ano = ano;
            revistas.caixaId = caixaId;
        }
    }
}
