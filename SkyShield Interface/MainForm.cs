using SkyShield_Interface.Models;
using SkyShield_Interface.Presenters;
using SkyShield_Interface.Views;
using System.Diagnostics;

namespace SkyShield_Interface
{
    public partial class MainForm : Form, IMainView
    {
        private MainPresenter presenter;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openLogFolder(object sender, EventArgs e)
        {
            
            string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "..",
                "LocalLow",
                "DefaultCompany",
                "Air Defense Simulation");

            string fullPath = Path.GetFullPath(logPath);

            if (Directory.Exists(fullPath))
            {
                Process.Start("explorer.exe", fullPath);
            }
            else
            {
                MessageBox.Show("Klasör bulunamadý:\n" + fullPath, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
