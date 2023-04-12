using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    internal class CadastrarRevistas
    {
        static ArrayList listaRevistas = new ArrayList();

        public static string PainelRevistas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("            CADASTRO DE REVISTAS");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Digite 1 para Inserir uma nova revista");
            Console.WriteLine("Digite 2 para Visualizar revistas");
            Console.WriteLine("Digite 3 para Editar revistas");
            Console.WriteLine("Digite 4 para Excluir revistas");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.Write("Insira uma opção ou digite 9 PARA VOLTAR: ");
            Console.ResetColor();

            string opcao = Console.ReadLine(); //Função retorna o valor lido na Program 

            return opcao;
        }
        public static void CadastroRevistas(string opcaoCadastroRevistas)
        {
            if (opcaoCadastroRevistas == "1")
            {
                Console.Title = "Registro de Revistas";
                RegistrarRevistas();
            }
            else if (opcaoCadastroRevistas == "2")
            {
                Console.Title = "Lista de Revistas";
                bool existemRevistas = VisualizarRevistas(true);

                if (existemRevistas)
                    Console.ReadLine();
            }
            else if (opcaoCadastroRevistas == "3")
            {
                Console.Title = "Edição de Revistas";
                EditarRevistas();
            }
            else if (opcaoCadastroRevistas == "4")
            {
                Console.Title = "Exclusão de Revistas";
                ExcluirRevistas();
            }
        }
        public static void RegistrarRevistas()
        {
            Console.Clear();

            Console.Write("Insira o ID da revista: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Insira o nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Insira o número da edição: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Insira o ano da revista: ");
            int ano = int.Parse(Console.ReadLine());

            int caixaId = CadastrarCaixas.EncontrarIdCaixa(); //VERIFICA SE A CAIXA EXISTE

            Revistas revistas = new Revistas();

            revistas.id = id;
            revistas.nome = nome;
            revistas.numero = numero;
            revistas.ano = ano;
            revistas.caixaId = caixaId;
            listaRevistas.Add(revistas);
        }
        public static bool VisualizarRevistas(bool existemRevistas)
        {
            Console.Clear();
            if (listaRevistas.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4} | {1,-20} | {2,-6} | {3,-4} | {4,-5}", "Id", "Nome", "Número", "Ano", "Id da Caixa");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Revistas r in listaRevistas)
            {
                Console.WriteLine("{0,-4} | {1,-20} | {2,-6} | {3,-4} | {4,-5}", r.id, r.nome, r.numero, r.ano, r.caixaId);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            return true;
        }
        public static void EditarRevistas()
        {
            bool existemRevistas = VisualizarRevistas(false);

            if (existemRevistas == false)
                return;

            Console.WriteLine();

            int id = EncontrarIdRevista();

            Console.Write("Insira o nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Insira o número da edição: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Insira o ano da revista: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Insira em qual caixa esta a revista: ");
            int caixaId = int.Parse(Console.ReadLine()); 

            Revistas revistas = SelecionarRevistasComId(id);
            revistas.id = id;
            revistas.nome = nome;
            revistas.numero = numero;
            revistas.ano = ano;
            revistas.caixaId = caixaId;
        }
        public static void ExcluirRevistas()
        {

            bool existemRevistas = VisualizarRevistas(false);

            if (existemRevistas == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdExcluir();

            Revistas revistas = SelecionarRevistasComId(idExclusao);

            listaRevistas.Remove(revistas);

            Console.WriteLine("Revista excluída!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ReadKey();
        }
        public static int EncontrarIdRevista()
        {
            int idEditar;
            bool idInvalido;

            do
            {
                Console.ResetColor();
                Console.Write("Insira o Id da revista: ");

                idEditar = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarRevistasComId(idEditar) == null;

                if (idInvalido)
                    Console.WriteLine("Id da revista não encontrada, tente novamente!!", Console.ForegroundColor =  ConsoleColor.Red);

            } while (idInvalido);

            return idEditar;
        }
        public static int EncontrarIdExcluir()
        {
            int idExclusao;
            bool idInvalido;

            do
            {
                Console.Write("Insira o Id da revista que deseja excluir: ");

                idExclusao = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarRevistasComId(idExclusao) == null;

                if (idInvalido)
                    Console.WriteLine("Id da revista não encontrada, tente novamente!!", ConsoleColor.Red);

            } while (idInvalido);

            return idExclusao;
        }
        public static Revistas SelecionarRevistasComId(int id)
        {
            Revistas revistas = null;

            foreach (Revistas r in listaRevistas)
            {
                if (r.id == id)
                {
                    revistas = r;
                    break;
                }
            }
            return revistas;
        }
    }
}
