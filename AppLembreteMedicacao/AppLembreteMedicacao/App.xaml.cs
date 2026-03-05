using AppLembreteMedicacao.Helpers; 

namespace AppLembreteMedicacao;

public partial class App : Application
{
    public static SQLiteDatabaseHelper Banco { get; private set; } // Inseri este campo
    public App()
    {
        InitializeComponent();

        // --- ADICIONEI O CÓDIGO ABAIXO ---
        if (Banco == null)
        {
            // Define o caminho onde o arquivo do banco será salvo no celular
            string caminho = Path.Combine(FileSystem.AppDataDirectory, "remedios.db3");

            // Aqui é onde se "instancia" o banco, evitando o erro de null
            Banco = new SQLiteDatabaseHelper(caminho);
        }
        // -------------------------------

        MainPage = new AppShell();
    }
}