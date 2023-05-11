using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloProduto
{
    public class RepositorioProduto : RepositorioBase
    {

        public RepositorioProduto(ArrayList listapProduto)
        {
            this.listaRegistros = listapProduto;
        }

        public override Produto SelecionarPorId(int id)
        {
            return (Produto)base.SelecionarPorId(id);
        }
    }
}
