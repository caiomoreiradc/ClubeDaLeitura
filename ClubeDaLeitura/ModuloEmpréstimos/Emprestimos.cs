using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmpréstimos
{
    internal class Emprestimos
    {
        public int id;
        public int idAmigo;
        public string amigoEmprestou;
        public int idRevista;
        public string revistaEmprestada;
        public DateTime dataEmprestimo;
        public string dataDevolucao;
        public int dia;
        public int mes;
        public int ano;

        public Revistas revistas;
    }
}
