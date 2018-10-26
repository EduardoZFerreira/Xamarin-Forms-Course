using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipoPG.View.Master
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Principal : MasterDetailPage
	{
		public Principal ()
		{
			InitializeComponent ();
		}

        private void Pg1Call(object sender, EventArgs args)
        {
            Detail = new NavigationPage(new Navigation.Page1());
        }

        private void Pg2Call(object sender, EventArgs args)
        {
            Detail = new Navigation.Page2();
        }

        private void ContentCall(object sender, EventArgs args)
        {
            Detail = new Conteudo();
        }
    }
}