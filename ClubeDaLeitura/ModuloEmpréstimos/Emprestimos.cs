using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmpréstimos
{
    public class Emprestimos : Entidade
    {
        public static int contadorId = 1;
        public string amigoEmprestou;
        public string revistaEmprestada;
        public string dataDevolucao;
        public string dataEmprestimo;
        public Amigos amigos;
        public Revistas revistas;

        public Emprestimos()
        {
            
        }

        public Emprestimos(Amigos amigoEmprestou, Revistas revistaEmprestada, string dataEmprestimo, string dataDevolucao)
        {
            id= contadorId++;
            this.amigos = amigoEmprestou;
            this.revistas = revistaEmprestada;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
        }


    }
}
