using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmpréstimos;
using ClubeDaLeitura.ModuloRevistas;

RepositorioCaixas repositorioCaixas = new RepositorioCaixas();
RepositorioRevistas repositorioRevistas = new RepositorioRevistas();
RepositorioAmigos repositorioAmigos = new RepositorioAmigos();
RepositorioEmprestimos repositorioEmprestimos = new RepositorioEmprestimos();

TelaAmigos telaAmigos = new TelaAmigos(repositorioAmigos, repositorioEmprestimos);
TelaCaixas telaCaixas = new TelaCaixas(repositorioCaixas);
TelaRevistas telaRevistas = new TelaRevistas(repositorioRevistas, repositorioCaixas, telaCaixas);
TelaEmprestimos telaEmprestimos = new TelaEmprestimos(repositorioEmprestimos, repositorioCaixas, repositorioAmigos, repositorioRevistas, telaCaixas, telaAmigos, telaRevistas);

while (true)
{
    string opcao = ShowMenu();

    if (opcao == "9")
        break;

    if (opcao == "1")
    {
        Console.Title = "Cadastro de Caixas";
        string opcaoCadastroCaixas = telaCaixas.PainelCaixas();

        if (opcaoCadastroCaixas == "9")
            continue;

        telaCaixas.CadastroCaixas(opcaoCadastroCaixas);
    }
    else if (opcao == "2")
    {
        Console.Title = "Cadastro de Amigos";
        string opcaoCadastroAmigos = TelaAmigos.PainelAmigos();

        if (opcaoCadastroAmigos == "9")
            continue;

        telaAmigos.CadastroAmigos(opcaoCadastroAmigos);
    }
    else if (opcao == "3")
    {
        Console.Title = "Cadastro de Revistas";
        string opcaoCadastroRevistas = TelaRevistas.PainelRevistas();

        if (opcaoCadastroRevistas == "9")
            continue;

        telaRevistas.CadastroRevistas(opcaoCadastroRevistas);
    }
    else if (opcao == "4")
    {
        Console.Title = "Cadastro de Empréstimos";
        string opcaoCadastroEmprestimos = TelaEmprestimos.PainelEmprestimos();

        if (opcaoCadastroEmprestimos == "9")
            continue;

        telaEmprestimos.CadastroEmprestimos(opcaoCadastroEmprestimos);
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
