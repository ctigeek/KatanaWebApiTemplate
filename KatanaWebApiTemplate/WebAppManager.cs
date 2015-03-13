using System;
using System.Configuration;
using System.IO;
using log4net;
using log4net.Core;
using Microsoft.Owin.Hosting;

namespace KatanaWebApiTemplate
{
    internal class WebAppManager
    {
        private static ILog log = LogManager.GetLogger(typeof(WebAppManager));
        public bool Running { get; private set; }
        private readonly bool debug;
        private IDisposable webApp;

        public WebAppManager()
        {
            Running = false;
            debug = ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level.Value <= Level.Debug.Value;
        }

        public void Start()
        {
            try
            {
                if (Running) throw new InvalidOperationException("WebAppManager already running.");
                var uri = ConfigurationManager.AppSettings["uri"];
                webApp = WebApp.Start<Startup>(uri);
                Running = true;
                log.Debug("Listening on " + uri);
            }
            catch (Exception ex)
            {
                log.Error("Could not start WebAppManager: ", ex);
                Running = false;
                throw;
            }
        }
        
        public void Stop()
        {
            if (webApp != null)
            {
                webApp.Dispose();
                webApp = null;
            }
            Running = false;
        }
    }
}
