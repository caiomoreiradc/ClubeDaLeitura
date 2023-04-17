using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class RepositorioAmigos
    {
        public static ArrayList listaAmigos = new ArrayList();

        public static void Registrar(Amigos amigos, int id, string nome, string nomeResponsavel, double telefone, string telefoneFormatado, string endereco)
        {
            amigos.id = id;
            amigos.nome = nome;
            amigos.nomeResponsavel = nomeResponsavel;
            amigos.telefone = telefone;
            amigos.telefoneFormatado = telefoneFormatado;
            amigos.endereco = endereco;
        }
        public static void Editar(int id, string nome, string nomeResponsavel, double telefone, string telefoneFormatado, string endereco)
        {
            Amigos amigos = TelaAmigos.SelecionarAmigosComId(id);
            amigos.id = id;
            amigos.nome = nome;
            amigos.nomeResponsavel = nomeResponsavel;
            amigos.telefone = telefone;
            amigos.telefoneFormatado = telefoneFormatado;
            amigos.endereco = endereco;
        }


    }
}
