using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;

namespace AppLembreteMedicacao.Platforms.Android
{
    [BroadcastReceiver(Enabled = true)]
    public class NotificationReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            string titulo = intent.GetStringExtra("title");
            string mensagem = intent.GetStringExtra("message");

            var notification = new NotificationCompat.Builder(context, "medicacao_channel")
                .SetContentTitle(titulo)
                .SetContentText(mensagem)
                .SetSmallIcon(Resource.Drawable.appicon)
                .SetPriority(NotificationCompat.PriorityHigh)
                .Build();

            var manager = NotificationManagerCompat.From(context);
            manager.Notify(0, notification);
        }
    }
}