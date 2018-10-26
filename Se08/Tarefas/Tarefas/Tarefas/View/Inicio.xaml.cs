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
	public partial class Inicio : ContentPage
	{
		public Inicio ()
		{
			InitializeComponent ();
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM");
            List<Tarefa> tarefas = Gerenciador.Listar();
            foreach(Tarefa tar in tarefas)
            {
                LinhaTarefa(tar);
            }
		}

        public void ActionCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        public void LinhaTarefa(Tarefa tarefa)
        {
            string imgCheck;
            StackLayout StackCentral = null;
            Label lbl = null;
            if (tarefa.DataFinalizacao == null)
            {
                StackCentral = new StackLayout()
                {
                    Spacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };
                lbl = new Label()
                {
                    TextColor = Color.Gray
                };
                Label dtFinal = new Label()
                {
                    TextColor = Color.Gray,
                    FontSize = 10,
                    Text = "Finalizado em " + tarefa.DataFinalizacao.Date.ToString("dd/MM/yyyy - hh:mm") + "h"
                };
                StackCentral.Children.Add(lbl);
                StackCentral.Children.Add(dtFinal);
                imgCheck = "checkOff.png";
            }
            else
            {
                lbl = new Label()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Text = tarefa.Nome
                };
                imgCheck = "checkOn.png";
            }

            StackLayout linha = new StackLayout()
            {
                Spacing = 15,
                Orientation = StackOrientation.Horizontal
            };
            
            Image check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(imgCheck) };
            if (Device.RuntimePlatform == Device.UWP)
                check.Source = ImageSource.FromFile("Resources/" + imgCheck);

            Image prior = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(tarefa.Status + ".png") };
            if (Device.RuntimePlatform == Device.UWP)
                prior.Source = ImageSource.FromFile("Resources/"+ tarefa.Status +".png");

            Image del = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
                del.Source = ImageSource.FromFile("Resources/Delete.png");
            
            

            


            linha.Children.Add(check);
            if (StackCentral == null)
                linha.Children.Add(lbl);
            else
                linha.Children.Add(StackCentral);
            linha.Children.Add(prior);
            linha.Children.Add(del);

            slTarefas.Children.Add(linha);
        }

	}
}