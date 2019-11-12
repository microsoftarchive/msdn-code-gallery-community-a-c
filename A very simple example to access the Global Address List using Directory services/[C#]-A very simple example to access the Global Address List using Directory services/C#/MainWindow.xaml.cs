using System.DirectoryServices;
using System.Linq;
using System.Windows;

namespace GlobalAddressListSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = GetGlobalAddressList();

            this.InitializeComponent();
        }

        public static Address[] GetGlobalAddressList()
        {
            using (var searcher = new DirectorySearcher())
            {
                using (var entry = new DirectoryEntry(searcher.SearchRoot.Path))
                {
                    searcher.Filter = "(&(mailnickname=*)(objectClass=user))";
                    searcher.PropertiesToLoad.Add("cn");
                    searcher.PropertyNamesOnly = true;
                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.Sort.Direction = SortDirection.Ascending;
                    searcher.Sort.PropertyName = "cn";
                    return searcher.FindAll().Cast<SearchResult>().Select(result => new Address(result.GetDirectoryEntry())).ToArray();
                }
            }
        }
    }
}
