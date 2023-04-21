using PSProject.Model;
using PSProject.ViewModel;
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

namespace PSProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovieViewModel movieViewModel;
        public MainWindow()
        {
            InitializeComponent();
            movieViewModel = new MovieViewModel();
        }

        public void EntitySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            ComboBoxItem item = (ComboBoxItem)cmb.SelectedItem;
            switch (item.Content.ToString())
            {
                case "Movies":
                    this.DataContext = movieViewModel;
                    break;
                case "Cars":
                    break;
            }
        }

        public void chkAttr_CheckedAndUnchecked(object sender, RoutedEventArgs e)
        {
            var ViewModel = (MovieViewModel)this.DataContext; // store this in var and switch it for different models
            if(ViewModel != null)
            {
                ViewModel.AttrCheckedUnchecked();
            }
        }

    }
}
