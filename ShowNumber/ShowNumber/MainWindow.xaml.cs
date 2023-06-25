using Newtonsoft.Json;
using RestSharp;
using ShowNumber.Models;
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

namespace ShowNumber
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextNumber.Text) || TextNumber.Text.Length != 13 || TextNumber.Text[0] != '+')
                {
                    // Видавання помилки, оскільки поле не задовольняє вимоги
                    
                    throw new Exception("Невірний формат номера");
                }

                var client = new RestClient($"https://api.apilayer.com/number_verification/validate?number={TextNumber.Text}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("apikey", "SzDt7gQLQHqgbXhOLp7XmPDg5k867vyr");
                IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);
                string jsonData = response.Content;

                PhoneData phoneData = JsonConvert.DeserializeObject<PhoneData>(jsonData);

                // Доступ до окремих елементів
                bool valid = phoneData.Valid;
                string number = phoneData.number;
                string localFormat = phoneData.local_format;
                string internationalFormat = phoneData.international_format;
                string countryPrefix = phoneData.country_prefix;
                string countryCode = phoneData.country_code;
                string countryName = phoneData.country_name;
                string location = phoneData.location;
                string carrier = phoneData.carrier;
                string lineType = phoneData.line_type;

                T_valid.Text = valid ? "так" : "ні";
                T_number.Text = number;
                T_localFormat.Text = localFormat;
                T_internationalFormat.Text = internationalFormat;
                T_countryPrefix.Text = countryPrefix;
                T_countryCode.Text = countryCode;
                T_countryName.Text = countryName;
                T_location.Text = location;
                T_carrier.Text = carrier;
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Дані не було прийнято. Код помилки 789", "Помилка при спробі взлому номера!");
                

            }


        }
    }
}
