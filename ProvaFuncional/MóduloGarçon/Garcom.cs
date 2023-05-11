using ProvaFuncional.Compatilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional.MóduloGarçon
{
    public class Garcom : EntidadeBase
    {

        public string nome;
        public string telefone;
        public int idade;

        public Garcom(string nome, string telefone, int idade)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.idade = idade;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garconAtualizado = (Garcom)registroAtualizado;

            this.nome = garconAtualizado.nome;
            this.telefone = garconAtualizado.telefone;
            this.idade = garconAtualizado.idade;

        }


        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (idade < 18)
                erros.Add("O campo \"idade\" precisa ser maior que 18");

            return erros;
        }

    }
}
