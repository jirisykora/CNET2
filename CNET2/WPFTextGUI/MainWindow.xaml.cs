using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTextGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string bigfilesdir = @"D:\Source\Repos\CNET2\CNET2\BigFiles";

        static IEnumerable<string> GetFilesFromDir(string dir)
        {
            return Directory.EnumerateFiles(dir);
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var bookdir = @"D:\Source\Repos\CNET2\CNET2\Playground\Books";

            //foreach (var file in GetFilesFromDir(bookdir))
            //{
            //    var dict = TextTools.TextTools.FreqAnalyze(file);
            //    var top10 = TextTools.TextTools.GetTopWord(10, dict);

            //    var fi = new FileInfo(file);


            //    var top10_list = top10.Select(x => $"{x.Key} : {x.Value}").ToList();
            //    txbInfo.Text += "KNIHA: " + fi.Name + Environment.NewLine;  
            //    foreach (var item in top10_list)
            //    {
            //        txbInfo.Text += item + Environment.NewLine;
            //    }

            //}
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            txbInfo.Text = "";
            txbDebugInfo.Text = "";
            Stopwatch stopwatch = new Stopwatch();  
            stopwatch.Start();

            

            var files = Directory.EnumerateFiles(bigfilesdir, "*.txt");
            foreach (var file in files)
            {
                var dict = await TextTools.TextTools.FreqAnalyzeFromFileAsync(file, Environment.NewLine);
                var top10 = TextTools.TextTools.GetTopWord(10, dict);

                var fi = new FileInfo(file);

                var top10_list = top10.Select(x => $"{x.Key} : {x.Value}").ToList();
                txbInfo.Text += "KNIHA: " + fi.Name + Environment.NewLine;
                foreach (var item in top10_list)
                {
                    txbInfo.Text += item + Environment.NewLine;
                }

            }

            stopwatch.Stop();
            txbDebugInfo.Text = "elapsed ms: " + stopwatch.ElapsedMilliseconds;
            Mouse.OverrideCursor = null;

        }

        private void btnStatsAll_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
