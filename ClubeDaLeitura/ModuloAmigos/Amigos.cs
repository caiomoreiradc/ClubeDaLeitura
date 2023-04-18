using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloEmpréstimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class Amigos : Entidade
    {
        public static int contadorId = 1;
        public string nome;
        public string nomeResponsavel;
        public double telefone;
        public string telefoneFormatado;
        public string endereco;

        public Amigos()
        {
            
        }

        public Amigos(string nome, string nomeResponsavel, double telefone, string telefoneFormatado, string endereco)
        {
            id = contadorId++;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.telefoneFormatado = telefoneFormatado;
            this.endereco = endereco;
        }

    }
}
