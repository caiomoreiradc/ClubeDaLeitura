using ClubeDaLeitura.ModuloAmigos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmpréstimos
{
    public class RepositorioEmprestimos
    {
        public ArrayList listaEmprestimos = new ArrayList();

        public void Registrar(Emprestimos emprestimos)
        {
            listaEmprestimos.Add(emprestimos);
        }
        public void Editar(Emprestimos emprestimos, string? amigoEmprestou, string? revistaEmprestada, string dataEmprestimo, string dataDevolucao)
        {
            emprestimos.amigoEmprestou = amigoEmprestou;
            emprestimos.revistaEmprestada = revistaEmprestada;
            emprestimos.dataEmprestimo = dataEmprestimo;
            emprestimos.dataDevolucao = dataDevolucao;
        }
        public Emprestimos SelecionarEmprestimosComId(int id)
        {
            Emprestimos emprestimos = null;

            foreach (var e in listaEmprestimos)
            {
                Emprestimos emprestimos2 = e as Emprestimos;
                if (emprestimos2.id == id)
                {
                    emprestimos = emprestimos;
                    break;
                }
            }
            return emprestimos;

            Amigos amigos = null;
        }
    }
}
