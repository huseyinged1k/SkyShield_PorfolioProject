using Newtonsoft.Json;
using SkyShield_Interface.Models;
using SkyShield_Interface.Presenters;
using SkyShield_Interface.Services;
using SkyShield_Interface.Views;
using System.Diagnostics;
using System.Text;

namespace SkyShield_Interface
{
    public partial class MainForm : Form, IMainView
    {
        private MainPresenter presenter;
        public event Action<ThreatLog> OnLogReceived;
        private LogArchiveService archiveService;

        string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "..",
                "LocalLow",
                "DefaultCompany",
                "Air Defense Simulation");

        string fullPath;
        public MainForm()
        {
            InitializeComponent();
            fullPath = Path.GetFullPath(logPath);

            LoadSimulationLogs();
        }

        private void openLogFolder(object sender, EventArgs e)
        {
            if (Directory.Exists(fullPath))
            {
                Process.Start("explorer.exe", fullPath);
            }
            else
            {
                MessageBox.Show("Klasör bulunamadý:\n" + fullPath, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSimulationLogs()
        {
            string logFilePath = Path.Combine(fullPath, "sim_logs.json");

            if (File.Exists(logFilePath))
            {
                string json = File.ReadAllText(logFilePath);
                
                var logs = JsonConvert.DeserializeObject<List<ThreatLog>>(json);

                if (logs != null)
                {
                    foreach (var log in logs)
                    { 
                        DisplayLog(log);
                    }
                }
            }
        }
    }
}
