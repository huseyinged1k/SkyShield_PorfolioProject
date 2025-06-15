using SkyShield_Interface.Presenters;

namespace SkyShield_Interface
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MainPresenter presenter = new MainPresenter(form);

            Application.Run(form);
        }
    }

}