using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
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
using WpfApp_sqlite.Database;
using WpfApp_sqlite.Model;

namespace WpfApp_sqlite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public My_database my_Database = new My_database();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Profile> list = new List<Profile>();   
            list = my_Database.Loaddata("profile");
            /*
            listview.ItemsSource= list;
            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(listview.ItemsSource);
            collectionView.Refresh();
            */
        }

        private void create_database_Click(object sender, RoutedEventArgs e)
        {
           
            my_Database.Create_datatable();
        }

        private void create_table_Click(object sender, RoutedEventArgs e)
        {
            my_Database.Create_table("profile");
        }

        private void tao_ban_ghi_Click(object sender, RoutedEventArgs e)
        {
            Profile myprofile = new Profile();
            myprofile.Email = "anhhienbadao@gmail.com";
            myprofile.Password = "aaaaa";
            myprofile.Status =1;
            var result = my_Database.Add_data("profile", myprofile);
            Debug.WriteLine(result);
        }

        private void doc_ban_ghi_Click(object sender, RoutedEventArgs e)
        {
            List<Profile> profiles = new List<Profile>();
            profiles = my_Database.Loaddata("profile");
            foreach (Profile profile in profiles)
            {
                Debug.WriteLine(profile.Email);
            }
        }

        private void xoa_ban_ghi_Click(object sender, RoutedEventArgs e)
        {
            int result = my_Database.Delete_data("anhhienbadao@gmail.com");
            Debug.WriteLine(result);
           
        }

        private void xoa_ban_ghi1_Click(object sender, RoutedEventArgs e)
        {
            int update = my_Database.Update_data("profile", "Ahiendam", "anhhienbadao@gmail.com");
            Debug.WriteLine(update);
        }
    }
}
