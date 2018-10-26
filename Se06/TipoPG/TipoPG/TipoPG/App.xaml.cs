using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TipoPG.View.Carousel;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TipoPG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Intro();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
