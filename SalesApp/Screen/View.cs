using SalesApp.Op;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp
{
    static public class View
    {
        static bool RafaTheusPARASEMPRE = false;

        static public void Opcoes()
        {
            while (!RafaTheusPARASEMPRE)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n");
                Operacoes.WriteLineCenter("DIGITE 1 PARA CADASTAR PRODUTO / DIGITE 2 PARA CADASTAR CLIENTE  / 3 PARA EXIBIR PRODUTOS \n");
                Operacoes.WriteLineCenter("4 PARA EXIBIR CLIENTES  /  DIGITE 5 PARA REALIZAR VENDAS / DIGITE 6 PARA SAIR  \n");
                Operacoes.WriteLineCenter("------------------------------------------------------------------------------------------------------------------------");
                Operacoes.WriteLineCenter("------------------------------------------------------------------------------------------------------------------------");

                int.TryParse(Console.ReadLine(), out int decisao);

                switch (decisao)
                {
                    case 1:
                        Console.WriteLine("CADASTAR PRODUTO ");
                        break;
                    case 2:
                        Console.WriteLine("CADASTAR CLIENTE ");
                        break;
                    case 3:
                        Console.WriteLine("PARA EXIBIR PRODUTOS ");
                        break;
                    case 4:
                        Console.WriteLine("PARA EXIBIR CLIENTES ");
                        break;
                    case 5:
                        Console.WriteLine(" REALIZAR VENDAS ");
                        break;
                    case 6:
                        Console.WriteLine("OBRIGADO E ATÉ MAIS. ENTER PARA SAIR");
                        Console.ReadLine();
                        RafaTheusPARASEMPRE = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
