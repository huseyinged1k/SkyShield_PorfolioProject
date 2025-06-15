using SkyShield_Interface.Models;
using SkyShield_Interface.Presenters;

namespace SkyShield_Interface.Views
{
    public interface IMainView
    {
        void DisplayLog(ThreatLog log);
        void SetPresenter(MainPresenter presenter);
    }
}
