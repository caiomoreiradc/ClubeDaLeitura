using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixa
{
    internal class CadastrarCaixas
    {
        static int contadorCaixas = 1;

        static ArrayList listaCaixas = new ArrayList();

        public static string PainelCaixas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;   
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("          CADASTRO DE CAIXAS");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Digite 1 para Inserir uma nova caixa");
            Console.WriteLine("Digite 2 para Visualizar caixas");
            Console.WriteLine("Digite 3 para Editar caixas");
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();
            //Console.WriteLine("Digite 4 para Excluir Equipamentos");
            //Console.WriteLine("Digite v para voltar para o menu principal");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public static void CadastrarCaixa(string opcaoCadastroDasCaixas)
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
        }
        public static void RegistrarCaixa()
        {
            Console.Clear();
            Console.Write("Insira o id da caixa: ");
            int id = int.Parse(Console.ReadLine());    
            
            Console.Write("Insira a cor da caixa: ");
            string cor = Console.ReadLine();         
            
            Console.Write("Insira a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Caixas caixas = new Caixas();
            
            caixas.id = id;
            caixas.cor = cor;
            caixas.etiqueta = etiqueta;
            listaCaixas.Add(caixas);
        }        

        public static void EditarCaixa()
        {
            Console.Write("Insira o id da caixa que deseja editar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Insira a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Insira a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Caixas caixas = SelecionarCaixaComId(id);
            caixas.id = id;
            caixas.cor = cor;
            caixas.etiqueta = etiqueta;
        }

        public static bool VisualizarCaixas(bool existemCaixas)
        {
            if (listaCaixas.Count == 0)
            {
                Console.WriteLine("Nenhum equipamento cadastrado!", Console.ForegroundColor = ConsoleColor.Red);
                Console.ReadKey();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", "Id", "Cor", "Etiqueta");

            Console.WriteLine("--------------------------------------------------------------------------");

            foreach (Caixas c in listaCaixas)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30}", c.id, c.cor, c.etiqueta);
            }

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
        static void IncrementarContador()
        {
            contadorCaixas++;
        }
    }
}
