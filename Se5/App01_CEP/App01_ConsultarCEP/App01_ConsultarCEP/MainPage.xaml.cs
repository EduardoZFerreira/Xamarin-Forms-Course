using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Services.Model;
using App01_ConsultarCEP.Services; 

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBusca.Clicked += BuscarCep;

        }

        private void BuscarCep(object sender, EventArgs args)
        {
            string cep = enCep.Text.Trim();
            if (IsValid(cep))
            {
                try
                {
                    Endereco end = ViaCEPService.BuscarEnderecoViaCEP(cep);
                    if(end != null)
                        lblResult.Text += "Endereço: " + end.uf + " - " + end.localidade + " - " + end.bairro + " - " + end.logradouro + " - " + end.unidade + "\n";
                    else
                        lblResult.Text += "Endereço não encontrado! \n";
                } catch(Exception e)
                {
                   DisplayAlert("Erro Crítico", e.Message, "Ok");
                }
            }
            else
                DisplayAlert("Erro", "O CEP informado é inválido", "Ok");
        }

        private bool IsValid(string cep)
        {
            if (cep.Length == 8)
                return false;
            int teste = 0;
            if (!int.TryParse(cep, out teste))
                return false;
            return true;
        }
    }
}
