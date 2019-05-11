using System;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ENVIAR.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //Logica do Programa

            //validações
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Logradouro: {0} " + Environment.NewLine
                                                + "Complemento: {1} " + Environment.NewLine
                                                + "Bairro : {2} " + Environment.NewLine
                                                + "Localidade : {3} " + Environment.NewLine
                                                + "UF : {4} " + Environment.NewLine,
                                                end.logradouro, end.complemento, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO","O endereço não foi encontrado para o cep informado " + cep, "OK");
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");

                }
            }


        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length < 8 || cep.Length > 8)
            {
                DisplayAlert("ERRO", "CEP inválido! o cep deve conter 8 carecteres", "OK");
                valido = false;
            }
            int novocep = 0;
            if (!int.TryParse(cep, out novocep))
            {
                DisplayAlert("ERRO", "CEP inválido! o cep deve composto apenas por numeros", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
