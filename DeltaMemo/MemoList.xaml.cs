using MahApps.Metro.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeltaMemo
{
    /// <summary>
    /// Interaction logic for MemoList.xaml
    /// </summary>
    public partial class MemoList : MetroWindow
    {
        private MemoListModel model { get; set; }

        public MemoList()
        {
            InitializeComponent();
            model = this.DataContext as MemoListModel;
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var http = new HttpClient();
            var a = await http.GetAsync("http://localhost:5000/contents");
            if (a.IsSuccessStatusCode)
            {
                var s = await a.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<Content>>(s);
                model.Contents = list;
            }
        }

        private void SwitchDisplay(object sender, RoutedEventArgs e)
        {
            model.IsOption = model.IsList;
            model.IsList = !model.IsOption;
        }
    }
}
