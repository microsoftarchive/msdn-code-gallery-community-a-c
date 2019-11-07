namespace ContextMenuBindSample
{
    /// <summary>
    /// ContextMenuの1項目を表すViewModel
    /// </summary>
    public class MenuItemViewModel
    {
        /// <summary>
        /// ContextMenuに表示するテキスト
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// ContextMenuに表示するテキストを指定してインスタンスを作成します。
        /// </summary>
        /// <param name="text">ContextMenuに表示するテキスト</param>
        public MenuItemViewModel(string text)
        {
            this.Text = text;
        }
    }
}
