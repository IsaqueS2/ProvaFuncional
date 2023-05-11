using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloProduto
{
    public class TelaProduto : TelaBase
    {

        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }



        protected override void MostrarTabela(ArrayList produtos)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Valor");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Produto produto in produtos)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", produto.id, produto.nome, produto.valor);
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o valor: ");
            double valor = double.Parse(Console.ReadLine());




            return new Produto(nome, valor);
        }
    }
}
