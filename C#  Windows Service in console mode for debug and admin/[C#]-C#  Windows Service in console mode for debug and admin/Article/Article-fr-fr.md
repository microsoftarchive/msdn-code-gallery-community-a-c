# C# : Service Windows en mode console pour le débogage et l'administration

Lorsque l'on développe des services Windows en .Net nous sommes très vite confronté au problème du débogage.

De plus nous devons régulièrement démarrer, arrêter le service, voir l'installer et le désinstaller. Toutes ces actions nécessitent d'utiliser différentes lignes de commandes (installutil, net start, etc.).

Je vous propose dans cet article de transformer votre Service Windows en mode console pour vous permettre de déboguer un peu plus facilement, ainsi que gérer tous les mécanismes de manipulation du service au travers des paramètres de lignes de commandes, et ainsi simplifier sa gestion.

Tout ce qui va être présenté n'est pas nouveau, vous trouverez pas mal de documentation sur le sujet à travers le Web, je me contente juste de rassembler le tout dans un article, comme rappel.

# Créer un Service Windows

Petit rappel pour la création d'un service "My Service":
- Lancer la création d'un nouveau projet
- Sélectionner le modèle "Modèles > Visual C# > Bureau Windows > Service Windows"


![Création d'un service Windows](vs-ws-create1.png)

On renomme la classe "Service1" en "svcMyService" et le nom du service "My Service" dans l'éditeur de propriété ouvert:

![Renomme le service](vs-ws-create2.png)

Ensuite dans l'explorateur de solution, on renomme le fichier "Service1.cs" du service en "svcMyService.cs":

![Renomme les fichiers](vs-ws-create3.png)

Les fichiers sous-jacents seront automatiquement renommés.

La dernière étape est de créer le programme d'installation. Depuis le designer de service (s'il a été fermé l'ouvrir en double-cliquant sur "svcMyService.cs" depuis l'explorateur de solution) faire un clic droit sur le designer et sélectionner "Ajouter un programme d'installation":

![Ajouter le programme d'installation](vs-ws-create4.png)

Dans le designer qui s'ouvre, sélectionner "serviceProcessInstaller1" pour pouvoir modifier le compte d'exécution du service, pour nos test nous choisirons "LocalSystem".

![Edition du compte utilisateur](vs-ws-create5.png)

En sélectionnant "serviceInstaller1" on peut modifier les informations d'affichage du service dans le gestionnaire de service.

![Modification des informations du service](vs-ws-create6.png)

Lancer une génération du programme "Générer &gt; Régénérer la solution". Si vous lancez une exécution vous aurez une erreur vous indiquant que c'est un service qui doit être installé et démarré.

On fait un test en installant notre service, et en le démarrant:
- Ouvrir un invité de commande en tant qu'administrateur
- Se rendre dans le dossier de destination de compilation du service "bin\Debug" de la solution

On peut ouvrir directement le dossier de la solution depuis l'explorateur de solution, clic-droit sur le dossier et "Ouvrir le dossier dans l'Explorateur de fichiers" et naviguer vers "bin\Debug". Sous Windows 8.1 utiliser le menu "Fichier > Ouvrir un invite de commande > Ouvrir un invite de commande en tant qu'administrateur".

Installer le service :

```
"%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" WinServiceTest.exe
```

Et on démarre notre service.

```
net start "My Service"
```

Normalement tout fonctionne:
- Dans le dossier de l'exécutable nous trouvons des fichiers log.
- Dans le gestionnaire de services nous trouvons notre service (avec les informations définies dans le programme d'installation).
- Dans l'observateur des journaux d'événements une nouvelle source d'affichera "My Service" si vous avez laissé "True" la valeur de la propriété "AutoLog" depuis le designer de service.

On peut tout arrêter:

```
net stop "My Service""%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" /u WinServiceTest.exe
```

# Déboguer un Service Windows

Petit rappel, pour déboguer un service, vous devez faire plusieurs choses:
- Installer le service avec "InstallUtil.exe"
- Démarrer le service avec "net start"
- Lancer Visual Studio en tant qu'Administrateur
- Attacher le débogueur au service en cours d'exécution

Bien sûr avant de modifier votre code et de recompiler votre service, vous devez au moins l'arrêter avec "net stop".

Toute cette procédure est parfois fastidieuse, et pose également un problème en terme de débogage, si le service ne fonctionne pas correctement au démarrage, vous n'avez pas le temps d'attacher le débogueur pour tracer ce qui se passe.

# Transformer son Service en Application Console pour le débogage

L'idée pour nous faciliter le débogage est de créer une application console qui va simuler l'exécution de notre service lorsqu'il est exécuté par Visual Studio.

La première étape est de modifier le type d'application du projet.
- Clic droit sur sur le projet du service ("WinServiceTest" dans notre cas) et sélectionner "Propriétés".
- Dans l'onglet "Application", zone "Type de sortie" sélectionner "Application Console" ("Application Windows" par défaut).
- Enregistrer les modifications.

Ensuite l'idée est de déterminer si on est mode service ou en mode débogage, pour celà il suffit de savoir si on est en mode interactif, grâce à la propriété `Environment.UserInteractive` et si on est en débogage avec la propriété `System.Diagnostics.Debugger.IsAttached`.

Dans le fichier "Program.cs" on modifie le code de la méthode Main de cette manière

``` csharp
/// <summary>
/// Point d'entrée principal de l'application.
/// </summary>
static void Main()
{
    // Initialisation du service à démarrer
    ServiceBase[] ServicesToRun;
    ServicesToRun = new ServiceBase[] 
    { 
        new svcMyService() 
    };

    // On est en mode intéractif et débogage ?
    if (Environment.UserInteractive && System.Diagnostics.Debugger.IsAttached)
    {
        // Simule l'exécution des services
        RunInteractiveServices(ServicesToRun);
    }
    else
    {
        // Exécute les services normalement
        ServiceBase.Run(ServicesToRun);
    }
}
```

Ensuite on ajoute la méthode "RunInteractiveServices" qui va démarrer chaque service :

``` csharp
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
    Console.WriteLine();
    Console.Write("=== Appuyer sur une touche pour quitter ===");
    Console.ReadKey();
}

```

Chaque service démarre dans son propre thread, nous n'avons pas à le gérer.

## Avantages

Donc le premier avantage c'est de pouvoir déboguer toute la chaîne de démarrage de votre service.

Autre avantage c'est que vous pouvez créer un mécanisme de log qui s'affiche sur la console, c'est lisible et direct.

## Inconvénients

Il y a toutefois quelques inconvénients.

Un service Windows s'exécute de manière générale avec un compte Administrateur (LocalSystem, LocalNetwork, etc.), ce qui peut vous poser des problèmes de droit en fonction de ce que fait votre service. Vous pouvez résoudre ce souci en exécutant Visual Studio en tant qu'administrateur, en lancer votre service il aura des droits administrateurs.

Un service, lorsqu'il démarre, exécute certaines tâches (création d'une source dans les journaux Windows, etc.) notre petite application ne fait rien de tout ça. A vous de préparer le terrain convenablement pour déboguer votre service.

## Remarque

Attention ce mode ne vous affranchit pas de déboguer en mode service, il vous permet de déboguer plus rapidement votre service, mais faîtes des tests en mode service pour s'assurer du bon fonctionnement de votre service dans son mode normal.


# Installation et Désinstallation du service

Un service pour fonctionner, doit être installé (il s'enregistre auprès du ServiceManager de Windows). Pour installer un service compilé en .Net il faut utiliser la commande "InstallUtil.exe" se trouvant dans le dossier du Framework .Net concerné.

Cette commande est parfois un peu longue à écrire, de même que lorsqu'il faut installer le service via un installeur, il est nécessaire de repérer le dossier du framework corrspondant, etc.

Comme nous avons maintenant une application console, nous pouvons l'utiliser pour nous faciliter le travail. Par exemple en utisant des arguments de commande en ligne pour installer/désinstaller le service. 

Pour gérer cette installation/désinstallation nous avons à notre disposition une classe `System.Configuration.Install.ManagedInstallerClass` qui possède des méthodes utilitaires pour celà.

Nous allons donc modifier notre application console pour supporter des 'commandes' d'installation (`install`) et de désinstallation (`uninstall`).

Nous allons devoir modifier le comportement de notre application:
- si on est en mode débogage on exécute de manière interactive les services
- si on est en mode interactif, on vérifie si on a des commandes. Si c'est le cas on exécute nos commandes, sinon on affiche un message d'aide.
- si on n'est pas en mode interactif, on exécute normalement les services.

On créé une méthode `HasCommand` nous permettant de déterminer si on a une commande spécifique dans la ligne de commande :
``` csharp

/// <summary>
/// Utilitaire permettant de déterminer si nous avons une commande dans les arguments de commande en ligne
/// </summary>
static bool HasCommand(String[] args, String command)
{
    if (args == null || args.Length == 0 || String.IsNullOrWhiteSpace(command)) return false;
    return args.Any(a => String.Equals(a, command, StringComparison.OrdinalIgnoreCase));
}

```

Ensuite nous modifions notre méthode Main pour supporter les arguments, et pour traiter les commandes :

``` csharp

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
                // On a une commande d'installation ?
                if (HasCommand(args, "install"))
                {
                    ManagedInstallerClass.InstallHelper(new String[] { typeof(Program).Assembly.Location });
                    hasCommands = true;
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
                    Console.WriteLine(" - install : Installation du service");
                    Console.WriteLine(" - uninstall : Désinstallation du service");
                }
            }
            catch (Exception ex)
            {
                var oldColor = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur : {0}", ex.GetBaseException().Message);
                Console.BackgroundColor = oldColor;
            }
        }
    }
    else
    {
        // Exécute les services normalement
        ServiceBase.Run(ServicesToRun);
    }
}

```

# Démarrage et Arrêt du service

Même principe que pour l'installation, pour démarrer et arrêter notre service nous devons passer par une ligne de commande "net start/stop" ou par le gestionnaire de service.

Pour les mêmes raisons que précédemment, on va faire de sorte de pouvoir démarrer ou arrêter le service grâce à des arguments de l'application console. Pour celà on utilise la classe `System.ServiceProcess.ServiceController`.

Nous allons donc ajoutons deux commandes `start` et `stop` entre nos deux commandes d'installation et de déinstallation.

``` csharp

...
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
...

```

La manière dont nous traitons les commandes nous permet de combiner l'installation et le démarrage en une seule commande en ligne. De même que pour l'arrêt et la désinstallation.

```
WinServiceTest.exe install start
WinServiceTest.exe uninstall stop
```

L'ordre des commandes n'est pas important car nous testons les commandes dans l'ordre qui nous importe (on teste 'stop' avant de tester 'uninstall').

# Aller plus loin

Bien sûr on peut ajouter différentes commandes utilitaires.

## Commande combinant installation et démarrage

On créer une commande qui va traiter une seule commande pour l'installataion et le démarrage. De même que l'arrêt et la désinstallation.

Dans notre exemple, nous implémentons celà avec les commandes 'start-services' et 'stop-services', nous exécutons ces commandes en priorité.

## Exécuter les services en mode interactif

Nous exécutons les services en mode interactif uniquement en mode débogage. Toutefois il peut vous être utile d'exécuter les services en mode interactif. Vous pouvez par conséquent ajouter une commande pour exécuter les services.

Dans notre exemple, nous implémentons celà avec la commande 'run-services'.

