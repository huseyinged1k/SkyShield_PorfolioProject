using SkyShield_Interface.Services;
using SkyShield_Interface.Views;


namespace SkyShield_Interface.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;
        private readonly UdpLogReceiver receiver;
        private readonly VideoPlayerService videoService;
        private readonly LogArchiveService archiveService;
        private readonly AlarmService alarmService;

        string alarmPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Media", "alarm.wav");

        public MainPresenter(IMainView view)
        {
            this.view = view;
            this.receiver = new UdpLogReceiver();
            this.videoService = new VideoPlayerService();
            this.archiveService = new LogArchiveService();            
            this.alarmService = new AlarmService();

            view.SetPresenter(this);

            receiver.OnLogReceived += log =>
            {
                view.DisplayLog(log);
                archiveService.Append(log);

                if (log.Event.Contains("engaged"))
                    alarmService.Play(alarmPath);
            };

            receiver.Start();
        }

        public void PlayLastVideo()
        {
            string latestVideo = videoService.GetLatestVideo();
            videoService.Play(latestVideo);
        }
    }

}
