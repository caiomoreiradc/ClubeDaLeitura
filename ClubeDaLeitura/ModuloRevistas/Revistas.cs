using ClubeDaLeitura.Compartilhado;
using ClubeDaLeitura.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ModuloRevistas
{
    public class Revistas : Entidade
    {
        public static int contadorId = 1;
        public string nome;
        public int numero;
        public int ano;
        public Caixas caixas;
        public Revistas()
        {
            
        }

        public Revistas(string nome, int numero, int ano, Caixas caixas)
        {
            id = contadorId++;
            this.nome = nome;
            this.numero = numero;
            this.ano = ano;
            this.caixas = caixas;
        }

        public Caixas Caixa;
    }
}
