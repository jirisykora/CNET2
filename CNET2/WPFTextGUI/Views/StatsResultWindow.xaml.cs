﻿using System;
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

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
