using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmpréstimos
{
    internal class RepositorioEmprestimos
    {
        internal static void Editar(int id, string? amigoEmprestou, string? revistaEmprestada, int dia, int mes, int ano, DateTime dataEmprestimo, string dataDevolucao)
        {
            Emprestimos emprestimos = TelaEmprestimos.SelecionarEmprestimosComId(id);
            emprestimos.id = id;
            emprestimos.amigoEmprestou = amigoEmprestou;
            emprestimos.revistaEmprestada = revistaEmprestada;
            emprestimos.ano = ano;
            emprestimos.mes = mes;
            emprestimos.dia = dia;
            emprestimos.dataEmprestimo = dataEmprestimo;
            emprestimos.dataDevolucao = dataDevolucao;
        }

        internal static void Registrar(Emprestimos emprestimos, int id, int idAmigo, string amigoEmprestou, int idRevista, string? revistaEmprestada, int dia, int mes, int ano, DateTime dataEmprestimo, string dataDevolucao)
        {
            emprestimos.id = id;
            emprestimos.idAmigo = idAmigo;
            emprestimos.amigoEmprestou = amigoEmprestou;
            emprestimos.idRevista = idRevista;
            emprestimos.revistaEmprestada = revistaEmprestada;
            emprestimos.ano = ano;
            emprestimos.mes = mes;
            emprestimos.dia = dia;
            emprestimos.dataEmprestimo = dataEmprestimo;
            emprestimos.dataDevolucao = dataDevolucao;
        }
    }
}
