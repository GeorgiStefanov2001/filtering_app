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
        CarViewModel carViewModel;

        public MainWindow()
        {
            InitializeComponent();
            movieViewModel = new MovieViewModel();
            carViewModel = new CarViewModel();
            DataContext = movieViewModel;
        }

        public void EntitySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            ComboBoxItem item = (ComboBoxItem)cmb.SelectedItem;
            switch (item.Content.ToString())
            {
                case "Movies":
                    DataContext = movieViewModel;
                    break;
                case "Cars":
                    DataContext = carViewModel;
                    break;
            }
        }

        public void chkAttr_CheckedAndUnchecked(object sender, RoutedEventArgs e)
        {
            //Since the DataContext changes between different ViewModels,
            //it needs to be casted runtime to the correct ViewModel
            var ViewModel = Cast(DataContext, DataContext.GetType()); //I am so sorry for doing this, but I had to :(
            if (ViewModel != null)
            {
                ViewModel.AttrCheckedUnchecked();
            }
        }

        private static dynamic Cast(dynamic obj, Type castTo)
        {
            return Convert.ChangeType(obj, castTo);
        }

    }
}
