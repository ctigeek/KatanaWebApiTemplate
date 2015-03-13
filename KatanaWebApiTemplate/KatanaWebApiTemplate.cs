using System.ServiceProcess;

namespace KatanaWebApiTemplate
{
    public partial class KatanaWebApiTemplate : ServiceBase
    {
        private readonly WebAppManager webAppManager;
        public KatanaWebApiTemplate()
        {
            InitializeComponent();
            webAppManager = new WebAppManager();
        }

        protected override void OnStart(string[] args)
        {
            webAppManager.Start();
        }

        protected override void OnStop()
        {
            webAppManager.Stop();
        }
    }
}
