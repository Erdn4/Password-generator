using System.Runtime.InteropServices;
using System.Security.Cryptography;
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

namespace PasswordGenerator
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

        protected Random rnd = new Random();
       
        protected void Button_Click(object sender, RoutedEventArgs e)
        {   // Password length is controlled via the slider "Slider": min 15, max 25
            int lenght = (int)Slider.Value;
            string password = GeneratePassword(lenght);
            // Password output in Textbox
            Textbox.Text = password;
        }

        protected string GeneratePassword(int lenght)
        {   // Strings sorted by type
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";
            string special = "!$%&?=+-#*";

            // All desired data types together in one string "chars"
            // Preparing for possible changes to the selection
            string chars = "";

            chars += lowercase;
            chars += uppercase;
            chars += numbers;
            chars += special;

            StringBuilder sb = new StringBuilder();
            // Generating a random password
            for (int i = 0; i < lenght; i++) 
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();

        }
    }
}