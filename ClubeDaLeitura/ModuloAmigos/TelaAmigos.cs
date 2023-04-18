using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmpréstimos;
using ClubeDaLeitura.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloAmigos
{
    public class TelaAmigos
    {
        RepositorioAmigos repositorioAmigos;
        RepositorioEmprestimos repositorioEmprestimos;

        public TelaAmigos(RepositorioAmigos repositorioAmigos, RepositorioEmprestimos repositorioEmprestimos)
        {
            this.repositorioAmigos = repositorioAmigos;
            this.repositorioEmprestimos = repositorioEmprestimos;
        }
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

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void CadastroAmigos(string opcaoCadastroAmigos)
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
        public void RegistrarAmigos()
        {
            Console.Clear();
            Tela.MostrarMensagem("Insira o nome do amigo: ", ConsoleColor.Yellow);
            string nome = Console.ReadLine();

            Tela.MostrarMensagem("Insira o nome do responsável: ", ConsoleColor.Yellow);
            string nomeResponsavel = Console.ReadLine();

            Tela.MostrarMensagem("Insira o telefone do amigo: ", ConsoleColor.Yellow);
            double telefone = double.Parse(Console.ReadLine());
            string telefoneFormatado = Convert.ToInt64(telefone).ToString(@"(00)00000-0000"); //FORMATA O TELEFONE

            Tela.MostrarMensagem("Insira o endereço do amigo: ", ConsoleColor.Yellow);
            string endereco = Console.ReadLine();

            Amigos amigos = new Amigos(nome, nomeResponsavel, telefone, telefoneFormatado, endereco);

            repositorioAmigos.Registrar(amigos);

        }
        public bool VisualizarAmigos(bool existemAmigos)
        {
            Console.Clear();
            if (repositorioAmigos.listaAmigos.Count == 0)
            {
                Console.WriteLine("Nenhum(a) amigo(a) cadastrado(a)!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-14} | {4,-40}", "Id", "Nome", "Nome do Responsável", "Telefone", "Endereço");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


            foreach (Amigos a in repositorioAmigos.listaAmigos)
            {
                Console.WriteLine("{0,-5} | {1,-20} | {2,-25} | {3,-14} | {4,-40}", a.id, a.nome, a.nomeResponsavel, a.telefoneFormatado, a.endereco);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            return true;
        }
        public void EditarAmigos()
        {
            bool existemAmigos = VisualizarAmigos(false);

            if (existemAmigos == false)
                return;
            Console.WriteLine();

            Amigos amigoEditar = repositorioAmigos.SelecionarAmigosComId(EncontrarIdAmigo());

            Tela.MostrarMensagem("Insira o nome do amigo: ", ConsoleColor.Yellow);
            string nome = Console.ReadLine();

            Tela.MostrarMensagem("Insira o nome do responsável: ", ConsoleColor.Yellow);
            string nomeResponsavel = Console.ReadLine();

            Tela.MostrarMensagem("Insira o telefone do amigo: ", ConsoleColor.Yellow);
            double telefone = double.Parse(Console.ReadLine());
            string telefoneFormatado = Convert.ToInt64(telefone).ToString(@"(00)00000-0000"); //FORMATA O TELEFONE

            Tela.MostrarMensagem("Insira o endereço do amigo: ", ConsoleColor.Yellow);
            string endereco = Console.ReadLine();


            repositorioAmigos.Editar(amigoEditar, nome, nomeResponsavel, telefone, telefoneFormatado, endereco);
        }
        public void ExcluirAmigos()
        {
            bool existemAmigos = VisualizarAmigos(false);

            if (existemAmigos == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdAmigo();

            repositorioAmigos.Excluir(idSelecionado);

            Tela.MostrarMensagem("Amigo excluído!", ConsoleColor.Red);

            Console.ReadKey();
        }
        public int EncontrarIdAmigo()
        {
            VisualizarAmigos(true);

            int idEncontrado;
            bool idInvalido;
            bool idTemEmprestimo;
            do
            {
                Tela.MostrarMensagem("Insira o ID do amigo: ", ConsoleColor.Yellow);
                idEncontrado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioAmigos.SelecionarAmigosComId(idEncontrado) == null;

                if (idInvalido)
                    Tela.MostrarMensagem("ID do amigo não encontrado, tente novamente!! - ", ConsoleColor.Red);

                idTemEmprestimo = VerificarEmprestimos(idEncontrado) != null; //VERIFICA 1 EMPRÉSTIMO POR AMIGO

                if (idTemEmprestimo)
                    Tela.MostrarMensagem("Este amigo já tem um empréstimo em aberto, tente novamente!!", ConsoleColor.Yellow);

            } while (idInvalido || idTemEmprestimo);

            return idEncontrado;
        }

        public Emprestimos VerificarEmprestimos(int id)
        {
            Emprestimos emprestimos = null;

            foreach (var e in repositorioEmprestimos.listaEmprestimos)
            {
                Emprestimos emprestimos2 = e as Emprestimos;
                if (emprestimos2.amigos.id == id)
                {
                    emprestimos = emprestimos2;
                    break;
                }
            }
            return emprestimos;
        }
    }
}
