using Newtonsoft.Json;
using SkyShield_Interface.Models;
using System.IO;

namespace SkyShield_Interface.Services
{
    public class LogArchiveService
    {
        public readonly string archivePath;

        public LogArchiveService()
        {
            archivePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log_archive.json");

            if (!File.Exists(archivePath))
            {
                File.WriteAllText(archivePath, "[\n");
            }
        }

        public void Append(ThreatLog log)
        {
            string jsonEntry = JsonConvert.SerializeObject(log, Formatting.Indented) + ",\n";
            File.AppendAllText(archivePath, jsonEntry);
        }

        public void FinalizeLog()
        {
            File.AppendAllText(archivePath, "\n]");
        }
    }

}
