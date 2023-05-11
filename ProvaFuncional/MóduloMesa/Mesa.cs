using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloMesa
{
    public class Mesa : EntidadeBase
    {
        public int quantidadeDeClientes;
        public string localizacao;
        public string status;

        public Mesa(int quantidadeDeClientes, string localizacao, string status)
        {
            this.quantidadeDeClientes = quantidadeDeClientes;
            this.localizacao = localizacao;
            this.status = status;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            this.quantidadeDeClientes = mesaAtualizada.quantidadeDeClientes;
            this.localizacao = mesaAtualizada.localizacao;
            this.status = mesaAtualizada.status;

        }


        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (quantidadeDeClientes <= 0)
                erros.Add("O campo \"quantidade de clientes\" necessita de um valor");

            if (string.IsNullOrEmpty(localizacao.Trim()))
                erros.Add("O campo \"localização\" é obrigatório");

            if (string.IsNullOrEmpty(status.Trim()))
                erros.Add("O campo \"status\" é obrigatório");

            return erros;
        }
    }
}
