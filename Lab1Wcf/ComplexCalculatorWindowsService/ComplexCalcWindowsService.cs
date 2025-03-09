using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCalculatorWindowsService
{
    public class ComplexCalcWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public ComplexCalcWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFComplexCalculatorWindowsService";
        }

        public static void Main()
        {
            ServiceBase.Run(new ComplexCalcWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and
            // provide the base address.
            serviceHost = new ServiceHost(typeof(Lab1Wcf.ComplexCalculator));

            // Open the ServiceHostBase to create listeners and start
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

    }

    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "WCFComplexCalculatorWindowsService";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
