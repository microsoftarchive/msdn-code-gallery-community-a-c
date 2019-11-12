using System.Linq;
using System.Windows.Forms;

public static class CheckedListBoxExtensions
{
    /// <summary>
    /// Find item, set check state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="Text">text to locate case insensitive</param>
    /// <param name="Checked">set check state to</param>
    /// <remarks></remarks>
    public static void FindItemAndSetChecked(this CheckedListBox sender, string Text, bool Checked)
    {
        // Result is declared with var as it's a anonymous type
        var Result =
            (
                from @this in sender.Items.Cast<string>().Select(
                    (item, index) => new
                        {
                            Item = item,
                            Index = index
                        }
                    )
                where @this.Item.ToLower() == Text.ToLower()
                select @this
            ).FirstOrDefault();

        if (Result != null)
        {
            sender.SetItemChecked(Result.Index, Checked);
        }
    }
}