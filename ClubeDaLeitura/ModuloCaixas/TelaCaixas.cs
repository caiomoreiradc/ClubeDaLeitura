using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    internal class TelaCaixas
    {
        private static ArrayList listaCaixas = new ArrayList();

        public static string PainelCaixas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;   
            Console.WriteLine("============================================");
            Console.WriteLine("            CADASTRO DE CAIXAS");
            Console.WriteLine("============================================");
            Console.WriteLine("Digite 1 para Inserir uma nova caixa");
            Console.WriteLine("Digite 2 para Visualizar caixas");
            Console.WriteLine("Digite 3 para Editar caixas");
            Console.WriteLine("Digite 4 para Excluir caixas");
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("Insira uma opção ou digite 9 PARA VOLTAR: ");
            Console.ResetColor();

            string opcao = Console.ReadLine(); 

            return opcao;
        }
        public static void CadastroCaixas(string opcaoCadastroDasCaixas)
        {
            if (opcaoCadastroDasCaixas == "1")
            {
                Console.Title = "Registro de Caixas";
                RegistrarCaixa();
            }
            else if (opcaoCadastroDasCaixas == "2")
            {
                Console.Title = "Caixas disponíveis";
                bool existemCaixas = VisualizarCaixas(true);

                if (existemCaixas)
                    Console.ReadLine();
            }
            else if(opcaoCadastroDasCaixas == "3")
            {
                Console.Title = "Edição de Caixas";
                EditarCaixa();
            }
            else if(opcaoCadastroDasCaixas=="4") 
            {
                Console.Title = "Exclusão de Caixas";
                ExcluirCaixa();
            }
        }
        private static void RegistrarCaixa()
        {
            Console.Clear();
            Tela.MostrarMensagem("Insira o ID da caixa: ", ConsoleColor.Yellow);
            int id = int.Parse(Console.ReadLine());

            Tela.MostrarMensagem("Insira a cor da caixa: ", ConsoleColor.Yellow);
            string cor = Console.ReadLine();

            Tela.MostrarMensagem("Insira a etiqueta da caixa: ", ConsoleColor.Yellow);
            string etiqueta = Console.ReadLine();

            Caixas caixas = new Caixas();

            RepositorioCaixas.Registrar(caixas, id, cor, etiqueta);
            listaCaixas.Add(caixas);
        }
        private static void EditarCaixa()
        {
            bool existemCaixas = VisualizarCaixas(false);

            if (existemCaixas == false)
                return;

            Console.WriteLine();
            Tela.MostrarMensagem("Insira o ID da caixa que deseja editar: ", ConsoleColor.Yellow);
            int id = int.Parse(Console.ReadLine());

            Tela.MostrarMensagem("Insira a cor da caixa: ", ConsoleColor.Yellow);
            string cor = Console.ReadLine();

            Tela.MostrarMensagem("Insira a etiqueta da caixa: ", ConsoleColor.Yellow);
            string etiqueta = Console.ReadLine();


            RepositorioCaixas.Editar(id, cor, etiqueta);
        }
        private static void ExcluirCaixa()
        {

            bool existemCaixas = VisualizarCaixas(false);

            if (existemCaixas == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdCaixa();

            Caixas caixa = SelecionarCaixaComId(idExclusao);

            listaCaixas.Remove(caixa);

            Tela.MostrarMensagem("Caixa excluída!", ConsoleColor.Red);
            Console.ReadKey();
        }
        public static int EncontrarIdCaixa()
        {
            int idExclusao;
            bool idInvalido;

            do
            {
                Tela.MostrarMensagem("Insira o ID da caixa: ", ConsoleColor.Yellow);
                idExclusao = Convert.ToInt32(Console.ReadLine());
                idInvalido = SelecionarCaixaComId(idExclusao) == null;

                if (idInvalido)
                    Tela.MostrarMensagem("ID da caixa não encontrado, tente novamente!", ConsoleColor.Red);

            } while (idInvalido);

            return idExclusao;
        }
        private static bool VisualizarCaixas(bool existemCaixas)
        {
            Console.Clear();
            if (listaCaixas.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrado!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-15} | {2,-15}", "Id", "Cor", "Etiqueta");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Caixas c in listaCaixas)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15}", c.id, c.cor, c.etiqueta);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            return true;
        }
        public static Caixas SelecionarCaixaComId(int id)
        {
            Caixas caixas = null;

            foreach (Caixas c in listaCaixas)
            {
                if (c.id == id)
                {
                    caixas = c;
                    break;
                }
            }
            return caixas;
        }
    }
}
