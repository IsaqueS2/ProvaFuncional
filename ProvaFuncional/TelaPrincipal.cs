﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaFuncional
{
    public class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle de Bar");

            Console.WriteLine("Digite 1 para Cadastrar Garçons");
            Console.WriteLine("Digite 2 para Cadastrar Produtos");
            Console.WriteLine("Digite 3 para Cadastrar Mesas");
            Console.WriteLine("Digite 4 para Cadastrar Contas");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }

}
