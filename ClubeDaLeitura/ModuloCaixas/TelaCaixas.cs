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
    public class TelaCaixas
    {

        RepositorioCaixas repositorioCaixas;
        public TelaCaixas(RepositorioCaixas repositorioCaixas)
        {
            this.repositorioCaixas = repositorioCaixas;
        }

        public string PainelCaixas()
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
        public void CadastroCaixas(string opcaoCadastroDasCaixas)
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
        public void RegistrarCaixa()
        {
            Console.Clear();

            Tela.MostrarMensagem("Insira a cor da caixa: ", ConsoleColor.Yellow);
            string cor = Console.ReadLine();

            Tela.MostrarMensagem("Insira a etiqueta da caixa: ", ConsoleColor.Yellow);
            string etiqueta = Console.ReadLine();

            Caixas caixas = new Caixas(cor, etiqueta);

            repositorioCaixas.Registrar(caixas);
        }
        public void EditarCaixa()
        {
            bool existemCaixas = VisualizarCaixas(false);

            if (existemCaixas == false)
                return;

            Console.WriteLine();
            Caixas caixaEditar = repositorioCaixas.SelecionarCaixaComId(EncontrarIdCaixa());


            if(caixaEditar == null)
            {
                Tela.MostrarMensagem("Caixa não encontrada!", ConsoleColor.Red);
            }
            else
            {
                Tela.MostrarMensagem("Insira a cor da caixa: ", ConsoleColor.Yellow);
                string cor2 = Console.ReadLine();

                Tela.MostrarMensagem("Insira a etiqueta da caixa: ", ConsoleColor.Yellow);
                string etiqueta2 = Console.ReadLine();

                repositorioCaixas.Editar(caixaEditar, cor2, etiqueta2);
            }
        }
        private void ExcluirCaixa()
        {

            bool existemCaixas = VisualizarCaixas(false);

            if (existemCaixas == false)
                return;

            Console.WriteLine();

            int idExclusao = EncontrarIdCaixa();

            repositorioCaixas.Excluir(idExclusao);

            Tela.MostrarMensagem("Caixa excluída!", ConsoleColor.Red);
            Console.ReadKey();
        }
        public int EncontrarIdCaixa()
        {
            VisualizarCaixas(true);
            int id;

            Tela.MostrarMensagem("Insira o ID da caixa: ", ConsoleColor.Yellow);

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Tela.MostrarMensagem("ID da caixa não encontrado, tente novamente!", ConsoleColor.Red);
                Tela.MostrarMensagem("Insira o ID da caixa: ", ConsoleColor.Yellow);
            } 
            return id;
        }
        public bool VisualizarCaixas(bool existemCaixas)
        {
            Console.Clear();
            if (repositorioCaixas.listaCaixas.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrado!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-5} | {1,-15} | {2,-15}", "Id", "Cor", "Etiqueta");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Caixas c in repositorioCaixas.listaCaixas)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15}", c.id, c.cor, c.etiqueta);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            return true;
        }

    }
}
