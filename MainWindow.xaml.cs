using CinemaApp.infrastructure;
using CinemaApp.models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            /*ModelGeneration generation = new ModelGeneration();
            
                string command = string.Format($"SELECT table_name FROM information_schema.tables WHERE table_schema = 'Film'");
                generation.Generation(command);*/

            string cmdFilm = String.Format($"select * from \"Film\".film f");

            string cmdType = String.Format($"select * from \"Film\".seance_type st");

            string cmdSeance = String.Format($"select * from \"Film\".seance st");

            string cmdClient = String.Format($"select * from \"Film\".client c");
            
            string cmdPlace = String.Format($"select * from \"Film\".place p");


            var films = Entity.Execute<film>(cmdFilm);

            var types = Entity.Execute<seance_type>(cmdType);

            var seance = Entity.Execute<seance>(cmdSeance);

            var client = Entity.Execute<client>(cmdClient);

            var place = Entity.Execute<place>(cmdPlace);

            cmbFilm.ItemsSource = films;
            cmbType.ItemsSource = types;
            cmbSeance.ItemsSource = seance;
            cmbClient.ItemsSource = client;
            cmbPlace.ItemsSource = place;
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            order newUser = new order
            {
               // client = client,
               // = seance_film,
               //place = place,
            };

            //DBconn.
            //DBconn.
            //MessageBox.Show("Успешно сохранено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        
    }
}