using Newtonsoft.Json;
using SkyShield_Interface.Models;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UdpLogReceiver
{
    public event Action<ThreatLog> OnLogReceived;

    public void Start()
    {
        Task.Run(() =>
        {
            UdpClient client = new UdpClient(9000);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] result = client.Receive(ref remoteEP);
                var json = Encoding.UTF8.GetString(result);
                var log = JsonConvert.DeserializeObject<ThreatLog>(json);
                OnLogReceived?.Invoke(log);
            }
        });
    }
}
