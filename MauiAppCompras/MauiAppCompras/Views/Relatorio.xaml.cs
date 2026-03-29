using System.Globalization;

namespace MauiAppCompras.Views;

public partial class Relatorio : ContentPage
{
    public Relatorio()
    {
        InitializeComponent();
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

    }

    private async void OnBuscarClicked(object sender, EventArgs e)
    {
        DateTime inicio = dtInicio.Date;
        DateTime fim = dtFim.Date;

        var lista = await App.Db.GetByPeriodo(inicio, fim);

        listaProdutos.ItemsSource = lista;
    }
}