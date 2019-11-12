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
        /// Utilitaire permettant de déterminer si nous avons une commande dans les arguments de commande en ligne
        /// </summary>
        static bool HasCommand(String[] args, String command)
        {
            if (args == null || args.Length == 0 || String.IsNullOrWhiteSpace(command)) return false;
            return args.Any(a => String.Equals(a, command, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Exécute les services en mode interactif
        /// </summary>
        static void RunInteractiveServices(ServiceBase[] servicesToRun)
        {
            Console.WriteLine();
            Console.WriteLine("Démarrage des services en mode intéractif.");
            Console.WriteLine();

            // Récupération de la méthode a exécuter sur chaque service pour le démarrer 
            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic);

            // Boucle de démarrage des services
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Démarrage de {0} ... ", service.ServiceName);
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                Console.WriteLine("Démarré");
            }

            // Attente de la fin
            Console.WriteLine();
            Console.WriteLine("Appuyer sur une touche pour arrêter les services et terminer le processus...");
            Console.ReadKey();
            Console.WriteLine();

            // Récupération de la méthode à exécuter sur chaque service pour l'arrêter
            MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop", BindingFlags.Instance | BindingFlags.NonPublic);

            // Boucle d'arrêt
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Arrêt de {0} ... ", service.ServiceName);
                onStopMethod.Invoke(service, null);
                Console.WriteLine("Arrêté");
            }

            Console.WriteLine();
            Console.WriteLine("Tous les services sont arrêtés.");

            // Attend l'appui d'une touche pour ne pas retourner directement à VS
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.Write("=== Appuyer sur une touche pour quitter ===");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main(String[] args)
        {
            // Initialisation du service à démarrer
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new svcMyService() 
            };

            // On est en mode intéractif ?
            if (Environment.UserInteractive)
            {
                // On est en mode débogage ?
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    // Simule l'exécution des services
                    RunInteractiveServices(ServicesToRun);
                }
                else
                {
                    try
                    {
                        bool hasCommands = false;
                        // On a une commande pour exécuter les services en mode interactif ?
                        if (HasCommand(args, "run-services"))
                        {
                            RunInteractiveServices(ServicesToRun);
                            // On ne traite pas les autres commandes
                            return;
                        }
                        // On a une commande pour installer et démarre les services ?
                        if (HasCommand(args, "start-services"))
                        {
                            // Installation
                            ManagedInstallerClass.InstallHelper(new String[] { typeof(Program).Assembly.Location });
                            // Démarrage
                            foreach (var service in ServicesToRun)
                            {
                                ServiceController sc = new ServiceController(service.ServiceName);
                                sc.Start();
                                sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                            }
                            hasCommands = true;
                        }
                        // On a une commande pour arrêter et désinstaller les services ?
                        if (HasCommand(args, "stop-services"))
                        {
                            // Arrêt
                            foreach (var service in ServicesToRun)
                            {
                                ServiceController sc = new ServiceController(service.ServiceName);
                                sc.Stop();
                                sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                            }
                            // Désinstallation
                            ManagedInstallerClass.InstallHelper(new String[] { "/u", typeof(Program).Assembly.Location });
                            hasCommands = true;
                        }
                        // On a une commande d'installation ?
                        if (HasCommand(args, "install"))
                        {
                            ManagedInstallerClass.InstallHelper(new String[] { typeof(Program).Assembly.Location });
                            hasCommands = true;
                        }
                        // On a une commande de démarrage ?
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
                        // On a une commande d'arrêt ?
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
                        // On a une commande de désintallation ?
                        if (HasCommand(args, "uninstall"))
                        {
                            ManagedInstallerClass.InstallHelper(new String[] { "/u", typeof(Program).Assembly.Location });
                            hasCommands = true;
                        }
                        // Si on a pas de commandes on affiche un message d'aide
                        if (!hasCommands)
                        {
                            Console.WriteLine("Usage : {0} [command] [command ...]", Environment.GetCommandLineArgs());
                            Console.WriteLine("Commandes : ");
                            Console.WriteLine(" - install : Installation des services");
                            Console.WriteLine(" - uninstall : Désinstallation des services");
                            Console.WriteLine(" - start : Démarre les services");
                            Console.WriteLine(" - stop : Arrête les services");
                            Console.WriteLine(" - start-services : Installe et démarre les services");
                            Console.WriteLine(" - stop-services : Arrête et désinstalle les services");
                            Console.WriteLine(" - run-services : Exécute les services en mode interactif");
                        }
                    }
                    catch (Exception ex)
                    {
                        var oldColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erreur : {0}", ex.GetBaseException().Message);
                        Console.ForegroundColor = oldColor;
                    }
                }
            }
            else
            {
                // Exécute les services normalement
                ServiceBase.Run(ServicesToRun);
            }
        }

    }
}
