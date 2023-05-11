using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaConta)
        {
            this.listaRegistros = listaConta;
        }

        public void FecharStatus(Conta conta)
        {
            conta.Status = "Fechado";
        }

        public double CalcularPedidosDoDia()
        {
            double totalDia = 0;

            foreach (Conta conta in listaRegistros)
            {
                if (conta.DataDoPedido == DateTime.Now.Date)
                {
                    totalDia += conta.CalcularPedidos();
                }
            }
            return totalDia;
        }
    }
}
