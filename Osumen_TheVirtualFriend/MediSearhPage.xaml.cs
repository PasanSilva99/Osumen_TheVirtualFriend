using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Osumen_TheVirtualFriend
{
    /// <summary>
    /// Interaction logic for MediSearhPage.xaml
    /// </summary>
    public partial class MediSearhPage : Page
    {
        public MediSearhPage()
        {
            InitializeComponent();
        }

        private void searchtextbox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void appointmentbutton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tiptext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Tiptext_Loaded(object sender, RoutedEventArgs e)
        {
            string contip = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C: \Users\hdalp\OneDrive - National School of Busness Management\Documents\Osumen.mdf';Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(contip))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT tip FROM Dailytips Where ID = 2"))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Tiptext.Text = sdr.ToString();
                    }
                    con.Close();

                         
                }
            }
        }
    }
}
