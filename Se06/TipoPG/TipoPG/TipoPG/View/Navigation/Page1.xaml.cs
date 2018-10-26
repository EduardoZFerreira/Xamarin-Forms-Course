using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipoPG.View.Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        private void MudarPagina2(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Page2());
        }

        private void MasterCall(object sender, EventArgs args)
        {
            App.Current.MainPage = new Master.Principal();
        }
    }
}