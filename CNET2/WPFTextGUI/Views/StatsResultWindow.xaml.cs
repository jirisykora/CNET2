using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WPFTextGUI.Model;

namespace WPFTextGUI.Views
{
    /// <summary>
    /// Interaction logic for StatsResultWindow.xaml
    /// </summary>
    public partial class StatsResultWindow : Window
    {
        public StatsResultWindow(Model.StatsResult result)
        {
            InitializeComponent();

            // data binding - nastavime datacontext pro nasi kontrolku UserControl StatsResultView
            // tim svazeme data s prvky v okne.
            // v kontrolce pridame do definice property DataContext="{Binding}"
            DataContext = result;
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var result = (StatsResult)DataContext;

            var apiurl = Data.Data.APIUrl;

            using var client = new HttpClient();
            client.BaseAddress = new Uri(apiurl);

            var res = await client.PostAsJsonAsync("/stats", result);
            if (res.IsSuccessStatusCode)
                this.Close();
            else
                MessageBox.Show("Chyba");
        }
    }
}
