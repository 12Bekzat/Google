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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Google
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabLoader(object sender, RoutedEventArgs e)
        {
            tabControl = (sender as TabControl);
        }

        private TabItem tabItem = new TabItem();

        private void SearchTextAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                WebBrowser browser = new WebBrowser();
                string url = "https://www.google.com/search?q=*";
                url = url.Replace("*", searchByText.Text);
                browser.Navigate(url);

                if (String.IsNullOrWhiteSpace(searchByText.Text))
                {
                    MessageBox.Show("Неверный поисковой запрос!");
                    return;
                }

                tabItem = new TabItem
                {
                    Height = 20,
                    Width = 80,
                    Header = searchByText.Text,
                    Content = (browser as WebBrowser)
                };

                tabControl.Items.Add(tabItem);
                tabItem.IsSelected = true;
                searchByText.Text = String.Empty;
            }
            catch
            {
                MessageBox.Show("Неверный поисковой запрос!");
            }
        }

        private void SearchUrlAddress(object sender, RoutedEventArgs e)
        {
            try
            {
                WebBrowser browser = new WebBrowser();
                browser.Navigate(searchByUrl.Text);

                tabItem = new TabItem
                {
                    Height = 20,
                    Width = 80,
                    Header = "Url Tab",
                    Content = (browser as WebBrowser)
                };

                tabControl.Items.Add(tabItem);
                tabItem.IsSelected = true;
                searchByUrl.Text = String.Empty;
            }
            catch
            {
                MessageBox.Show("Неверный URL адрес!");
            }
        }

        private void TabEventRemove(object sender, MouseButtonEventArgs e)
        {
            tabControl.Items.Remove(tabControl.SelectedItem);
        }
    }
}
