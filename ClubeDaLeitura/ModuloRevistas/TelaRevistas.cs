using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloAmigos;
using ClubeDaLeitura.ModuloCaixa;
using ClubeDaLeitura.ModuloCaixas;
using ClubeDaLeitura.ModuloEmpréstimos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class TelaRevistas
    {
        RepositorioRevistas repositorioRevistas;
        RepositorioCaixas repositorioCaixas;
        TelaCaixas telaCaixas;

        public TelaRevistas(RepositorioRevistas repositorioRevistas, RepositorioCaixas repositorioCaixas, TelaCaixas telaCaixas)
        {
            this.repositorioRevistas = repositorioRevistas;
            this.repositorioCaixas = repositorioCaixas;
            this.telaCaixas = telaCaixas;
        }

        public static string PainelRevistas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============================================");
            Console.WriteLine("            CADASTRO DE REVISTAS");
            Console.WriteLine("============================================");
            Console.WriteLine("Digite 1 para Inserir uma nova revista");
            Console.WriteLine("Digite 2 para Visualizar revistas");
            Console.WriteLine("Digite 3 para Editar revistas");
            Console.WriteLine("Digite 4 para Excluir revistas");
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("Insira uma opção ou digite 9 PARA VOLTAR: ");
            Console.ResetColor();

            string opcao = Console.ReadLine(); //Função retorna o valor lido na Program 

            return opcao;
        }
        public void CadastroRevistas(string opcaoCadastroRevistas)
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
        public void RegistrarRevistas()
        {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Insira o nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Insira o número da edição: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Insira o ano da revista: ");
            int ano = int.Parse(Console.ReadLine());

            Caixas caixaRevista = repositorioCaixas.SelecionarCaixaComId(telaCaixas.EncontrarIdCaixa());
            if(caixaRevista == null)
            {
                Tela.MostrarMensagem("Caixa não encontrada!", ConsoleColor.Red);
            }
            else 
            { 
                Console.Write("Insira o ID da caixa desejada: ");
            }

            Revistas revistas = new Revistas(nome, numero, ano , caixaRevista);
            repositorioRevistas.Registrar(revistas);
        }
        public bool VisualizarRevistas(bool existemRevistas)
        {
            Console.Clear();
            if (repositorioRevistas.listaRevistas.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrada!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-4} | {1,-20} | {2,-6} | {3,-4} | {4,-5}", "Id", "Nome", "Número", "Ano", "Etiqueta da Caixa");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Revistas r in repositorioRevistas.listaRevistas)
            {
                Console.WriteLine("{0,-4} | {1,-20} | {2,-6} | {3,-4} | {4,-5}", r.id, r.nome, r.numero, r.ano, r.caixas.etiqueta);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            return true;
        }
        public void EditarRevistas()
        {
            bool existemRevistas = VisualizarRevistas(false);

            if (existemRevistas == false)
                return;

            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Revistas revistaEditar = repositorioRevistas.SelecionarRevistasComId(EncontrarIdRevista());


            Console.Write("Insira o nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Insira o número da edição: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Insira o ano da revista: ");
            int ano = int.Parse(Console.ReadLine());

            Caixas caixaRevista = repositorioCaixas.SelecionarCaixaComId(telaCaixas.EncontrarIdCaixa());
            repositorioRevistas.Editar(revistaEditar, nome, numero, ano, caixaRevista);

        }
        private void ExcluirRevistas()
        {

            bool existemRevistas = VisualizarRevistas(false);

            if (existemRevistas == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdExcluir();

            repositorioRevistas.Excluir(idExclusao);

            Console.WriteLine("Revista excluída!", Console.ForegroundColor = ConsoleColor.Red);
            Console.ReadKey();
        }
        public int EncontrarIdRevista()
        {
            VisualizarRevistas(true);

            int idEncontrado;
            bool idInvalido;
            do
            {
                Console.Write("Insira o Id da revista: ", Console.ForegroundColor = ConsoleColor.Yellow);
                idEncontrado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioRevistas.SelecionarRevistasComId(idEncontrado) == null;

                if (idInvalido)
                    Console.WriteLine("Id da revista não encontrada, tente novamente!!", Console.ForegroundColor =  ConsoleColor.Red);

            } while (idInvalido);

            return idEncontrado;
        }
        private int EncontrarIdExcluir()
        {
            int idExclusao;
            bool idInvalido;

            do
            {
                Console.Write("Insira o Id da revista que deseja excluir: ", Console.ForegroundColor = ConsoleColor.Yellow);

                idExclusao = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioRevistas.SelecionarRevistasComId(idExclusao) == null;

                if (idInvalido)
                    Console.WriteLine("Id da revista não encontrada, tente novamente!!", ConsoleColor.Red);

            } while (idInvalido);

            return idExclusao;
        }


    }
}
