﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesApp.Op
{
    public static class Jhonson<T>
    {
        static string traj = AppDomain.CurrentDomain.BaseDirectory;
        public static void Recuperar(List<T> coisas, string caminho)
        {
            string path = $"{traj}{caminho}.json";
            using (StreamReader s = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var paut = JsonConvert.DeserializeObject<T>(line);
                    coisas.Add(paut);
                }
            }
        }
        public static void Salvar(List<T> coisas, string caminho)
        {
            string path = $"{traj}{caminho}.json";
            File.Delete(path);
            using (StreamWriter s = File.AppendText(path))
            {
                foreach (var produto in coisas)
                {
                    string G = JsonConvert.SerializeObject(produto);
                    s.WriteLine(G);
                }
            }
        }
    }
}
