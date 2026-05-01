using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System;
using System.Diagnostics;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked_Previsao(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = 
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

                        string mapa = $"https://embed.windy.com/embed.html?" +
                                      $"type=map&location=coordinates&metricRain=mm&metricTemp=°C" +
                                      $"&metricWind=km/h&zoom=5&overlay=wind&product=ecmwf&level=surface" +
                                      $"&lat={t.lat.ToString().Replace(",", ".")}&lon={t.lon.ToString().Replace(",", ".")}";

                        wv_mapa.Source = mapa;

                        Debug.WriteLine(mapa);

                    }
                    else
                    {

                        lbl_res.Text = "Sem dados de Previsão";
                    }

                }
                else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }

            }
            //Cidade não encontrada
            catch (Exception ex) when (ex.Message == "CIDADE_NAO_ENCONTRADA")
            {
                await DisplayAlert("Cidade não encontrada", "Verifique o nome da cidade e tente novamente.", "OK");
            }

            //Sem internet
            catch (Exception ex) when (ex.Message == "SEM_INTERNET")
            {
                await DisplayAlert("Sem conexão", "Você está sem acesso à internet.", "OK");
            }

            //Outros erros
            catch (Exception)
            {
                await DisplayAlert("Erro", "Ocorreu um erro ao buscar a previsão do tempo.", "OK");
            }
        }

        private async void Button_Clicked_Localizacao(object sender, EventArgs e)
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(
                    GeolocationAccuracy.Medium,
                    TimeSpan.FromSeconds(10)
                );

                Location? local = await Geolocation.Default.GetLocationAsync(request);

                if (local != null)
                {
                    string local_disp = $"Latitude: {local.Latitude} \n" +
                                        $"Longitude: {local.Longitude}";

                    lbl_coords.Text = local_disp;

                    // pega nome da cidade que está nas coordenadas.
                    GetCidade(local.Latitude, local.Longitude);

                }
                else
                {
                    lbl_coords.Text = "Nenhuma localização";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Erro: Dispositivo não Suporta", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Erro: Localização Desabilitada", fneEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Erro: Permissão da Localização", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void GetCidade(double lat, double lon)
        {
            try
            {
                IEnumerable<Placemark> places = await Geocoding.Default.GetPlacemarksAsync(lat, lon);

                Placemark? place = places.FirstOrDefault();

                if (place != null)
                {
                    txt_cidade.Text = place.Locality;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro: Obtenção do nome da Cidade", ex.Message, "OK");
            }
        }
    }
}