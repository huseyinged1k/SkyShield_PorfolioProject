using System.IO;
using UnityEngine;

public class SimulationLogger : MonoBehaviour, ILogObserver
{
    private string logFilePath;

    void Start()
    {
        logFilePath = Path.Combine(Application.persistentDataPath, "sim_logs.json");
        File.WriteAllText(logFilePath, "[\n");
    }

    void OnDestroy()
    {
        File.AppendAllText(logFilePath, "\n]");
    }

    public void OnLogEvent(string message)
    {
        string jsonEntry = $"  {{ \"time\": \"{System.DateTime.Now:O}\", \"event\": \"{message}\" }},\n";
        File.AppendAllText(logFilePath, jsonEntry);
    }
}