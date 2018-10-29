using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
namespace Tarefas.Model
{
    public static class Gerenciador
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();
        public static void Salvar(Tarefa tarefa)
        {
            tarefas = Listar();
            tarefas.Add(tarefa);
            SalvarProps(tarefas);
        }

        public static List<Tarefa> Listar()
        {
            return ListagemProps();
        }

        public static void Finalizar(int index, Tarefa tarefa)
        {
            tarefas = Listar();
            DateTime data = DateTime.Now;
            
            tarefas[index].DataFinalizacao = data;
            SalvarProps(tarefas);
        }

        public static void Remover(int index, Tarefa tarefa)
        {
            tarefas = Listar();
            tarefas.RemoveAt(index);
            SalvarProps(tarefas);
        }

        private static void SalvarProps(List<Tarefa> tarefas)
        {
            
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }
            
            string JsonVal = JsonConvert.SerializeObject(tarefas);
            
            App.Current.Properties.Add("Tarefas", JsonVal);
        }

        private static List<Tarefa> ListagemProps()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string JsonVal = (string)App.Current.Properties["Tarefas"];

                List<Tarefa> lista = JsonConvert.DeserializeObject<List<Tarefa>>(JsonVal);

                return lista;
            } else
                return new List<Tarefa>();
        }


    }
}
