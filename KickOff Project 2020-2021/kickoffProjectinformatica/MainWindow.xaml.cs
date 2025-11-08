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
using System.IO;
using Microsoft.Win32;


namespace kickoffProjectinformatica
{
    /// <summary>
    /// Bij sommigge commentaren zet ik field[i] om te zeggen welke veld-Index het heeft gekregen bij het "splitten".
    /// Om te beginnen programmeerde ik vanaf de top van formulier naar de grond van formulier al criteria's.
    /// Eerst maakte ik de formulier, programmeerd ik of  "we" :p de toevoeging, daarna de wijziging, daarna het verwijderen, menu open
    /// , resetknop, en uiteindelijk het zoeken 
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variabelen
        int Id = 1;
        DateTime Geboortedatum = new DateTime();
        DateTime Jaartweeduizend = new DateTime(2000, 1, 1);
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string BestandsNaam;

        string FNaam;
        string VNaam;
        string GDatum;
        string RRN;
        string MOfV;
        string StraatNaam;
        string HuisNummer;
        string PCode;
        string Gemeente;
        string Telefoon;
        string Email;
        string aantalGezinLeden;
        string TypeContact;
        string opgebeld;

       
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sav1 = new SaveFileDialog();
      


        public MainWindow()
        {
            InitializeComponent();
            //
            BestandsNaam = "";
            textBoxId.Text = Convert.ToString(Id);

         


        }

        private void textBoxNaam_KeyUp(object sender, KeyEventArgs e)//famielienaam intypen (stap1)=field[1]
        {
            string naam = textBoxNaam.Text;
            if (naam.Length != 0)
            {
                textBoxVoornaam.IsEnabled = true;
            }
            else
            {
                textBoxVoornaam.IsEnabled = false;
            }

        }

        private void textBoxVoornaam_KeyUp(object sender, KeyEventArgs e)//Voornaam intypen (stap2)=field[2]
        {
            string voornaam = textBoxVoornaam.Text;
            if (voornaam.Length !=0)
            {
                dpGeboorte.IsEnabled = true;
            }
            else
            {
                dpGeboorte.IsEnabled = false;
            }
        }

        private void dpGeboorte_SelectedDateChanged(object sender, SelectionChangedEventArgs e) //Geboortedatum invoegen (stap3)=field[3]
        {
            Geboortedatum = Convert.ToDateTime(dpGeboorte.SelectedDate);
            textBoxRRN.IsEnabled = true;
        }

        private void textBoxRRN_KeyUp(object sender, KeyEventArgs e)//RRN intypen (stap4)=field[4]
        {

            string rrn = textBoxRRN.Text;
            try
            {
                long rrnGetal = Convert.ToInt64(rrn);
            }
            catch (FormatException exeption1)
            {
                if (textBoxRRN.Text == "")
                {
                    return;
                }
                textBoxRRN.Text = "";
            }


            if (rrn.Length == 11 && Geboortedatum < Jaartweeduizend)
            {
                int variabeleA = int.Parse(rrn.Substring(0, 9));
                int variabeleB = int.Parse(rrn.Substring(9));
                int variabeleC = variabeleA % 97;
                if (97 - variabeleC == variabeleB)
                {
                    comboBoxGeslacht.IsEnabled = true;
                }
            }

            if (rrn.Length == 11 && Geboortedatum > Jaartweeduizend)
            {
                string rrn2 = 2 + rrn;
                long variabeleAa = Convert.ToInt64(rrn2.Substring(0, 10));
                long variabeleBb = Convert.ToInt64(rrn2.Substring(10));
                long variabeleCc = variabeleAa % 97;
                if (97 - variabeleCc == variabeleBb)
                {
                    comboBoxGeslacht.IsEnabled = true;
                }
            }


            if (rrn.Length != 11)
            {
                comboBoxGeslacht.IsEnabled = false;

            }
        }



        private void comboBoxGeslacht_SelectionChanged(object sender, SelectionChangedEventArgs e)//geslacht kiezen (stap5)=field[5]
        {
            textBoxStraatNaam.IsEnabled = true;
        }

        private void textBoxStraatNaam_KeyUp(object sender, KeyEventArgs e)//Straatnaam intypen( stap6)= field[6]
        {
            textBoxHuisNr.IsEnabled = true;
        }


        private void textBoxHuisNr_KeyUp(object sender, KeyEventArgs e)//Huis-nummer (stap7)= field[7]
        {

            textBoxpostcode.IsEnabled = true;
        }

        private void textBoxpostcode_KeyUp(object sender, KeyEventArgs e)//Postcode invoegen (stap8)=field[8]
        {
            string str = textBoxpostcode.Text;

            try
            {
                int postcode = int.Parse(str);
            }
            catch (FormatException exeption2)

            {
                if (textBoxpostcode.Text == "")
                {
                    return;
                }
                MessageBox.Show("De postCode moet een geldig getal zijn bestaande uit 4 cijfers");
                textBoxpostcode.Text = "";
            }


            if (str.Length == 4)
            {
                textBoxGemeente.IsEnabled = true;
            }
           else
            {
                textBoxGemeente.IsEnabled = false;
               
            }

        }
        private void textBoxGemeente_KeyUp(object sender, KeyEventArgs e)//gemeente invoegen stap9=field[9]
        {
            textBoxTelefoon.IsEnabled = true;
        }
        private void textBoxTelefoon_KeyUp(object sender, KeyEventArgs e)//telefoon/Gsm invoegen stap10=field[10]
        {
            textBoxEmail.IsEnabled = true;
        }

        private void textBoxEmail_KeyUp(object sender, KeyEventArgs e)//E-mail invoegen stap11=field[11]
        {
            textBoxGezinsLeden.IsEnabled = true;
        }

        private void textBoxGezinsLeden_KeyUp(object sender, KeyEventArgs e)//Aantal gezinsleden intypen field [12]
        {
            int getal;
            try
            {
                int x = int.Parse(textBoxGezinsLeden.Text);
                getal = x;

            }
            catch
            {
                if (textBoxGezinsLeden.Text == "")//zoiets deed ik om te vermijden dat de Messagebox altijd terugkomt. Hopelijk; begrijpelijk.
                {
                    comboBoxTypeContactCorona.IsEnabled = false;
                    return;
                }

                MessageBox.Show("Nummer invullen alstublieft!", "waarschuwing", MessageBoxButton.OK);

                textBoxGezinsLeden.Text = "";
            }



            comboBoxTypeContactCorona.IsEnabled = true;
        }

        private void comboBoxTypeContactCorona_SelectionChanged(object sender, SelectionChangedEventArgs e)// Type contact field[13]
        {
            comboBoxGebeldOfNiet_Ja_Nee.IsEnabled = true;

        }

        private void comboBoxGebeldOfNiet_Ja_Nee_SelectionChanged(object sender, SelectionChangedEventArgs e)// wel of niet gecontacteerd field[14]
        {
            ButtonToevoegen.IsEnabled = true;
        }

        private void ButtonToevoegen_Click(object sender, RoutedEventArgs e)//Toevoegen aan CSV file en aan listbox
        {
            //
            if (textBoxId.Text == "" || textBoxNaam.Text == "" || textBoxVoornaam.Text == "" ||
                textBoxRRN.Text == "" || comboBoxGeslacht.SelectionBoxItem == "" || textBoxStraatNaam.Text == ""
                || textBoxHuisNr.Text == "" || textBoxpostcode.Text == "" || textBoxGemeente.Text == "" || textBoxTelefoon.Text == "" ||
                textBoxEmail.Text == "" || textBoxGezinsLeden.Text == "" || comboBoxTypeContactCorona.SelectionBoxItem == ""
                || comboBoxGebeldOfNiet_Ja_Nee.SelectionBoxItem == "")
            {
                MessageBox.Show("Er ontbreekt Informatie!");// Als een van de teksBoxen leeg is toon dit.
            }

            if//Als geen van de teksBoxen leeg....
                 (textBoxId.Text != "" && textBoxNaam.Text != "" && textBoxVoornaam.Text != "" &&
                 textBoxRRN.Text != "" && comboBoxGeslacht.SelectionBoxItem != "" && textBoxStraatNaam.Text != ""
                 && textBoxHuisNr.Text != "" && textBoxpostcode.Text != "" && textBoxGemeente.Text != "" && textBoxTelefoon.Text != "" &&
                 textBoxEmail.Text != "" && textBoxGezinsLeden.Text != "" && comboBoxTypeContactCorona.SelectionBoxItem != ""
                 && comboBoxGebeldOfNiet_Ja_Nee.SelectionBoxItem != "")

            {//De creatie van deze variabelen gebeurde in het begin van de applicatie(zie helemaal bovenaan)
                FNaam = textBoxNaam.Text;
                VNaam = textBoxVoornaam.Text;
                DateTime birth = Convert.ToDateTime(dpGeboorte.SelectedDate);
                GDatum = birth.ToShortDateString();
                RRN = textBoxRRN.Text;
                MOfV = Convert.ToString(comboBoxGeslacht.SelectionBoxItem);
                StraatNaam = textBoxStraatNaam.Text;
                HuisNummer = textBoxHuisNr.Text;
                PCode = textBoxpostcode.Text;
                Gemeente = textBoxGemeente.Text;
                Telefoon = textBoxTelefoon.Text;
                Email = textBoxEmail.Text;
                aantalGezinLeden = textBoxGezinsLeden.Text;
                TypeContact = Convert.ToString(comboBoxTypeContactCorona.SelectionBoxItem);
                opgebeld = Convert.ToString(comboBoxGebeldOfNiet_Ja_Nee.SelectionBoxItem);
                //
                //Ik maak een string met komma's en dankzij stringinterpolatie maak ik 1 enkel regel voor de csv file.
                string special = $"{Id},{FNaam},{VNaam},{GDatum},{RRN},{MOfV},{StraatNaam},{HuisNummer},{PCode}," +
                            $"{Gemeente},{Telefoon},{Email},{aantalGezinLeden},{TypeContact},{opgebeld},";
                ///

                sav1.Filter = "CSV-Files(*.csv)|*.csv";//op voorhand filter van savefiledialog

                if (sav1.ShowDialog() == true)//OpenKrijgen van SaveFiledialog
                {
                    BestandsNaam = sav1.FileName;//bestandsnaam string hiermee bepaald
                    StreamWriter swr = File.AppendText(@BestandsNaam);//open  csv bestand om naar te schrijven
                    swr.WriteLine(special);//schrijf één regel naar csv bestand
                    swr.Close();//Sluit de streamWriter
                }
                listBoxx.Items.Clear();//listbox even leegmaken
                StreamReader srx = File.OpenText(@BestandsNaam);//openen van bestand om vanaf de csv file in listbox weg te schrijven
                string lijn = srx.ReadLine();// streamreader -Readline 
                while (lijn != null)//Loopen in de Readline hierboven tot een regel leeg is 
                {
                    string[] strx = lijn.Split(','); //elke string readline word eens "Gesplit"
                   
                    listBoxx.Items.Add(strx[0]+" "+ strx[1]+" "+ strx[2]);//field [0],[1],[2] worden aan listbox toegevoeg van elke Readline string.
                    lijn = srx.ReadLine();//Lees nog een regel tot er geen regel meer is.
                }
                srx.Close();// sluiten van streamreader

                DIsableFormulier();//formulier herinitialiseren
                Id++;//Id word verhoogd 
                buttonReset.IsEnabled = true;
                textBoxId.Text = Convert.ToString(Id);//id ...
                ButtonToevoegen.IsEnabled = false;

            }

        }
        private void DIsableFormulier()
        {
            textBoxNaam.Text = "";

            textBoxVoornaam.Text = "";
            textBoxVoornaam.IsEnabled = false;
            dpGeboorte.SelectedDate = null;
            dpGeboorte.IsEnabled = false;
            textBoxRRN.Text = "";
            textBoxRRN.IsEnabled = false;
            comboBoxGeslacht.SelectedItem = null;
            comboBoxGeslacht.IsEnabled = false;
            textBoxStraatNaam.Text = "";
            textBoxStraatNaam.IsEnabled = false;
            textBoxHuisNr.Text = "";
            textBoxHuisNr.IsEnabled = false;
            textBoxpostcode.Text = "";
            textBoxpostcode.IsEnabled = false;
            textBoxGemeente.Text = "";
            textBoxGemeente.IsEnabled = false;
            textBoxTelefoon.Text = "";
            textBoxTelefoon.IsEnabled = false;
            textBoxEmail.Text = "";
            textBoxEmail.IsEnabled = false;
            textBoxGezinsLeden.Text = "";
            textBoxGezinsLeden.IsEnabled = false;
            comboBoxTypeContactCorona.SelectedItem = null;
            comboBoxTypeContactCorona.IsEnabled = false;
            comboBoxGebeldOfNiet_Ja_Nee.SelectedItem = null;
        }
        private void DisableTextBoxes()
        {


            textBoxNaam.IsEnabled = true;
            textBoxVoornaam.IsEnabled = false;

            dpGeboorte.IsEnabled = false;

            textBoxRRN.IsEnabled = false;

            comboBoxGeslacht.IsEnabled = false;

            textBoxStraatNaam.IsEnabled = false;

            textBoxHuisNr.IsEnabled = false;

            textBoxpostcode.IsEnabled = false;

            textBoxGemeente.IsEnabled = false;

            textBoxTelefoon.IsEnabled = false;

            textBoxEmail.IsEnabled = false;

            textBoxGezinsLeden.IsEnabled = false;

            comboBoxTypeContactCorona.IsEnabled = false;

            comboBoxGebeldOfNiet_Ja_Nee.IsEnabled = false;
        }


        private void menuItemOpenFile_Click(object sender, RoutedEventArgs e)//CSV bestand openen vanaf de menuknop
        {
            ButtonToevoegen.Visibility = Visibility.Visible;
            ButtonToevoegen.IsEnabled = false;
            buttonWijzigen2.Visibility = Visibility.Hidden;
            ofd.Filter = "CSV bestanden(*.csv)|*csv";
            try
            {
                if (ofd.ShowDialog() == true)//open hier een csv bestand
                {

                    BestandsNaam = ofd.FileName;//bestandsnaam word verander als savefiledialog ok is.
                    string line = File.ReadAllLines(@BestandsNaam).Last();// ik lees hier de laatste regel.

                    string[] words = line.Split(','); //"Split" de laatste regel


                    Id = Convert.ToInt32(words[0]) + 1;// maak al een id klaar voor de gebruiker, zo regel ik de volgende Id.
                    textBoxId.Text = Convert.ToString(Id);


                    DIsableFormulier();
                    ButtonToevoegen.Visibility = Visibility.Visible;
                    buttonWijzigen2.Visibility = Visibility.Hidden;
                }
            }
            catch (FormatException exeption)// als de csv file niet behoord tot een file dat gemaakt is door dit programma
            {
                MessageBox.Show("Geen geldige database!");
                BestandsNaam = "";
                Id = 1;//Id wordt dan weer terug 1
                textBoxId.Text = Convert.ToString(Id);
                DIsableFormulier();
            }

            ButtonToevoegen.IsEnabled = false;
            ButtonToevoegen.Visibility = Visibility.Visible;
            buttonWijzigen2.Visibility = Visibility.Hidden;

            listBoxx.Items.Clear();//Vanaf Hier alles uitlezen en in listbox zetten
            StreamReader srx = File.OpenText(@BestandsNaam);// Weer een streamReader 
            string lijn = srx.ReadLine();//
            while (lijn != null)//
            {
                string[] strx = lijn.Split(',');
                listBoxx.Items.Add(strx[0]+" "+ strx[1] + " "+ strx[2]);//Zo !
                lijn = srx.ReadLine();
            }
            srx.Close();
            ButtonToevoegen.IsEnabled = false;
            ButtonToevoegen.Visibility = Visibility.Visible;
            buttonWijzigen2.Visibility = Visibility.Hidden;
        }

        private void listBoxx_SelectionChanged(object sender, SelectionChangedEventArgs e)//Wat er gebeurd als je op een listboxItem klikt
        {

            ButtonToevoegen.Visibility = Visibility.Hidden;

            string[] lines = File.ReadAllLines(@BestandsNaam);//Eigenlijk doet die een streamreader en gebruikt de voorlipige bestandsnaam

            string[] listboxSplit = Convert.ToString(listBoxx.SelectedItem).Split(' ');// Id van personen vergaren.
            for (int i = 0; i < lines.Length; i++)//Loopt door de csv file
            {
                string[] fields = lines[i].Split(',');// "Split" elke regel weer eens in fields

               

                if (fields[0] == listboxSplit[0]) //
                {
                    textBoxId.Text = fields[0];
                    textBoxNaam.Text = fields[1];
                    textBoxVoornaam.Text = fields[2];
                    dpGeboorte.SelectedDate = Convert.ToDateTime(fields[3]);
                    textBoxRRN.Text = fields[4];
                    if (fields[5] == "Man") { comboBoxGeslacht.SelectedIndex = 0; } else { comboBoxGeslacht.SelectedIndex = 1; }
                    textBoxStraatNaam.Text = fields[6];
                    textBoxHuisNr.Text = fields[7];
                    textBoxpostcode.Text = fields[8];
                    textBoxGemeente.Text = fields[9];
                    textBoxTelefoon.Text = fields[10];
                    textBoxEmail.Text = fields[11];
                    textBoxGezinsLeden.Text = fields[12];
                    if (fields[13] == "Werk") { comboBoxTypeContactCorona.SelectedIndex = 0; }
                    else if (fields[13] == "School") { comboBoxTypeContactCorona.SelectedIndex = 1; }
                    else if (fields[13] == "Sportclub") { comboBoxTypeContactCorona.SelectedIndex = 2; }
                    else if (fields[13] == "Vriend") { comboBoxTypeContactCorona.SelectedIndex = 3; }
                    else if (fields[13] == "Privé") { comboBoxTypeContactCorona.SelectedIndex = 4; }

                    if (fields[14] == "Ja")
                    {
                        comboBoxGebeldOfNiet_Ja_Nee.SelectedIndex = 0;
                    }
                    else if (fields[14] == "Nee") 
                    {
                        comboBoxGebeldOfNiet_Ja_Nee.SelectedIndex = 1; 
                    }

                }

                DisableTextBoxes();
                buttonWijzigen.IsEnabled = true;
                buttonDelete.IsEnabled = true;
                buttonWijzigen.Visibility = Visibility.Visible;
                buttonWijzigen2.Visibility = Visibility.Hidden;
                buttonReset.IsEnabled = true;
            }
        }

        private void buttonWijzigen_Click(object sender, RoutedEventArgs e)// Eigenlijk eerste wijzigen klik! na het wijzigen van velden komt er een ander wijzigen klik.
        {
            EnableBoxes();
            buttonWijzigen.Visibility = Visibility.Hidden;
            buttonWijzigen2.Visibility = Visibility.Visible;
            buttonDelete.IsEnabled = false;
        }

        private void EnableBoxes()
        {
            textBoxNaam.IsEnabled = true;
            textBoxVoornaam.IsEnabled = true;

            dpGeboorte.IsEnabled = true;

            textBoxRRN.IsEnabled = true;

            comboBoxGeslacht.IsEnabled = true;

            textBoxStraatNaam.IsEnabled = true;

            textBoxHuisNr.IsEnabled = true;

            textBoxpostcode.IsEnabled = true;

            textBoxGemeente.IsEnabled = true;

            textBoxTelefoon.IsEnabled = true;

            textBoxEmail.IsEnabled = true;

            textBoxGezinsLeden.IsEnabled = true;

            comboBoxTypeContactCorona.IsEnabled = true;

            comboBoxGebeldOfNiet_Ja_Nee.IsEnabled = true;
        }

        private void buttonWijzigen2_Click(object sender, RoutedEventArgs e)
        {
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filepath = System.IO.Path.Combine(folderpath, "vervanging.csv");//voorlopig csv bestand en wordt daarna weer hernaamd naar de originele tittel
            StreamWriter streamwrter = File.AppendText(@filepath);// wegschrijven naar voorlopig bestand.


            string[] lines = File.ReadAllLines(@BestandsNaam);

            for (int i = 0; i < lines.Length; i++)//loop
            {
                string[] fields = lines[i].Split(',');

                if (!fields[0].Equals(textBoxId.Text))// als de formulier een ander Id heeft schrijf naar voorlopig bestand anders niet.
                {

                    streamwrter.WriteLine($"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}," +
                        $"{fields[7]},{fields[8]},{fields[9]},{fields[10]},{fields[11]},{fields[12]},{fields[13]},{fields[14]}");

                }
                else if (fields[0].Equals(textBoxId.Text))//Als het te wijzigen object zijn Id hetzelfde is dan schrijf deze lijn hieronder
                {
                    DateTime ddatum = Convert.ToDateTime(dpGeboorte.SelectedDate);
                    string gebDatum = ddatum.ToShortDateString();
                    streamwrter.WriteLine($"{textBoxId.Text},{textBoxNaam.Text},{textBoxVoornaam.Text},{gebDatum}," +
                        $"{textBoxRRN.Text},{Convert.ToString(comboBoxGeslacht.SelectionBoxItem)},{textBoxStraatNaam.Text},{textBoxHuisNr.Text}," +
                        $"{textBoxpostcode.Text},{textBoxGemeente.Text},{textBoxTelefoon.Text},{textBoxEmail.Text},{textBoxGezinsLeden.Text}," +
                        $"{Convert.ToString(comboBoxTypeContactCorona.SelectionBoxItem)},{Convert.ToString(comboBoxGebeldOfNiet_Ja_Nee.SelectionBoxItem)},");
                }
            }
            streamwrter.Close();
            File.Delete(@BestandsNaam);//Verwijder definitief het oude bestand
            System.IO.File.Move(filepath, BestandsNaam);//Geef dit bestand de naam van het oude bestand

            MessageBox.Show("Bestand is gewijzig met success! \n " +
                "Herniew uw lijst door uw bestand te heropenen.");



            ButtonToevoegen.Visibility = Visibility.Hidden;


        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)//Reset knop dient om een niewe contact aan te maken in dezelfde file
        {
            listBoxx.Items.Clear();
            DIsableFormulier();
           
                string line = File.ReadAllLines(@BestandsNaam).Last();
                string[] words = line.Split(',');
                Id = Convert.ToInt32(words[0]) + 1;//Id wordt herberkend
     
            textBoxId.Text = Convert.ToString(Id);
            ButtonToevoegen.Visibility = Visibility.Visible;
            ButtonToevoegen.IsEnabled = false;
            buttonWijzigen.IsEnabled = false;
            buttonWijzigen2.Visibility = Visibility.Hidden;
            
            if (BestandsNaam !="")
            {
                StreamReader srx = File.OpenText(BestandsNaam);
                string lijn = srx.ReadLine();
                while (lijn != null)
                {
                    string[] strx = lijn.Split(',');
                    listBoxx.Items.Add(strx[0]+" "+ strx[1]+" "+ strx[2]);
                    lijn = srx.ReadLine();
                }
                srx.Close();

                textBlockZoekCriterium.Visibility = Visibility.Hidden;
                textBlockZoekCriterium.Text = "";
                comboBoxZoekCriterium.Visibility = Visibility.Hidden;
                textBoxZoeken.Visibility = Visibility.Hidden;
                btnOk.Visibility = Visibility.Hidden;
                comboBoxZoekenMofV.Visibility = Visibility.Hidden;
                comboboxZoekenTypeContact.Visibility = Visibility.Hidden;
                comboBoxZoekenWelOfNietOpgebeld.Visibility = Visibility.Hidden;
            }
            else return;


        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)// gewoon deleten van een contact . dit kan misschien beknopter maar deze manier is ook goed.
        {
            string[] listboxSplit = Convert.ToString(listBoxx.SelectedItem).Split(' ');//selectedItem van listbox splitten om veld[0] te krijgen (=Id)
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string tempfilepath = System.IO.Path.Combine(folderpath, "vervanging.csv");
          
            string[] regels = System.IO.File.ReadAllLines(@BestandsNaam);
            StreamWriter sw = File.AppendText(tempfilepath);

            for (int i = 0; i < regels.Length; i++)
            {
                String[] fields = regels[i].Split(',');
                if ((!fields[0].Equals(listboxSplit[0])))//Hier Veld[0] van listbox belangrijk
                {
                    sw.WriteLine($"{fields[0]},{fields[1]},{fields[2]},{fields[3]},{fields[4]},{fields[5]},{fields[6]}," +
                   $"{fields[7]},{fields[8]},{fields[9]},{fields[10]},{fields[11]},{fields[12]},{fields[13]},{fields[14]}");
                }
            }
            sw.Close();
            File.Delete(@BestandsNaam);
            System.IO.File.Move(@tempfilepath, BestandsNaam);
            listBoxx.Items.Remove(listBoxx.SelectedItem);
            DIsableFormulier();
           
            MessageBox.Show("Persoon Verwijderd met success!");
            string line = File.ReadAllLines(@BestandsNaam).Last();
            string[] words = line.Split(',');
            Id = Convert.ToInt32(words[0]) + 1;
            textBoxId.Text = Convert.ToString(Id);
        }

        private void btnZoeken1_Click_1(object sender, RoutedEventArgs e)// Deze knop opent de andere buttons,textboxes en comboboxes voor het zoeken
        {
            textBlockZoekCriterium.Visibility = Visibility.Visible;
            textBlockZoekCriterium.Text = "Kies uw zoek-criterium:";
            comboBoxZoekCriterium.Visibility = Visibility.Visible;
            comboBoxZoekCriterium.SelectedIndex = 0;
            textBoxZoeken.Visibility = Visibility.Visible;
            btnOk.Visibility = Visibility.Visible;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)// met deze knop zoek je meteen u resultaat.
        {
            var zoekwoord = textBoxZoeken.Text;//textbox zoeken
            string zoekwoord2 = Convert.ToString(comboBoxZoekenMofV.SelectionBoxItem);//combobox String 
            string zoekwoord3 = Convert.ToString(comboboxZoekenTypeContact.SelectionBoxItem);//andere combobox string
            string zoekwoord4 = Convert.ToString(comboBoxZoekenWelOfNietOpgebeld.SelectionBoxItem);
            listBoxx.Items.Clear();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@BestandsNaam);

                for(int i = 0; i < lines.Length; i++)
                {
                    String[] fields = lines[i].Split(',');

                    if (comboBoxZoekCriterium.SelectedIndex == 0)
                    {
                        if (fields.Contains(zoekwoord))
                        {
                            
                            listBoxx.Items.Add(fields[0] +" "+ fields[1]+" "+ fields[2]);
                        }
                    }

                    if (comboBoxZoekCriterium.SelectedIndex == 1)
                    {
                        if (fields.Contains(zoekwoord))
                        {

                            listBoxx.Items.Add(fields[0] + " " + fields[1] + " " + fields[2]);
                        }
                    }
                    if (comboBoxZoekCriterium.SelectedIndex == 2)
                    {
                        if (fields.Contains(zoekwoord))
                        {

                            listBoxx.Items.Add(fields[0] + " " + fields[1] + " " + fields[2]);
                        }
                    }
                    if (comboBoxZoekCriterium.SelectedIndex == 3)
                    {
                        if (fields[5]==zoekwoord2)
                        {

                            listBoxx.Items.Add(fields[0] + " " + fields[1] + " " + fields[2]);
                        }
                    }
                    if (comboBoxZoekCriterium.SelectedIndex == 4)
                    {
                        if (fields[13] == zoekwoord3)
                        {

                            listBoxx.Items.Add(fields[0] + " " + fields[1] + " " + fields[2]);
                        }
                    }
                    if (comboBoxZoekCriterium.SelectedIndex == 5)
                    {
                        if (fields[14] == zoekwoord4)
                        {

                            listBoxx.Items.Add(fields[0] + " " + fields[1] + " " + fields[2]);
                        }
                    }
                }
                textBlockZoekCriterium.Visibility = Visibility.Hidden;
                textBlockZoekCriterium.Text = "";
                comboBoxZoekCriterium.Visibility = Visibility.Hidden;
                textBoxZoeken.Visibility = Visibility.Hidden;
                btnOk.Visibility = Visibility.Hidden;
                comboBoxZoekenMofV.Visibility = Visibility.Hidden;
                comboboxZoekenTypeContact.Visibility = Visibility.Hidden;
                comboBoxZoekenWelOfNietOpgebeld.Visibility = Visibility.Hidden;
            }
            catch(Exception exeption)
            {
                MessageBox.Show("Fout");
            }
        }

        private void comboBoxZoekCriterium_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboBoxZoekCriterium.SelectedIndex == 0)
            {
                textBoxZoeken.Visibility = Visibility.Visible;
                comboBoxZoekenMofV.Visibility = Visibility.Hidden;
                comboboxZoekenTypeContact.Visibility = Visibility.Hidden;
                comboBoxZoekenWelOfNietOpgebeld.Visibility = Visibility.Hidden;
            }
            if (comboBoxZoekCriterium.SelectedIndex == 1)
            {
                textBoxZoeken.Visibility = Visibility.Visible;
                comboBoxZoekenMofV.Visibility = Visibility.Hidden;
                comboboxZoekenTypeContact.Visibility = Visibility.Hidden;
                comboBoxZoekenWelOfNietOpgebeld.Visibility = Visibility.Hidden;
            }
            if (comboBoxZoekCriterium.SelectedIndex == 3)
            {
                textBoxZoeken.Visibility = Visibility.Hidden;
                comboBoxZoekenMofV.Visibility = Visibility.Visible;
                comboboxZoekenTypeContact.Visibility = Visibility.Hidden;
                comboBoxZoekenWelOfNietOpgebeld.Visibility = Visibility.Hidden;
            }
            if (comboBoxZoekCriterium.SelectedIndex == 4)
            {
                textBoxZoeken.Visibility = Visibility.Hidden;
                comboBoxZoekenMofV.Visibility = Visibility.Hidden;
                comboboxZoekenTypeContact.Visibility = Visibility.Visible;
            }

            if (comboBoxZoekCriterium.SelectedIndex == 5)
            {
                textBoxZoeken.Visibility = Visibility.Hidden;
                comboBoxZoekenMofV.Visibility = Visibility.Hidden;
                comboboxZoekenTypeContact.Visibility = Visibility.Hidden;
                comboBoxZoekenWelOfNietOpgebeld.Visibility = Visibility.Visible;
            }
        }

        private void menuNewForm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Formulier hernieuwd!");
            listBoxx.Items.Clear();
            Id = 1;
            BestandsNaam = "";
            textBoxId.Text = Convert.ToString(Id);
            DIsableFormulier();
        }
    }
}
