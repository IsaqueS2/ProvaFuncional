using ProvaFuncional.MóduloConta;
using ProvaFuncional.MóduloGarçon;
using ProvaFuncional.MóduloMesa;
using ProvaFuncional.MóduloProduto;
using System.Collections;

namespace ProvaFuncional
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RepositorioGarcom repositorioGarcon = new RepositorioGarcom(new ArrayList());
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());


            CadastrarRegistros(repositorioGarcon, repositorioMesa, repositorioProduto, repositorioConta);

            TelaGarcom telaGarcon = new TelaGarcom(repositorioGarcon);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);
            TelaConta telaConta = new TelaConta(repositorioConta, repositorioMesa, repositorioProduto, repositorioGarcon, telaGarcon, telaMesa, telaProduto);


            TelaPrincipal principal = new TelaPrincipal();


            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "s")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaGarcon.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaGarcon.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaGarcon.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaGarcon.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaGarcon.ExcluirRegistro();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaProduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaProduto.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaProduto.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaProduto.ExcluirRegistro();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }
                }

                else if (opcao == "4")
                {
                    string subMenu = telaConta.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaConta.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaConta.RegistrarPedido();
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaConta.FechaConta();
                    }
                    else if (subMenu == "4")
                    {
                        telaConta.VisualizarContasAbertas();
                    }
                    else if (subMenu == "5")
                    {
                        telaConta.VisualizarFaturaTotalDoDia();
                        Console.ReadLine();
                    }
                    else if (subMenu == "6")
                    {
                        telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }

                    else if (subMenu == "7")
                    {
                        telaConta.EditarRegistro();
                        Console.ReadLine();
                    }

                    else if (subMenu == "8")
                    {
                        telaConta.ExcluirRegistro();
                        Console.ReadLine();
                    }

                    else if (subMenu == "9")
                    {
                        telaConta.CalcularPedidosDaConta();
                        Console.ReadLine();
                    }
                }


            }

        }

        private static void CadastrarRegistros(RepositorioGarcom repositorioGarcon, RepositorioMesa repositorioMesa, RepositorioProduto repositorioProduto, RepositorioConta repositorioConta)
        {

            Garcom garcon1 = new Garcom("Isaque", "999999999", 23);
            Garcom garcon2 = new Garcom("Pedro", "999999999", 45);

            repositorioGarcon.Inserir(garcon1);
            repositorioGarcon.Inserir(garcon2);

            Mesa mesa1 = new Mesa(5, "Ao lado da parede", "Ocupado");
            Mesa mesa2 = new Mesa(4, "Ao lado da porta", "Ocupado");

            repositorioMesa.Inserir(mesa1);
            repositorioMesa.Inserir(mesa2);

            Produto produto1 = new Produto("Refri", 23.00);
            Produto produto2 = new Produto("Cerveja", 15.00);

            repositorioProduto.Inserir(produto1);
            repositorioProduto.Inserir(produto2);

            Conta conta1 = new Conta(mesa1, garcon1);
            Conta conta2 = new Conta(mesa2, garcon2);

            repositorioConta.Inserir(conta1);
            repositorioConta.Inserir(conta2);
        }
    }
}