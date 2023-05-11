using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloMesa
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }


        protected override void MostrarTabela(ArrayList mesas)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Quantidade de Pessoas", "Localização", "Status");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Mesa mesa in mesas)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", mesa.id, mesa.quantidadeDeClientes, mesa.localizacao, mesa.status);
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite a quantidade de pessoas: ");
            int quantidadeDeClientes = int.Parse(Console.ReadLine());

            Console.Write("Digite a localização: ");
            string localizacao = Console.ReadLine();

            Console.Write("Digite o status: ");
            string status = Console.ReadLine();


            return new Mesa(quantidadeDeClientes, localizacao, status);
        }
    }
}
