namespace ContextMenuBindSample
{
    using Microsoft.Practices.Prism.Commands;

    /// <summary>
    /// MainWindow用のViewModleクラス
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private MenuItemViewModel currentMenuItem;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            // コマンドの初期化
            this.SetMenu1Command = new DelegateCommand(
                () => this.CurrentMenuItem = new MenuItemViewModel("Menu1"));

            this.SetMenu2Command = new DelegateCommand(
                () => this.CurrentMenuItem = new MenuItemViewModel("Menu2"));
        }

        /// <summary>
        /// 現在表示したいContextMenuのMenuItem
        /// </summary>
        public MenuItemViewModel CurrentMenuItem
        {
            get
            {
                return this.currentMenuItem;
            }

            set
            {
                this.currentMenuItem = value;
                this.RaisePropertyChanged(() => CurrentMenuItem);
            }
        }

        /// <summary>
        /// Menu1と表示されたMenuをContextMenuに設定するコマンド
        /// </summary>
        public DelegateCommand SetMenu1Command { get; private set; }

        /// <summary>
        /// Menu2と表示されたMenuをContextMenuに設定するコマンド
        /// </summary>
        public DelegateCommand SetMenu2Command { get; private set; }
    }
}
