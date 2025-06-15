using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UdpLoggerSender : MonoBehaviour, ILogObserver
{
    UdpClient client;

    void Start()
    {
        client = new UdpClient();
    }

    public void OnLogEvent(string message)
    {
        string payload = $"{{ \"timestamp\": \"{System.DateTime.Now:O}\", \"event\": \"{message}\" }}";
        byte[] data = Encoding.UTF8.GetBytes(payload);
        client.Send(data, data.Length, "127.0.0.1", 9000);
    }

    void OnDestroy()
    {
        client?.Close();
    }
}