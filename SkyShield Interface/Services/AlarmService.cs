using System.Media;
using NAudio.Wave;

namespace SkyShield_Interface.Services
{
    public class AlarmService
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public void Play(string wavPath)
        {
            if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                return; // zaten çalıyor, tekrar başlatma

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(wavPath);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += OnPlaybackStopped;
            outputDevice.Play();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            outputDevice.Dispose();
            audioFile.Dispose();
            outputDevice = null;
            audioFile = null;
        }
    }
}

