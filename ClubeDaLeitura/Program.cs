using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloEmpréstimos;
using ClubeDaLeitura.ModuloRevistas;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string opcao = ShowMenu();

                if (opcao == "9")
                    break;

                if (opcao == "1")
                {
                    Console.Title = "Cadastro de Caixas";
                    string opcaoCadastroCaixas = CadastrarCaixas.PainelCaixas(); 

                    if (opcaoCadastroCaixas == "9")
                        continue;

                    CadastrarCaixas.CadastroCaixas(opcaoCadastroCaixas);
                }
                else if (opcao == "2")
                {
                    Console.Title = "Cadastro de Amigos";
                    string opcaoCadastroAmigos = CadastrarAmigos.PainelAmigos(); 

                    if (opcaoCadastroAmigos == "9")
                        continue;

                    CadastrarAmigos.CadastroAmigos(opcaoCadastroAmigos);
                }                
                else if (opcao == "3")
                {
                    Console.Title = "Cadastro de Revistas";
                    string opcaoCadastroRevistas = CadastrarRevistas.PainelRevistas(); 

                    if (opcaoCadastroRevistas == "9")
                        continue;

                    CadastrarRevistas.CadastroRevistas(opcaoCadastroRevistas);
                }                
                else if (opcao == "4")
                {
                    Console.Title = "Cadastro de Empréstimos";
                    string opcaoCadastroEmprestimos = CadastrarEmprestimos.PainelEmprestimos(); 

                    if (opcaoCadastroEmprestimos == "9")
                        continue;

                    CadastrarEmprestimos.CadastroEmprestimos(opcaoCadastroEmprestimos);
                }
            }

            static string ShowMenu()
            {
                Console.Title = "Painel de Revistas do Caio - 0.1";
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("========================================");
                Console.WriteLine("         PAINEL DE REVISTAS 0.1");
                Console.WriteLine("========================================");
                Console.WriteLine("Digite 1 para o painel de caixas");
                Console.WriteLine("Digite 2 para o painel de amigos");
                Console.WriteLine("Digite 3 para o painel de revistas");
                Console.WriteLine("Digite 4 para o painel de empréstimos");
                Console.WriteLine("========================================");
                Console.WriteLine();
                Console.Write("Insira uma opção ou digite 9 PARA SAIR: ");
                Console.ResetColor();

                string opcao = Console.ReadLine();

                return opcao;
            }
        }
        public static void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ResetColor();
            Console.Write(mensagem, Console.ForegroundColor = cor);
        }
    }
}