using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloGarçon
{
    public class TelaGarcom : TelaBase

    {
        public TelaGarcom(RepositorioGarcom repositorioGarcom)
        {
            repositorioBase = repositorioGarcom;
            nomeEntidade = "Garçon";
            sufixo = "s";
        }



        protected override void MostrarTabela(ArrayList garcons)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Garcom garcom in garcons)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}", garcom.id, garcom.nome, garcom.telefone, garcom.idade);
            }
            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());


            return new Garcom(nome, telefone, idade);
        }
    }

}
