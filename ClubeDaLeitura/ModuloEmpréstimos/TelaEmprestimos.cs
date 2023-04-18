using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloCaixas;
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
    public class TelaEmprestimos
    {
        RepositorioEmprestimos repositorioEmprestimos;
        RepositorioCaixas repositorioCaixas;
        RepositorioAmigos repositorioAmigos;
        RepositorioRevistas repositorioRevistas;
        TelaCaixas telaCaixas;
        TelaAmigos telaAmigos;
        TelaRevistas telaRevistas;

        public TelaEmprestimos(RepositorioEmprestimos repositorioEmprestimos, RepositorioCaixas repositorioCaixas, RepositorioAmigos repositorioAmigos, RepositorioRevistas repositorioRevistas, TelaCaixas telaCaixas, TelaAmigos telaAmigos, TelaRevistas telaRevistas)
        {
            this.repositorioEmprestimos = repositorioEmprestimos;
            this.repositorioCaixas = repositorioCaixas;
            this.repositorioAmigos = repositorioAmigos;
            this.repositorioRevistas = repositorioRevistas;
            this.telaCaixas = telaCaixas;
            this.telaAmigos = telaAmigos;
            this.telaRevistas = telaRevistas;
        }

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
        public void CadastroEmprestimos(string opcaoCadastroEmprestimos)
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
        public void RegistrarEmprestimos()
        {
            Console.Clear();

            
            Amigos amigoEmprestou = repositorioAmigos.SelecionarAmigosComId(telaAmigos.EncontrarIdAmigo());

            Revistas revistaEmprestada = repositorioRevistas.SelecionarRevistasComId(telaRevistas.EncontrarIdRevista());

            Tela.MostrarMensagem("Insira a data em que foi emprestada: ", ConsoleColor.Yellow);
            string dataEmprestimo = Convert.ToInt64(Console.ReadLine()).ToString(@"00/00/0000");

            string dataDevolucao = VerificarDevolucao();

            Emprestimos emprestimos = new Emprestimos(amigoEmprestou, revistaEmprestada, dataEmprestimo, dataDevolucao);

            repositorioEmprestimos.Registrar(emprestimos);
        }
        private bool VisualizarEmprestimos(bool existemEmprestimos)
        {
            Console.Clear();
            if (repositorioEmprestimos.listaEmprestimos.Count == 0)
            {
                Console.WriteLine("Nenhum empréstimo cadastrado!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-8} | {4,-8}", "Id", "Nome Amigo", "Nome Revista", "Data Empréstimo", "Data Devolução");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Emprestimos e in repositorioEmprestimos.listaEmprestimos)
            {
                Console.WriteLine("{0,-5} | {1,-25} | {2,-20} | {3,-8} | {4,-8}", e.id, e.amigos.nome, e.revistas.nome, e.dataEmprestimo, e.dataDevolucao);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


            Console.ResetColor();

            return true;
        }
        private void EditarEmprestimos()
        {
            bool existemEmprestimos = VisualizarEmprestimos(false);

            if (existemEmprestimos == false)
                return;

            Console.WriteLine();
            Console.ResetColor();
            Emprestimos emprestimoEditar = repositorioEmprestimos.SelecionarEmprestimosComId(EncontrarIdEmprestimo());

            Tela.MostrarMensagem("Insira o nome do amigo que emprestou: ", ConsoleColor.Yellow);
            string amigoEmprestou = Console.ReadLine();

            Tela.MostrarMensagem("Insira o nome da revista: ", ConsoleColor.Yellow);
            string revistaEmprestada = Console.ReadLine();

            Tela.MostrarMensagem("Insira a data de emprestimo: ", ConsoleColor.Yellow);
            string dataEmprestimo = Convert.ToInt64(Console.ReadLine()).ToString(@"00/00/0000");


            string dataDevolucao = VerificarDevolucao();
            repositorioEmprestimos.Editar(emprestimoEditar, amigoEmprestou, revistaEmprestada, dataEmprestimo, dataDevolucao);

        }
        private void ExcluirEmprestimos()
        {

            bool existemEmprestimos = VisualizarEmprestimos(false);

            if (existemEmprestimos == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdEmprestimo();

            Emprestimos emprestimos = repositorioEmprestimos.SelecionarEmprestimosComId(idExclusao);

            repositorioEmprestimos.listaEmprestimos.Remove(emprestimos);

            Tela.MostrarMensagem("Empréstimo deletado!!", ConsoleColor.Red); 
            Console.ReadKey();
        }
        public int EncontrarIdEmprestimo()
        {
            int idEmprestimo;
            bool idInvalido;

            do
            {
                Tela.MostrarMensagem("Insira o ID do empréstimo: ", ConsoleColor.Yellow);

                idEmprestimo = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioEmprestimos.SelecionarEmprestimosComId(idEmprestimo) == null;

                if (idInvalido)
                    Tela.MostrarMensagem("ID do empréstimo não encontrado, tente novamente!!", ConsoleColor.Red);
            } while (idInvalido);

            return idEmprestimo;
        }
        private string VerificarDevolucao()
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

    }
}
