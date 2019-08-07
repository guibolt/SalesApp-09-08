using Newtonsoft.Json;
using SalesApp.Entities.Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesApp.Op
{
    static public class Operacoes
    {
        static public void WriteLineCenter(string a)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (a.Length / 2)) + "}", a));
        }
        static void GravarVendas(Pedido pedido)
        {
            string Lop = Guid.NewGuid().ToString();
            var caminh = AppDomain.CurrentDomain.ToString();
            string path = $"{caminh}{Lop}";

            //$@"C:\Users\Treinamento 5\Desktop\AtividadeEntrega\ArquivoJson\ArquivoJson{Lop.Substring(0, 2)}.json";
            StreamWriter writter = new StreamWriter(path);
            string arq = JsonConvert.SerializeObject(pedido);
            writter.WriteLine(arq);
            writter.Close();
        }

        
            //using (StreamReader s = File.OpenText(Path))
            //{
            //    string[] lines = File.ReadAllLines(Path);
            //    foreach (var line in lines)
            //    {
            //        var paut = JsonConvert.DeserializeObject<Pauta>(line);
            //        Pautas.Add(paut);
            //    }

            //}



    }
}
