using ClubeDaLeitura.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class RepositorioRevistas
    {
        public ArrayList listaRevistas = new ArrayList();

        public void Registrar(Revistas revistas)
        {
            listaRevistas.Add(revistas);
        }
        internal void Editar(Revistas revistas, string nome, int numero, int ano, Caixas caixas)
        {
            revistas.nome = nome;
            revistas.numero = numero;
            revistas.ano = ano;
            revistas.caixas = caixas;
        }

        public void Excluir(int idSelecionado)
        {
            Revistas revistas = SelecionarRevistasComId(idSelecionado);

            listaRevistas.Remove(revistas);
        }

        public Revistas SelecionarRevistasComId(int id)
        {
            Revistas revistas = null;

            foreach (var r in listaRevistas)
            {
                Revistas revistas2 = r as Revistas;
                if (revistas2.id == id)
                {
                    revistas = revistas2;
                    break;
                }
            }
            return revistas;
        }
    }
}
