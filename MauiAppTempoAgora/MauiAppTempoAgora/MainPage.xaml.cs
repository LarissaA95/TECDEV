using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Validação do campo
            if (string.IsNullOrEmpty(txt_cidade.Text))
            {
                lbl_res.Text = "Preencha a cidade.";
                return;
            }

            try
            {
                // Chamada do Service
                Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                // Se vier dados
                if (t != null)
                {
                    string dados_previsao =
                        $"Latitude: {t.lat} \n" +
                        $"Longitude: {t.lon} \n" +
                        $"Descrição: {t.description} \n" +
                        $"Visibilidade: {t.visibility} \n" +
                        $"Velocidade: {t.speed} \n" +
                        $"Nascer do Sol: {t.sunrise} \n" +
                        $"Por do Sol: {t.sunset} \n" +
                        $"Temp Máx: {t.temp_max} \n" +
                        $"Temp Min: {t.temp_min} \n";

                    lbl_res.Text = dados_previsao;
                }
                else
                {
                    lbl_res.Text = "Sem dados de previsão.";
                }
            }
            catch (Exception ex)
            {
                // Tratamento de erros amigável
                switch (ex.Message)
                {
                    case "SEM_INTERNET":
                        await DisplayAlert(
                            "Sem conexão",
                            "Você está sem acesso à internet. Verifique sua conexão.",
                            "OK"
                        );
                        break;

                    case "CIDADE_NAO_ENCONTRADA":
                        await DisplayAlert(
                            "Cidade não encontrada",
                            "Não foi possível localizar a cidade informada.",
                            "OK"
                        );
                        break;

                    default:
                        await DisplayAlert(
                            "Erro",
                            "Ocorreu um erro ao buscar os dados do clima.",
                            "OK"
                        );
                        break;
                }
            }
        }
    }
}