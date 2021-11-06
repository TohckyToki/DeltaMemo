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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.IconPacks;

namespace DeltaMemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainWinfowModel model { get; set; }
        private bool isClosed { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            model = this.DataContext as MainWinfowModel;
        }

        private void AddWindow(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
        }

        private void SwitschDisplay(object sender, RoutedEventArgs e)
        {
            this.ShowInTaskbar = !this.ShowInTaskbar;
            model.Display = this.ShowInTaskbar ? PackIconMaterialKind.EyeOutline.ToString() : PackIconMaterialKind.EyeOffOutline.ToString();
        }

        private void SwitschInTop(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
            model.InTop = this.Topmost ? PackIconMaterialKind.PinOutline.ToString() : PackIconMaterialKind.PinOffOutline.ToString();
        }

        private void IncreaseLineHeight(object sender, RoutedEventArgs e)
        {
            if (model.LineHeight < 10)
            {
                model.LineHeight++;
            }
        }

        private void DecreaseLineHeight(object sender, RoutedEventArgs e)
        {
            if (model.LineHeight > 1)
            {
                model.LineHeight--;
            }
        }

        private void ToggleToolbar(object sender, RoutedEventArgs e)
        {
            if (model.IsShowToolbar == Visibility.Visible)
            {
                model.IsShowToolbar = Visibility.Collapsed;
                model.ToggleToolbarButtonText = PackIconMaterialKind.ChevronUp.ToString();
            }
            else
            {
                model.IsShowToolbar = Visibility.Visible;
                model.ToggleToolbarButtonText = PackIconMaterialKind.ChevronDown.ToString();
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var text = new TextRange(mainRTB.Document.ContentStart, mainRTB.Document.ContentEnd).Text;
            if (text.Length > 0 && isClosed == false)
            {
                Dialog.IsOpen = true;
                e.Cancel = true;
            }
        }

        private void Dialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if (((bool?)eventArgs.Parameter) ?? false)
            {
                this.isClosed = true;
                this.Close();
            }
        }
    }
}
