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
    internal class CadastrarEmprestimos
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
            Console.WriteLine("Digite 5 para Visualizar empréstimos de um mês -- NÃO IMPLEMENTADO");
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
            else if (opcaoCadastroEmprestimos == "5")
            {
                Console.Title = "Lista de Empréstimos";
                //EncontrarPorMes();
            }
        }
        public static void RegistrarEmprestimos()
        {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Insira o id do empréstimo: ");
            int id = int.Parse(Console.ReadLine());

            int idAmigo = CadastrarAmigos.EncontrarIdAmigo();

            Console.Write("Insira o nome do amigo que emprestou: ");
            string amigoEmprestou = Console.ReadLine();

            int idRevista = CadastrarRevistas.EncontrarIdRevista();

            Console.Write("Insira o nome da revista: ");
            string revistaEmprestada = Console.ReadLine();

            Console.Write("Insira o dia que foi emprestada: ");
            int dia = int.Parse(Console.ReadLine());       
            
            Console.Write("Insira o mes que foi emprestada: ");
            int mes = int.Parse(Console.ReadLine());            

            Console.Write("Insira o ano que foi emprestada: ");
            int ano = int.Parse(Console.ReadLine());
            DateTime dataEmprestimo = new DateTime(ano, mes, dia);

            string dataDevolucao = VerificarDevolucao();

            Emprestimos emprestimos = new Emprestimos();

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            int id = EncontrarIdEmprestimo();

            Console.Write("Insira o nome do amigo que emprestou: ");
            string amigoEmprestou = Console.ReadLine();

            Console.Write("Insira o nome da revista: ");
            string revistaEmprestada = Console.ReadLine();

            Console.Write("Insira o dia que foi emprestada: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Insira o mes que foi emprestada: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Insira o ano que foi emprestada: ");
            int ano = int.Parse(Console.ReadLine());

            DateTime dataEmprestimo = new DateTime(ano, mes, dia);

            string dataDevolucao = VerificarDevolucao();

            Emprestimos emprestimos = SelecionarEmprestimosComId(id);
            emprestimos.id = id;
            emprestimos.amigoEmprestou = amigoEmprestou;
            emprestimos.revistaEmprestada = revistaEmprestada;
            emprestimos.ano = ano;
            emprestimos.mes = mes;
            emprestimos.dia = dia;
            emprestimos.dataEmprestimo = dataEmprestimo;
            emprestimos.dataDevolucao = dataDevolucao;
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
                Console.Write("Insira o Id do empréstimo: ", Console.ForegroundColor = ConsoleColor.Yellow);

                idEmprestimo = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarEmprestimosComId(idEmprestimo) == null;

                if (idInvalido)
                    Console.WriteLine("Id do empréstimo não encontrada, tente novamente!!", Console.ForegroundColor = ConsoleColor.Red);

            } while (idInvalido);

            return idEmprestimo;
        }
        private static Emprestimos SelecionarEmprestimosComId(int id)
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
                dataDevolucao = "Devoldido";
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
        private static Emprestimos AcharEmprestimosMes(int mes)
        {
            Emprestimos emprestimos = null;

            foreach (Emprestimos e in listaEmprestimos)
            {
                if (e.mes == mes)
                {
                    emprestimos = e;
                    break;
                }
            }
            return emprestimos;
        }


    }
}
