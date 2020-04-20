using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SettingsManager.Commands;

namespace SettingsManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<SettingsFile> files = new ObservableCollection<SettingsFile>();
        public MainWindow()
        {
            InitializeComponent();

            lvSettingFiles.ItemsSource = files;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateColumnsWidth(sender as ListView);
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateColumnsWidth(sender as ListView);
        }

        private void UpdateColumnsWidth(ListView listView)
        {
            int autoFillColumnIndex = (listView.View as GridView).Columns.Count - 1;
            if (listView.ActualWidth == Double.NaN)
                listView.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            double remainingSpace = listView.ActualWidth;
            for (int i = 0; i < (listView.View as GridView).Columns.Count; i++)
                if (i != autoFillColumnIndex)
                    remainingSpace -= (listView.View as GridView).Columns[i].ActualWidth;
            (listView.View as GridView).Columns[autoFillColumnIndex].Width = remainingSpace >= 0 ? remainingSpace : 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ApplicationSettings form = new ApplicationSettings();
            //form.Owner = this;
            form.ShowDialog();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            files.Add(new SettingsFile { InUse = true, Description = "test", FileLocation = "test" });
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (lvSettingFiles.SelectedItem != null)
            {
                files.Remove(lvSettingFiles.SelectedItem as SettingsFile);
            }
        }
    }
}
