using ProvaFuncional.Compatilhado;
using ProvaFuncional.MóduloGarçon;
using ProvaFuncional.MóduloMesa;
using ProvaFuncional.MóduloProduto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloConta
{
    public class TelaConta : TelaBase
    {
        RepositorioConta repositorioConta = null;
        RepositorioMesa repositorioMesa = null;
        RepositorioProduto repositorioProduto = null;
        RepositorioGarcom repositorioGarcom = null;
        TelaMesa telaMesa = null;
        TelaGarcom telaGarcom = null;
        TelaProduto telaProduto = null;
        public TelaConta(RepositorioConta repositorioConta, RepositorioMesa repositorioMesa, RepositorioProduto repositorioProduto, RepositorioGarcom repositorioGarcom, TelaGarcom telaGarcom, TelaMesa telaMesa, TelaProduto telaProduto)
        {
            this.repositorioMesa = repositorioMesa;
            this.repositorioConta = repositorioConta;
            this.repositorioBase = repositorioConta;
            this.repositorioProduto = repositorioProduto;
            this.repositorioGarcom = repositorioGarcom;
            this.telaGarcom = telaGarcom;
            this.telaMesa = telaMesa;
            this.telaProduto = telaProduto;

        }

        public override string ApresentarMenu()
        {

            Console.Clear();

            Console.WriteLine($"Cadastro de contas \n");

            Console.WriteLine($"Digite 1 para Abrir uma conta ");
            Console.WriteLine($"Digite 2 para registrar pedidos ");
            Console.WriteLine($"Digite 3 para fechar uma conta");
            Console.WriteLine($"Digite 4 para vizualizar contas abertas ");
            Console.WriteLine($"Digite 5 para vizualizar fatura total do dia ");
            Console.WriteLine($"Digite 6 para vizualizar contas ");
            Console.WriteLine($"Digite 7 para editar uma conta ");
            Console.WriteLine($"Digite 8 para exclur uma conta ");
            Console.WriteLine($"Digite 9 para calcular os pedidos da conta ");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}", "Id", "Mesa", "Garçom", "Status");

            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (Conta conta in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}|{3, -20}", conta.id, conta.mesa.id, conta.Garcom.nome, conta.Status);
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {


            telaMesa.VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id da mesa que a conta pertence: ");
            int idMesa = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");
            telaGarcom.VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id do garçom que recebeu a conta: ");
            int idGarcom = int.Parse(Console.ReadLine());

            Mesa mesa = (Mesa)repositorioMesa.SelecionarPorId(idMesa);
            Garcom garcom = (Garcom)repositorioGarcom.SelecionarPorId(idGarcom);

            return new Conta(mesa, garcom);
        }

        public override void InserirNovoRegistro()
        {

            Console.WriteLine($"Abrindo uma nova conta...");

            EntidadeBase registro = ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro();

                return;
            }

            repositorioBase.Inserir(registro);

            MostrarMensagem("Conta aberta com sucesso!", ConsoleColor.Green);
        }

        public void RegistrarPedido()
        {
            VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id da conta: ");
            int id = int.Parse(Console.ReadLine());
            Conta conta = (Conta)repositorioBase.SelecionarPorId(id);

            Console.WriteLine("\n");
            telaProduto.VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id do produto desejado: ");
            int idProduto = int.Parse(Console.ReadLine());

            Produto produto = (Produto)repositorioProduto.SelecionarPorId(idProduto);

            Console.WriteLine("\nDigite a quantidade: ");
            int quantidade = int.Parse(Console.ReadLine());

            conta.AdicionarPedido(produto, quantidade);
        }

        public void VisualizarContasAbertas()
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}| {3, -20}", "Id", "Mesa", "Garçom", "Status");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (Conta conta in repositorioConta.listaRegistros)
            {
                if (conta.Status == "Aberto")
                {
                    Console.WriteLine("{0, -10} | {1, -20} | {2, -20}|{3, -20}", conta.id, conta.mesa.id, conta.Garcom.nome, conta.Status);
                }
            }
            Console.ReadLine();
        }

        public void VisualizarFaturaTotalDoDia()
        {
            double totalFaturado = repositorioConta.CalcularPedidosDoDia();
            Console.WriteLine("O total faturado do dia foi $" + totalFaturado);
            Console.ReadLine();
        }

        public void CalcularPedidosDaConta()
        {
            VisualizarRegistros(false);

            Console.WriteLine("\nDigite o Id da conta para calcular os pedidos: ");
            int idConta = int.Parse(Console.ReadLine());

            VisualizarRegistros(false);
            Conta conta = (Conta)repositorioConta.SelecionarPorId(idConta);

            double pedidosCalculados = conta.CalcularPedidos();

            Console.WriteLine("O valor total dos pedidos é: " + pedidosCalculados);

            Console.ReadLine();
        }

        public void FechaConta()
        {
            Console.WriteLine("Digite o ID da Conta a fechar: ");
            int id = int.Parse(Console.ReadLine());

            Conta conta = (Conta)repositorioConta.SelecionarPorId(id);

            conta.Status = "Fechada";

            MostrarMensagem("Conta fechada com sucesso!", ConsoleColor.Green);
        }
    }
}
