namespace AppLembreteMedicacao.Platforms.Android;

public class NotificationReceiver : ContentPage
{
	public NotificationReceiver()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}