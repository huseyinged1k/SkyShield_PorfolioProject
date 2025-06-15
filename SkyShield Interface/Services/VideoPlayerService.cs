using SkyShield_Interface.Views;

namespace SkyShield_Interface.Services
{
    public class VideoPlayerService
    {
        private readonly string capturePath = Path.GetFullPath(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            @"..\LocalLow\DefaultCompany\Air Defense Simulation"));

        public string GetLatestVideo()
        {
            var files = Directory.GetFiles(capturePath, "capture_*.mp4");
            return files.OrderByDescending(f => File.GetCreationTime(f)).FirstOrDefault();
        }

        public void Play(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            foreach (Form f in Application.OpenForms)
            {
                if (f is MainForm mf)
                {
                    mf.mediaPlayer.URL = path;
                    mf.mediaPlayer.Ctlcontrols.play();
                    break;
                }
            }
        }
    }

}
