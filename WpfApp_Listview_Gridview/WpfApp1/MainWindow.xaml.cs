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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ButtonName{
          get;set;
           
        }
        public ICommand Exitrow { get; set; }
        public ObservableCollection<Person> Persons { get; set; }   
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ButtonName = "day la button name";
            ObservableCollection<Person> list = new ObservableCollection<Person> {
               new Person { Hoten = "hien", Tuoi = 33 },
                new Person { Hoten = "tuyet", Tuoi = 33 },
            };
            listview.ItemsSource = list;
            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(listview.ItemsSource);
            collectionView.Filter = FilterListview;



            Exitrow = new RelayCommand<Person>(
               (p) => { return true; },
               (p) => {
                   System.Diagnostics.Debug.WriteLine(p.Hoten);
               }
               );
         
        }


        public bool FilterListview(object item)
        {
            if (String.IsNullOrEmpty(search.Text))
                return true;
            else
                return ((item as Person).Hoten.IndexOf(search.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

            CollectionViewSource.GetDefaultView(listview.ItemsSource).Refresh();
        }



        private void bt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You are click");
        }
        public class User
        {
            public string Name { get; set; }
            public int Tuoi { get; set; }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(String.IsNullOrEmpty(search.Text))
            {
                return;
            }
           
        }
    }
   
}
