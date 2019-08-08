using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesApp.Op
{
    public static class Jhonson<T>
    {
        static string traj = AppDomain.CurrentDomain.BaseDirectory;
        public static void Recuperar(List<T> pedidos, string caminho)
        {
            string path = $"{traj}{caminho}.json";
            using (StreamReader s = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<T>(line);
                    pedidos.Add(paut);
                }
            }
        }
        public static void Salvar(List<T> produtos, string caminho)
        {
            string path = $"{traj}{caminho}.json";
            File.Delete(path);
            using (StreamWriter s = File.AppendText(path))
            {
                foreach (var produto in produtos)
                {
                    string G = JsonConvert.SerializeObject(produto);
                    s.WriteLine(G);
                }
            }
        }
    }
}
