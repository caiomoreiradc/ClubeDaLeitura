using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmpréstimos
{
    internal class TelaEmprestimos
    {
        static ArrayList listaEmprestimos = new ArrayList();

        public static string PainelEmprestimos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============================================");
            Console.WriteLine("          CADASTRO DE EMPRÉSTIMOS");
            Console.WriteLine("============================================");
            Console.WriteLine("Digite 1 para Inserir um novo empréstimo");
            Console.WriteLine("Digite 2 para Visualizar empréstimos");
            Console.WriteLine("Digite 3 para Editar empréstimos");
            Console.WriteLine("Digite 4 para Finalizar empréstimos");
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("Insira uma opção ou digite 9 PARA VOLTAR: ");
            Console.ResetColor();

            string opcao = Console.ReadLine(); //Função retorna o valor lido na Program 

            return opcao;
        }
        public static void CadastroEmprestimos(string opcaoCadastroEmprestimos)
        {
            if (opcaoCadastroEmprestimos == "1")
            {
                Console.Title = "Registro de Empréstimos";
                RegistrarEmprestimos();
            }
            else if (opcaoCadastroEmprestimos == "2")
            {
                Console.Title = "Lista de Empréstimos";
                bool existemEmprestimos = VisualizarEmprestimos(true);

                if (existemEmprestimos)
                    Console.ReadLine();
            }
            else if (opcaoCadastroEmprestimos == "3")
            {
                Console.Title = "Edição de Empréstimos";
                EditarEmprestimos();
            }
            else if (opcaoCadastroEmprestimos == "4")
            {
                Console.Title = "Finalização de Empréstimos";
                ExcluirEmprestimos();
            }            
        }
        public static void RegistrarEmprestimos()
        {
            Console.Clear();
            Tela.MostrarMensagem("Insira o ID do empréstimo: ", ConsoleColor.Yellow);
            int id = int.Parse(Console.ReadLine());

            int idAmigo = TelaAmigos.EncontrarIdAmigo();

            Tela.MostrarMensagem("Insira o o nome do amigo que emprestou: ", ConsoleColor.Yellow); //AUTOMATIZAR COM FUNÇÃO!!
            string amigoEmprestou = Console.ReadLine();

            int idRevista = TelaRevistas.EncontrarIdRevista();

            Tela.MostrarMensagem("Insira o nome da revista emprestada: ", ConsoleColor.Yellow);
            string revistaEmprestada = Console.ReadLine();

            Tela.MostrarMensagem("Insira o dia em que foi emprestada: ", ConsoleColor.Yellow);
            int dia = int.Parse(Console.ReadLine());

            Tela.MostrarMensagem("Insira o mês em que foi emprestada: ", ConsoleColor.Yellow);
            int mes = int.Parse(Console.ReadLine());

            Tela.MostrarMensagem("Insira o ano em que foi emprestada: ", ConsoleColor.Yellow);
            int ano = int.Parse(Console.ReadLine());
            DateTime dataEmprestimo = new DateTime(ano, mes, dia);

            string dataDevolucao = VerificarDevolucao();

            Emprestimos emprestimos = new Emprestimos();

            RepositorioEmprestimos.Registrar(emprestimos, id, idAmigo, amigoEmprestou, idRevista, revistaEmprestada, dia, mes, ano, dataEmprestimo, dataDevolucao);
            listaEmprestimos.Add(emprestimos);
        }
        private static bool VisualizarEmprestimos(bool existemEmprestimos)
        {
            Console.Clear();
            if (listaEmprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo cadastrado!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-8} | {4,-8}", "Id", "Nome Amigo", "Nome Revista", "Data Empréstimo", "Data Devolução");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Emprestimos e in listaEmprestimos)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-8} | {4,-8}", e.id, e.amigoEmprestou, e.revistaEmprestada, e.dataEmprestimo.ToShortDateString(), e.dataDevolucao);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


            Console.ResetColor();

            return true;
        }
        private static void EditarEmprestimos()
        {
            bool existemEmprestimos = VisualizarEmprestimos(false);

            if (existemEmprestimos == false)
                return;

            Console.WriteLine();
            Console.ResetColor();
            int id = EncontrarIdEmprestimo();

            Tela.MostrarMensagem("Insira o nome do amigo que emprestou: ", ConsoleColor.Yellow);
            string amigoEmprestou = Console.ReadLine();

            Tela.MostrarMensagem("Insira o nome da revista: ", ConsoleColor.Yellow);
            string revistaEmprestada = Console.ReadLine();

            Tela.MostrarMensagem("Insira o dia em que foi emprestada: ", ConsoleColor.Yellow);
            int dia = int.Parse(Console.ReadLine());

            Tela.MostrarMensagem("Insira o mês em que foi emprestada: ", ConsoleColor.Yellow);
            int mes = int.Parse(Console.ReadLine());

            Tela.MostrarMensagem("Insira o ano em que foi emprestada: ", ConsoleColor.Yellow);
            int ano = int.Parse(Console.ReadLine());

            DateTime dataEmprestimo = new DateTime(ano, mes, dia);

            string dataDevolucao = VerificarDevolucao();
            RepositorioEmprestimos.Editar(id, amigoEmprestou, revistaEmprestada, dia, mes, ano, dataEmprestimo, dataDevolucao);

        }
        private static void ExcluirEmprestimos()
        {

            bool existemEmprestimos = VisualizarEmprestimos(false);

            if (existemEmprestimos == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdEmprestimo();

            Emprestimos emprestimos = SelecionarEmprestimosComId(idExclusao);

            listaEmprestimos.Remove(emprestimos);

            Tela.MostrarMensagem("Empréstimo deletado!!", ConsoleColor.Red); 
            Console.ReadKey();
        }
        public static int EncontrarIdEmprestimo()
        {
            int idEmprestimo;
            bool idInvalido;

            do
            {
                Tela.MostrarMensagem("Insira o ID do empréstimo: ", ConsoleColor.Yellow);

                idEmprestimo = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarEmprestimosComId(idEmprestimo) == null;

                if (idInvalido)
                    Tela.MostrarMensagem("ID do empréstimo não encontrado, tente novamente!!", ConsoleColor.Red);
            } while (idInvalido);

            return idEmprestimo;
        }
        public static Emprestimos SelecionarEmprestimosComId(int id)
        {
            Emprestimos emprestimos = null;

            foreach (Emprestimos e in listaEmprestimos)
            {
                if (e.id == id)
                {
                    emprestimos = e;
                    break;
                }
            }
            return emprestimos;
        }
        private static string VerificarDevolucao()
        {
            string dataDevolucao = "";
            Tela.MostrarMensagem("A revista já foi devolvida (s/n)? ", ConsoleColor.Yellow);
            string devolucao = Console.ReadLine();

            if (devolucao == "s")
            {
                Tela.MostrarMensagem("Insira a data de devolução: ", ConsoleColor.Yellow);
                dataDevolucao = Convert.ToInt64(Console.ReadLine()).ToString(@"00/00/0000");
            }
            else if (devolucao == "n")
            {

                dataDevolucao += "Não Devolvido";
            }

            return dataDevolucao;
        }
        public static Emprestimos VerificarEmprestimos(int id)
        {
            Emprestimos emprestimos = null;

            foreach (Emprestimos e in listaEmprestimos)
            {
                if (e.idAmigo == id)
                {
                    emprestimos = e;
                    break;
                }
            }
            return emprestimos;
        }
    }
}
