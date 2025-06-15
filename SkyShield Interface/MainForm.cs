using SkyShield_Interface.Models;
using SkyShield_Interface.Presenters;
using SkyShield_Interface.Views;

namespace SkyShield_Interface
{
    public partial class MainForm : Form, IMainView
    {
        private MainPresenter presenter;

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
