using Plc;

namespace WpfApp
{
    public class MainWindowModel
    {
        public MainWindowModel()
        {
            Entry.Plc.Connector.BuildAndStart();
            MAIN = Entry.Plc.MAIN;
        }

        public MAIN MAIN { get; set; }
    }
}