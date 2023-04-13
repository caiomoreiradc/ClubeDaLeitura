using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloEmpréstimos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    internal class CadastrarAmigos
    {
        private static ArrayList listaAmigos = new ArrayList();

        public static string PainelAmigos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============================================");
            Console.WriteLine("            CADASTRO DE AMIGOS");
            Console.WriteLine("============================================");
            Console.WriteLine("Digite 1 para Inserir um(a) novo(a) amigo(a)");
            Console.WriteLine("Digite 2 para Visualizar amigos");
            Console.WriteLine("Digite 3 para Editar amigos");
            Console.WriteLine("Digite 4 para Excluir amigos");
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("Insira uma opção ou digite 9 PARA VOLTAR: ");
            Console.ResetColor();

            string opcao = Console.ReadLine(); //Função retorna o valor lido na Program 

            return opcao;
        }
        public static void CadastroAmigos(string opcaoCadastroAmigos)
        {
            if (opcaoCadastroAmigos == "1")
            {
                Console.Title = "Registro de Amigos";
                RegistrarAmigos();
            }
            else if (opcaoCadastroAmigos == "2")
            {
                Console.Title = "Lista de Amigos";
                bool existemAmigos = VisualizarAmigos(true);

                if (existemAmigos)
                    Console.ReadLine();
            }
            else if (opcaoCadastroAmigos == "3")
            {
                Console.Title = "Edição de Amigos";
                EditarAmigos();
            }
            else if (opcaoCadastroAmigos == "4")
            {
                Console.Title = "Exclusão de Amigos";
                ExcluirAmigos();
            }
        }
        private static void RegistrarAmigos()
        {
            Console.Clear();
            Program.MostrarMensagem("Insira o ID do amigo: ", ConsoleColor.Yellow);
            int id = int.Parse(Console.ReadLine());

            Program.MostrarMensagem("Insira o nome do amigo: ", ConsoleColor.Yellow);
            string nome = Console.ReadLine();

            Program.MostrarMensagem("Insira o nome do responsável: ", ConsoleColor.Yellow);
            string nomeResponsavel = Console.ReadLine();

            Program.MostrarMensagem("Insira o telefone do amigo: ", ConsoleColor.Yellow);
            double telefone = double.Parse(Console.ReadLine());
            string telefoneFormatado = Convert.ToInt64(telefone).ToString(@"(00)00000-0000"); //FORMATA O TELEFONE

            Program.MostrarMensagem("Insira o endereço do amigo: ", ConsoleColor.Yellow);
            string endereco = Console.ReadLine();

            Amigos amigos = new Amigos();

            amigos.id = id;
            amigos.nome = nome;
            amigos.nomeResponsavel = nomeResponsavel;
            amigos.telefone = telefone;
            amigos.telefoneFormatado = telefoneFormatado;
            amigos.endereco = endereco;
            listaAmigos.Add(amigos);
        }
        private static bool VisualizarAmigos(bool existemAmigos)
        {
            Console.Clear();
            if (listaAmigos.Count == 0)
            {
                Console.WriteLine("Nenhum(a) amigo(a) cadastrado(a)!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-14} | {4,-40}", "Id", "Nome", "Nome do Responsável", "Telefone", "Endereço");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


            foreach (Amigos a in listaAmigos)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-14} | {4,-40}", a.id, a.nome, a.nomeResponsavel, a.telefoneFormatado, a.endereco);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            return true;
        }
        private static void EditarAmigos()
        {
            bool existemAmigos = VisualizarAmigos(false);

            if (existemAmigos == false)
                return;

            Console.WriteLine();
            Program.MostrarMensagem("Insira o ID do amigo que deseja editar: ", ConsoleColor.Yellow);
            int id = int.Parse(Console.ReadLine());

            Program.MostrarMensagem("Insira o nome do amigo: ", ConsoleColor.Yellow);
            string nome = Console.ReadLine();

            Program.MostrarMensagem("Insira o nome do responsável: ", ConsoleColor.Yellow);
            string nomeResponsavel = Console.ReadLine();

            Program.MostrarMensagem("Insira o telefone do amigo: ", ConsoleColor.Yellow);
            double telefone = double.Parse(Console.ReadLine());
            string telefoneFormatado = Convert.ToInt64(telefone).ToString(@"(00)00000-0000"); //FORMATA O TELEFONE

            Program.MostrarMensagem("Insira o endereço do amigo: ", ConsoleColor.Yellow);
            string endereco = Console.ReadLine();

            Amigos amigos = SelecionarAmigosComId(id);
            amigos.id = id;
            amigos.nome = nome;
            amigos.nomeResponsavel = nomeResponsavel;
            amigos.telefone = telefone;
            amigos.telefoneFormatado = telefoneFormatado;
            amigos.endereco = endereco;
        }
        private static void ExcluirAmigos()
        {

            bool existemAmigos = VisualizarAmigos(false);

            if (existemAmigos == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdAmigo();

            Amigos amigos = SelecionarAmigosComId(idExclusao);

            listaAmigos.Remove(amigos);

            Program.MostrarMensagem("Amigo excluído!", ConsoleColor.Red);

            Console.ReadKey();
        }
        public static int EncontrarIdAmigo()
        {
            int idExclusao;
            bool idInvalido;
            bool idTemEmprestimo;
            do
            {
                Program.MostrarMensagem("Insira o ID do amigo: ", ConsoleColor.Yellow);
                idExclusao = Convert.ToInt32(Console.ReadLine());

                idInvalido = SelecionarAmigosComId(idExclusao) == null;

                if (idInvalido)
                    Program.MostrarMensagem("ID do amigo não encontrado, tente novamente!!: ", ConsoleColor.Yellow);

                idTemEmprestimo = CadastrarEmprestimos.VerificarEmprestimos(idExclusao) != null; //VERIFICA 1 EMPRÉSTIMO POR AMIGO

                if (idTemEmprestimo)
                    Program.MostrarMensagem("Este amigo já tem um empréstimo em aberto, tente novamente!!", ConsoleColor.Yellow);

            } while (idInvalido || idTemEmprestimo);

            return idExclusao;
        }
        private static Amigos SelecionarAmigosComId(int id)
        {
            Amigos amigos = null;

            foreach (Amigos a in listaAmigos)
            {
                if (a.id == id)
                {
                    amigos = a;
                    break;
                }
            }
            return amigos;
        }

    }
}
