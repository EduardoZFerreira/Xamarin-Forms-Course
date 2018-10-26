using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tarefas.Model
{
    public static class Gerenciador
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();
        public static void Salvar(Tarefa tarefa)
        {
            tarefas.Add(tarefa);
            SalvarProps(tarefas);
        }

        public static List<Tarefa> Listar()
        {
            return ListagemProps();
        }

        public static void Finalizar(Tarefa tarefa)
        {
            DateTime data = DateTime.Now;
            if (tarefas.Contains(tarefa))
            {
                int ind = tarefas.IndexOf(tarefa);
                tarefas[ind].DataFinalizacao = data;
                SalvarProps(tarefas);
            }
            else
                throw new Exception("A tarefa selecionada não existe!");
        }

        public static void Remover(Tarefa tarefa)
        {
            tarefas.Remove(tarefa);
            SalvarProps(tarefas);
        }

        private static void SalvarProps(List<Tarefa> tarefas)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }
            App.Current.Properties.Add("Tarefas", tarefas);
        }

        private static List<Tarefa> ListagemProps()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            } else
                return new List<Tarefa>();
        }


    }
}
