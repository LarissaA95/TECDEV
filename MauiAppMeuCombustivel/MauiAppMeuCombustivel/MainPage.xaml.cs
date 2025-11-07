namespace MauiAppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            try
            {
                string marca = txt_marca.Text?.Trim();
                string modelo = txt_modelo.Text?.Trim();

                // Verifica se os campos obrigatórios estão preenchidos
                if (string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo))
                {
                    DisplayAlert("Atenção", "Por favor, informe a marca e o modelo do veículo.", "OK");
                    return;
                }

                // Conversão dos valores numéricos
                double etanol = Convert.ToDouble(txt_etanol.Text.Replace(",", "."));
                double gasolina = Convert.ToDouble(txt_gasolina.Text.Replace(",", "."));

                if (etanol <= 0 || gasolina <= 0)
                {
                    DisplayAlert("Atenção", "Os preços devem ser maiores que zero.", "OK");
                    return;
                }

                string resultado = etanol <= (gasolina * 0.7)
                    ? $"O etanol está compensando para o seu {marca} {modelo}."
                    : $"A gasolina está compensando para o seu {marca} {modelo}.";

                DisplayAlert("Resultado", resultado, "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", "Ocorreu um erro inesperado. Tente novamente.", "Fechar");
            }

        }
    }
}
