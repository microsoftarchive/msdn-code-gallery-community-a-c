using ClientApp.Common;
using ClientApp.Models.ODataV4Sample;
using ClientApp.Models.ODataV4Sample.Models;
using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ClientApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 基本ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234237 を参照してください

namespace ClientApp
{
    /// <summary>
    /// 多くのアプリケーションに共通の特性を指定する基本ページ。
    /// </summary>
    public sealed partial class ListPage : Page
    {
        private Container container = new Container(new Uri(Constants.Uri));
        private ObservableCollection<Person> people;

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// これは厳密に型指定されたビュー モデルに変更できます。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper は、ナビゲーションおよびプロセス継続時間管理を
        /// 支援するために、各ページで使用します。
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public ListPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
        /// 再作成する場合は、保存状態も指定されます。
        /// </summary>
        /// <param name="sender">
        /// イベントのソース (通常、<see cref="NavigationHelper"/>)>
        /// </param>
        /// <param name="e">このページが最初に要求されたときに
        /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたナビゲーション パラメーターと、
        /// 前のセッションでこのページによって保存された状態の辞書を提供する
        /// セッション。ページに初めてアクセスするとき、状態は null になります。</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
        /// このページに関連付けられた状態を保存します。値は、
        /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
        /// </summary>
        /// <param name="sender">イベントのソース (通常、<see cref="NavigationHelper"/>)</param>
        /// <param name="e">シリアル化可能な状態で作成される空のディクショナリを提供するイベント データ
        ///。</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper の登録

        /// このセクションに示したメソッドは、NavigationHelper がページの
        /// ナビゲーション メソッドに応答できるようにするためにのみ使用します。
        /// 
        /// ページ固有のロジックは、
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// および <see cref="GridCS.Common.NavigationHelper.SaveState"/> のイベント ハンドラーに配置する必要があります。
        /// LoadState メソッドでは、前のセッションで保存されたページの状態に加え、
        /// ナビゲーション パラメーターを使用できます。

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = null;
            try
            {
                var skip = int.Parse(this.textBoxSkip.Text);
                var take = int.Parse(this.textBoxTake.Text);

                var query = (DataServiceQuery<Person>)container.People
                    .Skip(skip)
                    .Take(take);
                this.people = new ObservableCollection<Person>(await query.ExecuteAsync());

                this.listBoxPeople.ItemsSource = people;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                var dialog = new MessageDialog(errorMessage);
                await dialog.ShowAsync();
            }
        }

        private void listBoxPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = (Person)e.AddedItems.FirstOrDefault();
            if (person == null) { return; }

            var target = new Person
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age
            };

            this.stackPanelEditArea.DataContext = target;
        }

        private async void buttonCommit_Click(object sender, RoutedEventArgs e)
        {
            var current = (Person)this.stackPanelEditArea.DataContext;

            var target = await this.container.People.ByKey(current.Id).GetValueAsync();
            target.Name = current.Name;
            target.Age = current.Age;
            this.container.ChangeState(target, EntityStates.Modified);
            var results = await this.container.SaveChangesAsync();
            if (results.Any())
            {
                var message = string.Join(Environment.NewLine, results.Select(r => "StatusCode: " + r.StatusCode));
                var dialog = new MessageDialog(message);
                await dialog.ShowAsync();
            }
        }

        private async void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            var current = (Person)this.stackPanelEditArea.DataContext;

            var target = await this.container.People.ByKey(current.Id).GetValueAsync();
            this.container.ChangeState(target, EntityStates.Deleted);
            var results = await this.container.SaveChangesAsync();
            if (results.Any())
            {
                var message = string.Join(Environment.NewLine, results.Select(r => "StatusCode: " + r.StatusCode));
                var dialog = new MessageDialog(message);
                await dialog.ShowAsync();
            }

            this.people.Remove(target);
        }
    }
}
