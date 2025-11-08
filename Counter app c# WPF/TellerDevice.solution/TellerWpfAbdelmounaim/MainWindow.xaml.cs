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
using TellerDomainAbdelmounaim;
using System.IO;

namespace TellerWpfAbdelmounaim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Ik maar hieronder een tellerModel Aan
        public TellerModelAbdelmounaim Teller = new TellerModelAbdelmounaim();
      
      
        public MainWindow()
        {
            InitializeComponent();
            buttonVerhoog.IsEnabled = false;
            buttonReset.IsEnabled = false;
            try
            {
                using (StreamReader sr = new StreamReader("Teller.txt"))
                {
                    textboxTellerScreen.Text = sr.ReadLine();
                    sr.Close();
                }
                buttonVerhoog.IsEnabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Welcome");
            }
         
        }

        private  void buttonVerhoog_Click(object sender, RoutedEventArgs e)
        {
            Teller.Verhogen();
            using (StreamWriter sw = new StreamWriter("Teller.txt"))
            {
                sw.Write(Teller.LeesTeller());
                sw.Close();
            }


            string tellerInText;
            using (StreamReader sr = new StreamReader("Teller.txt"))
            {
                textboxTellerScreen.Text = sr.ReadLine();
                sr.Close();
            }
            buttonReset.IsEnabled = true;
            
           
            

        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            Teller.Resetten();
            using (StreamWriter sw = new StreamWriter("Teller.txt"))
            {
                sw.Write(Teller.LeesTeller());
                sw.Close();
            }

            using (StreamReader sr = new StreamReader("Teller.txt"))
            {
                textboxTellerScreen.Text = sr.ReadLine();
                sr.Close();
            }

           
        }

        private void buttonOnOff_Click(object sender, RoutedEventArgs e)
        {
            if (buttonOnOff.Content.ToString() == "On")
            {
                try
                {
                    using (StreamReader sr = new StreamReader("Teller.txt"))
                    {
                        textboxTellerScreen.Text = sr.ReadLine();
                        sr.Close();
                    }
                    buttonVerhoog.IsEnabled = true;
                }
                catch(Exception exception)
                {
                    MessageBox.Show("Welcome");
                }
                buttonOnOff.Content = "Off";
              
            } else if (buttonOnOff.Content.ToString() == "Off")
            {
                textboxTellerScreen.Text = "0";
                buttonVerhoog.IsEnabled = false;
                buttonReset.IsEnabled = false;
                buttonOnOff.Content = "On";
            }
         
            
        }
    }
}
