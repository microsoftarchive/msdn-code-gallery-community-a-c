using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinServiceTest
{
    static class Program
    {

        /// <summary>
        /// Helper for check if we are a command in the command line arguments
        /// </summary>
        static bool HasCommand(String[] args, String command)
        {
            if (args == null || args.Length == 0 || String.IsNullOrWhiteSpace(command)) return false;
            return args.Any(a => String.Equals(a, command, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Run services in interactive mode
        /// </summary>
        static void RunInteractiveServices(ServiceBase[] servicesToRun)
        {
            Console.WriteLine();
            Console.WriteLine("Start the services in interactive mode.");
            Console.WriteLine();

            // Get the method to invoke on each service to start it
            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic);

            // Start services loop
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Starting {0} ... ", service.ServiceName);
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                Console.WriteLine("Started");
            }

            // Waiting the end
            Console.WriteLine();
            Console.WriteLine("Press a key to stop services et finish process...");
            Console.ReadKey();
            Console.WriteLine();

            // Get the method to invoke on each service to stop it
            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop", BindingFlags.Instance | BindingFlags.NonPublic);

            // Stop loop
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Stopping {0} ... ", service.ServiceName);
                onStopMethod.Invoke(service, null);
                Console.WriteLine("Stopped");
            }

            Console.WriteLine();
            Console.WriteLine("All services are stopped.");

            // Waiting a key press to not return to VS directly
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.Write("=== Press a key to quit ===");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        static void Main(String[] args)
        {
            // Initialize the service to start
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new svcMyService() 
            };

            // In interactive mode ?
            if (Environment.UserInteractive)
            {
                // In debug mode ?
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    // Simulate the services execution
                    RunInteractiveServices(ServicesToRun);
                }
                else
                {
                    try
                    {
                        bool hasCommands = false;
                        // Having command to run the services in interactive mode ?
                        if (HasCommand(args, "run-services"))
                        {
                            RunInteractiveServices(ServicesToRun);
                            // We don't process other commands
                            return;
                        }
                        // Having command to install and start the services ?
                        if (HasCommand(args, "start-services"))
                        {
                            // Install
                            ManagedInstallerClass.InstallHelper(new String[] { typeof(Program).Assembly.Location });
                            // Start
                            foreach (var service in ServicesToRun)
                            {
                                ServiceController sc = new ServiceController(service.ServiceName);
                                sc.Start();
                                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            }
                            hasCommands = true;
                        }
                        // Having a command to stop and uninstall the services ?
                        if (HasCommand(args, "stop-services"))
                        {
                            // Stop
                            foreach (var service in ServicesToRun)
                            {
                                ServiceController sc = new ServiceController(service.ServiceName);
                                sc.Stop();
                                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                            }
                            // Uninstall
                            ManagedInstallerClass.InstallHelper(new String[] { "/u", typeof(Program).Assembly.Location });
                            hasCommands = true;
                        }
                        // Having an install command ?
                        if (HasCommand(args, "install"))
                        {
                            ManagedInstallerClass.InstallHelper(new String[] { typeof(Program).Assembly.Location });
                            hasCommands = true;
                        }
                        // Having a start command ?
                        if (HasCommand(args, "start"))
                        {
                            foreach (var service in ServicesToRun)
                            {
                                ServiceController sc = new ServiceController(service.ServiceName);
                                sc.Start();
                                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            }
                            hasCommands = true;
                        }
                        // Having a stop command ?
                        if (HasCommand(args, "stop"))
                        {
                            foreach (var service in ServicesToRun)
                            {
                                ServiceController sc = new ServiceController(service.ServiceName);
                                sc.Stop();
                                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                            }
                            hasCommands = false;
                        }
                        // Having an uninstall command ?
                        if (HasCommand(args, "uninstall"))
                        {
                            ManagedInstallerClass.InstallHelper(new String[] { "/u", typeof(Program).Assembly.Location });
                            hasCommands = true;
                        }
                        // If we don't have commands we print usage message
                        if (!hasCommands)
                        {
                            Console.WriteLine("Usage : {0} [command] [command ...]", Environment.GetCommandLineArgs());
                            Console.WriteLine("Commands : ");
                            Console.WriteLine(" - install : Install the services");
                            Console.WriteLine(" - uninstall : Uninstall the services");
                            Console.WriteLine(" - start : Start the services");
                            Console.WriteLine(" - stop : Stop the services");
                            Console.WriteLine(" - start-services : Install and start the services");
                            Console.WriteLine(" - stop-services : Stop and uninstall the services");
                            Console.WriteLine(" - run-services : Run the services in interactive mode");
                        }
                    }
                    catch (Exception ex)
                    {
                        var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error : {0}", ex.GetBaseException().Message);
                        Console.ForegroundColor = oldColor;
                    }
                }
            }
            else
            {
                // Normal service execution
                ServiceBase.Run(ServicesToRun);
            }
        }

    }
}
