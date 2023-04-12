using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloEmpréstimos
{
    internal class CadastrarEmprestimos
    {
        static ArrayList listaEmprestimos = new ArrayList();

        public static string PainelEmprestimos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("          CADASTRO DE EMPRÉSTIMOS");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Digite 1 para Inserir umm novo empréstimo");
            Console.WriteLine("Digite 2 para Visualizar empréstimos");
            Console.WriteLine("Digite 3 para Editar empréstimos");
            Console.WriteLine("Digite 4 para Finalizar empréstimos");
            Console.WriteLine("--------------------------------------------");
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
            Console.Write("Insira o id do empréstimo: ");
            int id = int.Parse(Console.ReadLine());

            int idAmigo = CadastrarAmigos.EncontrarIdAmigo();

            Console.Write("Insira o nome do amigo que emprestou: ");
            string amigoEmprestou = Console.ReadLine();

            int idRevista = CadastrarRevistas.EncontrarIdRevista();

            Console.Write("Insira o nome da revista: ");
            string revistaEmprestada = Console.ReadLine();

            Console.Write("Insira a data que foi emprestada: ");
            int dataEmprestimo = int.Parse(Console.ReadLine());

            string dataDevolucao = VerificarDevolucao();

            Emprestimos emprestimos = new Emprestimos();

            emprestimos.id = id;
            emprestimos.idAmigo = idAmigo;
            emprestimos.amigoEmprestou = amigoEmprestou;
            emprestimos.idRevista = idRevista;
            emprestimos.revistaEmprestada = revistaEmprestada;
            emprestimos.dataEmprestimo = dataEmprestimo;
            emprestimos.dataDevolucao = dataDevolucao;
            listaEmprestimos.Add(emprestimos);
        }
        public static bool VisualizarEmprestimos(bool existemEmprestimos)
        {
            Console.Clear();
            if (listaEmprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo cadastrado!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-8} | {4,-8}", "Id", "Nome Amigo", "Nome Revista", "Data Empréstimo", "Data Devolução");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Emprestimos e in listaEmprestimos)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-8} | {4,-8}", e.id, e.amigoEmprestou, e.revistaEmprestada, e.dataEmprestimo, e.dataDevolucao);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


            Console.ResetColor();

            return true;
        }
        public static void EditarEmprestimos()
        {
            bool existemEmprestimos = VisualizarEmprestimos(false);

            if (existemEmprestimos == false)
                return;

            Console.WriteLine();

            int id = EncontrarIdEmprestimo();

            Console.Write("Insira o nome do amigo que emprestou: ");
            string amigoEmprestou = Console.ReadLine();

            Console.Write("Insira o nome da revista: ");
            string revistaEmprestada = Console.ReadLine();

            Console.Write("Insira a data que foi emprestada: ");
            int dataEmprestimo = int.Parse(Console.ReadLine());

            string dataDevolucao = VerificarDevolucao();

            Emprestimos emprestimos = SelecionarEmprestimosComId(id);
            emprestimos.id = id;
            emprestimos.amigoEmprestou = amigoEmprestou;
            emprestimos.revistaEmprestada = revistaEmprestada;
            emprestimos.dataEmprestimo = dataEmprestimo;
            emprestimos.dataDevolucao = dataDevolucao;
        }
        public static void ExcluirEmprestimos()
        {

            bool existemEmprestimos = VisualizarEmprestimos(false);

            if (existemEmprestimos == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdEmprestimo();

            Emprestimos emprestimos = SelecionarEmprestimosComId(idExclusao);

            listaEmprestimos.Remove(emprestimos);

            Console.WriteLine("Empréstimo deletado!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ReadKey();
        }
        public static int EncontrarIdEmprestimo()
        {
            int idEmprestimo;
            bool idInvalido;

            do
            {
                Console.ResetColor();
                Console.Write("Insira o Id do empréstimo: ");

                idEmprestimo = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarEmprestimosComId(idEmprestimo) == null;

                if (idInvalido)
                    Console.WriteLine("Id do empréstimo não encontrada, tente novamente!!", Console.ForegroundColor = ConsoleColor.Red);

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
            Console.Write("A revista já foi devolvida (s/n)? ");
            string devolucao = Console.ReadLine();

            if (devolucao == "s")
            {
                Console.Write("Insira a data de devolução: ");
                dataDevolucao = Console.ReadLine();
            }
            else if (devolucao == "n")
            {
                dataDevolucao += "Não Devolvido";
            }

            return dataDevolucao;
        }
    }
}
