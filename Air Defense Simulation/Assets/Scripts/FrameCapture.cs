using System;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System.Collections;

public class FrameCapture : MonoBehaviour, ILogObserver
{
    private Process ffmpegProcess;
    private string outputFile;
    private bool isRecording = false;

    public Camera cam;

    public void StartRecording()
    {
        outputFile = Path.Combine(Application.persistentDataPath, $"capture_{System.DateTime.Now:HHmmss}.mp4");
        string args = $"-f rawvideo -pix_fmt rgb24 -s 1280x720 -r 60 -i - -vf vflip -an -vcodec libx264 -pix_fmt yuv420p -preset ultrafast -crf 23 \"{outputFile}\"";

        var ffmpeg = new ProcessStartInfo
        {
            FileName = Path.Combine(Application.streamingAssetsPath, "ffmpeg.exe"),
            Arguments = args,
            UseShellExecute = false,
            RedirectStandardInput = true,
            CreateNoWindow = true
        };

        ffmpegProcess = Process.Start(ffmpeg);
        isRecording = true;
        StartCoroutine(RecordRoutine());
    }

    IEnumerator RecordRoutine()
    {
        var tex = new Texture2D(1280, 720, TextureFormat.RGB24, false);
        
        var rt = new RenderTexture(1280, 720, 24);

        cam.targetTexture = rt;

        while (isRecording)
        {
            yield return new WaitForEndOfFrame();

            cam.Render();
            RenderTexture.active = rt;
            tex.ReadPixels(new Rect(0, 0, 1280, 720), 0, 0);
            tex.Apply();

            byte[] raw = tex.GetRawTextureData(); // RAW RGB24 formatı
            ffmpegProcess.StandardInput.BaseStream.Write(raw, 0, raw.Length);
            ffmpegProcess.StandardInput.BaseStream.Flush();
        }

        cam.targetTexture = null;
        RenderTexture.active = null;
        rt.Release();
    }


    public void OnLogEvent(string message)
    {
        if (!isRecording && message.Contains("engaged"))
        {
            StartRecording();
        }
    }
}
