using Android.App;
using Android.OS;

public override void OnCreate()
{
    base.OnCreate();
    CriarCanalNotificacao();
}

void CriarCanalNotificacao()
{
    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
    {
        var channel = new NotificationChannel(
            "medicacao_channel",
            "Lembrete de Medicamentos",
            NotificationImportance.High
        );

        var manager = (NotificationManager)GetSystemService(NotificationService);

        manager.CreateNotificationChannel(channel);
    }
}