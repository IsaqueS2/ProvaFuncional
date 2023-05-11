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
    public class Conta : EntidadeBase
    {

        public string Status;
        public ArrayList Pedidos;
       public Mesa mesa;
        public Garcom Garcom;
        public DateTime DataDoPedido;

        public Conta(Mesa mesa, Garcom garcom)
        {

            this.mesa  = mesa;
            this.Garcom = garcom;
            this.Status = "Aberto";
           this.Pedidos = new ArrayList();
            this.DataDoPedido = DateTime.Now.Date;
        }


        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {




        }

        public override ArrayList Validar()
        {
            ArrayList listaErros = new ArrayList();

            //if (string.IsNullOrEmpty())
            //{
            //    listaErros.Add("O campo \"mesa\" é obrigatório");
            //}
            return listaErros;
        }

        public void AdicionarPedido(Produto produto, int quantidadeTotalDePedidos)
        {
            Pedido pedido = new Pedido(produto, quantidadeTotalDePedidos);
            Pedidos.Add(pedido);
        }

        public double CalcularPedidos()
        {
            double pedidosCalculados = 0;

            foreach (Pedido pedido in Pedidos)
            {
                pedidosCalculados = pedido.CalcularPedido();
            }
            return pedidosCalculados;
        }



    }

    public class Pedido
    {
        public Produto produto;
        public int quantidadeTotalDePedidos;

        public Pedido(Produto produto, int quantidadeTotalDePedidos)
        {
            this.produto = produto;
            this.quantidadeTotalDePedidos = quantidadeTotalDePedidos;
        }

        public double CalcularPedido()
        {
            double pedidoCalculado = quantidadeTotalDePedidos * produto.valor;
            return pedidoCalculado;
        }
    }
}
