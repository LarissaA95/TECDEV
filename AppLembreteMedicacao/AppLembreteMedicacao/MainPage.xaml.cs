using AppLembreteMedicacao.Models;

namespace AppLembreteMedicacao;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // Ação do botão da Sprint 1.2
    private async void AoClicarSalvar(object sender, EventArgs e)
    {
        try
        {
            // Validação simples: o nome não pode estar vazio
            if (string.IsNullOrWhiteSpace(entNome.Text))
            {
                await DisplayAlert("Atenção", "Por favor, digite o nome do remédio.", "OK");
                return;
            }

            // Criando o objeto com os dados da tela (Sprint 1.2)
            var novoRemedio = new Medicamento
            {
                Nome = entNome.Text,
                Dosagem = entDose.Text,
                DataInicio = dtInicio.Date.ToString("dd/MM/yyyy"),
                Ativo = 1
            };

            // Salvando no banco de dados criado na Sprint 1.1
            // Usamos o App.Banco que definimos no App.xaml.cs
            await App.Banco.InsertMedicamento(novoRemedio);

            await DisplayAlert("Sucesso!", $"{novoRemedio.Nome} foi cadastrado.", "OK");

            // Limpa os campos após salvar
            entNome.Text = string.Empty;
            entDose.Text = string.Empty;



        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Erro ao salvar: " + ex.Message, "OK");
        }

    }


}