using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace LiteDbTestApp
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dbstring = Path.Combine(ApplicationData.Current.LocalFolder.Path, "PersonData.db").ToString();

            using (var db = new LiteDatabase(dbstring))
            {
                // Get datamodel collection
                var datas = db.GetCollection<DataModel>("presondata");

                // Create new DataModel instance
                var data = new ObservableCollection<DataModel>()
                {
                    new DataModel(){LastName = "紫山", FirstName = "太郎", Height = (float)167.5, Weight = (float)69.1 },
                    new DataModel(){LastName = "寺岡", FirstName = "次郎", Height = (float)193.0, Weight = (float)82.5 },
                    new DataModel(){LastName = "高森", FirstName = "三郎", Height = (float)174.8, Weight = (float)75.6 },
                    new DataModel(){LastName = "桂", FirstName = "四郎", Height = (float)186.3, Weight = (float)93.7 }
                };

                // Insert
                datas.Insert(data);

            }
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            var dbstring = Path.Combine(ApplicationData.Current.LocalFolder.Path, "PersonData.db").ToString();

            using (var db = new LiteDatabase(dbstring))
            {
                // Get datamodel collection
                var datas = db.GetCollection<DataModel>("presondata");

                // Read
                var datasource = datas.FindAll().ToList();

                list.ItemsSource = datasource;
            }
        }
    }
}
