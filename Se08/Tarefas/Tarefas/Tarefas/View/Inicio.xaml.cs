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
			InitializeComponent();
            DataHoje.Text = DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Now.ToString("dd/MM");
            Carregar();
		}

        private void Carregar()
        {
            List<Tarefa> tarefas = Gerenciador.Listar();
            int i = 0;
            
            if (tarefas.Count > 0)
            {
                foreach (Tarefa tar in tarefas)
                {
                    LinhaTarefa(tar, i);
                    i++;
                }
            }
            else
                ListaVazia();
        }

        public void ActionCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Cadastro());
        }

        public void ListaVazia()
        {
            StackLayout stack = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Label msg = new Label()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Text = "Não há tarefas para hoje"
            };
            stack.Children.Add(msg);
            slTarefas.Children.Add(stack);
        }

        public void LinhaTarefa(Tarefa tarefa, int i)
        {
            string imgCheck;
            DateTime vazio = new DateTime(0001, 01, 01);
            StackLayout StackCentral = null;
            Label lbl = null;
            if (tarefa.DataFinalizacao != vazio)
            {
                StackCentral = new StackLayout()
                {
                    Spacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };
                lbl = new Label()
                {
                    Text = tarefa.Nome,
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
                imgCheck = "CheckOn.png";
            }
            else
            {
                lbl = new Label()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Text = tarefa.Nome
                };
                imgCheck = "CheckOff.png";
            }

            StackLayout linha = new StackLayout()
            {
                Spacing = 15,
                Orientation = StackOrientation.Horizontal
            };

            TapGestureRecognizer encerrarTarefa = new TapGestureRecognizer();
            encerrarTarefa.Tapped += (sender, e) =>
            {
                Image image = (Image)sender;
                Gerenciador.Finalizar(i, tarefa);
                App.Current.MainPage = new NavigationPage(new Inicio());
            };

            Image check = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile(imgCheck) };
            if (Device.RuntimePlatform == Device.UWP)
                check.Source = ImageSource.FromFile("Resources/" + imgCheck);
            check.GestureRecognizers.Add(encerrarTarefa);


            Image prior = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("p"  + tarefa.Status + ".png") };
            if (Device.RuntimePlatform == Device.UWP)
                prior.Source = ImageSource.FromFile("Resources/p"+ tarefa.Status +".png");

            TapGestureRecognizer deletar = new TapGestureRecognizer();
            deletar.Tapped += (sender, e) =>
            {
                Image image = (Image)sender;
                Gerenciador.Remover(i, tarefa);
                App.Current.MainPage = new NavigationPage(new Inicio());
            };

            Image del = new Image() { VerticalOptions = LayoutOptions.Center, Source = ImageSource.FromFile("Delete.png") };
            if (Device.RuntimePlatform == Device.UWP)
                del.Source = ImageSource.FromFile("Resources/Delete.png");
            del.GestureRecognizers.Add(deletar);
            

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