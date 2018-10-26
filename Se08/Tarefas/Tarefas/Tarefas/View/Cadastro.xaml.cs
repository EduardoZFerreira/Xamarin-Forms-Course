using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarefas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {

        private byte prior { get; set; }

		public Cadastro ()
		{
			InitializeComponent ();
		}

        public void SelPrior(object sender, EventArgs args)
        {
            var stacks = slPrioridades.Children;
            foreach(var stack in stacks)
            {
                Label lblPrior = ((StackLayout)stack).Children[1] as Label;
                lblPrior.TextColor = Color.Gray;
            }
            ((Label)((StackLayout)sender).Children[1]).TextColor = Color.Black;
            FileImageSource src = ((Image)((StackLayout)sender).Children[0]).Source as FileImageSource;
            string prioridade = src.File.ToString().Replace("Resources/", "").Replace(".png", "").Replace("p", "");
            this.prior = byte.Parse(prioridade);
        }

        public void SalvarAction(object sender, EventArgs args)
        {
            bool erro = false;
            if (!(Nome.Text.Trim().Length > 0))
                erro = true;
            if (!(this.prior > 0))
                erro = true;
            if (erro == false)
            {
                //Salvar dados
                Tarefa tarefa = new Tarefa() { Nome = Nome.Text.Trim(), Status = this.prior };
                Gerenciador.Salvar(tarefa);
                App.Current.MainPage = new NavigationPage(new Inicio());
            }
            else
                DisplayAlert("Erro", "Verifique se todos os dados foram preenchidos!", "Ok");
        }

	}
}