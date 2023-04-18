using ClubeDaLeitura.ModuloCaixa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloCaixas
{
    public class RepositorioCaixas
    {
        public ArrayList listaCaixas = new ArrayList();

        public void Registrar(Caixas caixas)
        {
            listaCaixas.Add(caixas);
        }
        public void Editar(Caixas caixaEditar, string cor, string etiqueta)
        {
            caixaEditar.cor = cor;
            caixaEditar.etiqueta = etiqueta;
        }
        public void Excluir(int idSelecionado)
        {
            Caixas caixa = SelecionarCaixaComId(idSelecionado);

            listaCaixas.Remove(caixa);
        }
        public Caixas SelecionarCaixaComId(int id)
        {
            Caixas caixas = null;    
            foreach (var c in listaCaixas)
            {
                Caixas caixas2 = c as Caixas;
                if (caixas2.id == id)
                {
                    caixas = caixas2;
                    break;
                }
            }
            return caixas;
        }
    }
}
