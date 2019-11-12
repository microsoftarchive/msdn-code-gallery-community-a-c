using System.Windows;
using System.Windows.Interop;

namespace ModernWPF.Win8TouchKeyboard.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Disables inking in the WPF application and enables us to track touch events to properly trigger the touch keyboard
            InkInputHelper.DisableWPFTabletSupport();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Enables WPF to mark edit field as supporting text pattern (Automation Concept)
            System.Windows.Automation.AutomationElement asForm =
                System.Windows.Automation.AutomationElement.FromHandle(new WindowInteropHelper(this).Handle);

            // Windows 8 API to enable touch keyboard to monitor for focus tracking in this WPF application
            InputPanelConfigurationLib.InputPanelConfiguration inputPanelConfig = new InputPanelConfigurationLib.InputPanelConfiguration();
            inputPanelConfig.EnableFocusTracking();
        }
    }
}
