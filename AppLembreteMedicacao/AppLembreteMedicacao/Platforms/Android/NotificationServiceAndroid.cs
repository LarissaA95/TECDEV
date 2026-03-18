using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using AppLembreteMedicacao.Services;

namespace AppLembreteMedicacao.Platforms.Android
{
    public class NotificationServiceAndroid : INotificationService
    {
        const string CHANNEL_ID = "medicacao_channel";

        public void AgendarNotificacao(int id, string titulo, string mensagem, DateTime dataHora)
        {
            var context = Android.App.Application.Context;

            var intent = new Intent(context, typeof(NotificationReceiver));
            intent.PutExtra("title", titulo);
            intent.PutExtra("message", mensagem);

            var pendingIntent = PendingIntent.GetBroadcast(
                context,
                id,
                intent,
                PendingIntentFlags.Immutable | PendingIntentFlags.UpdateCurrent
            );

            long triggerTime = new DateTimeOffset(dataHora).ToUnixTimeMilliseconds();

            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            alarmManager.SetExactAndAllowWhileIdle(
                AlarmType.RtcWakeup,
                triggerTime,
                pendingIntent
            );
        }

        public void CancelarNotificacao(int id)
        {
            var context = Android.App.Application.Context;

            var intent = new Intent(context, typeof(NotificationReceiver));

            var pendingIntent = PendingIntent.GetBroadcast(
                context,
                id,
                intent,
                PendingIntentFlags.Immutable | PendingIntentFlags.UpdateCurrent
            );

            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.Cancel(pendingIntent);
        }
    }
}