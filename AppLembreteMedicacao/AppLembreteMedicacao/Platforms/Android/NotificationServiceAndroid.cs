namespace AppLembreteMedicacao.Platforms.Android;

public class NotificationServiceAndroid : ContentPage
{
	public NotificationServiceAndroid()
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