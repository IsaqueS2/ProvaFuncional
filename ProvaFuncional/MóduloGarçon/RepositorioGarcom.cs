using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloGarçon
{
    public class RepositorioGarcom : RepositorioBase

    {
        public RepositorioGarcom(ArrayList listaGarcon)
        {
            this.listaRegistros = listaGarcon;
        }

        public override Garcom SelecionarPorId(int id)
        {
            return (Garcom)base.SelecionarPorId(id);
        }
    }
}
