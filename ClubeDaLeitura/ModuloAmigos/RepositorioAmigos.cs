using ClubeDaLeitura.ModuloEmpréstimos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class RepositorioAmigos
    {
        public ArrayList listaAmigos = new ArrayList();

        public void Registrar(Amigos amigos)
        {
            listaAmigos.Add(amigos);
        }

        public void Editar(Amigos amigos, string nome, string nomeResponsavel, double telefone, string telefoneFormatado, string endereco)
        {
            amigos.nome = nome;
            amigos.nomeResponsavel = nomeResponsavel;
            amigos.telefone = telefone;
            amigos.telefoneFormatado = telefoneFormatado;
            amigos.endereco = endereco;
        }

        public void Excluir(int idSelecionado)
        {
            Amigos amigos = SelecionarAmigosComId(idSelecionado);
            listaAmigos.Remove(amigos);
        }

        public Amigos SelecionarAmigosComId(int id)
        {
            Amigos amigos = null;

            foreach (var a in listaAmigos)
            {
                Amigos amigos2 = a as Amigos;
                if (amigos2.id == id)
                {
                    amigos = amigos2;
                    break;
                }
            }
            return amigos;
        }

    }
}
