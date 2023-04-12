using ClubeDaLeitura.ModuloCaixa;

namespace ClubeDaLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string opcao = ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    Console.Title = "Cadastro de Caixas";
                    string opcaoCadastroCaixas = CadastrarCaixas.PainelCaixas(); //IR PARA O PAINEL DE CAIXAS

                    if (opcaoCadastroCaixas == "9")
                        continue;

                    CadastrarCaixas.CadastrarCaixa(opcaoCadastroCaixas);
                }
                //else if (opcao == "2")
                //{
                    //painel revistas
                //}
            }



            static string ApresentarMenu()
            {
                Console.Title = "Painel de Revistas do Caio - 0.1";
                Console.Clear();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("         PAINEL DE REVISTAS 0.1");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Digite 1 para o painel de caixas");
                Console.WriteLine("Digite 2 para o painel de revistas - não implementado");
                Console.WriteLine("Digite 3 para o painel de amigos - não implementado");
                Console.WriteLine("Digite 4 para o painel de empréstimos - não implementado");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Digite 9 para Sair");
                Console.ResetColor();

                string opcao = Console.ReadLine();

                return opcao;
            }
        }
    }
}