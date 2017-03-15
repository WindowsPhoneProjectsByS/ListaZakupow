using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ListaZakupów
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoreOptionPage : Page
    {
        private ObservableCollection<Zakup> zakupy = new ObservableCollection<Zakup>();

        public MoreOptionPage()
        {
            this.InitializeComponent();

            inicjujJednostkeComboBox();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            zakupy = e.Parameter as ObservableCollection<Zakup>;
            ZakupyDoEdycji.ItemsSource = zakupy;
            zakupy.CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            //ZakupyDoEdycji.ItemsSource = zakupy;

            ZakupyDoEdycji.ItemsSource = null;
            ZakupyDoEdycji.ItemsSource = zakupy;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            e.Handled = true;
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void inicjujJednostkeComboBox()
        {
            PoleWyszukiwania.Items.Add("nazwa");
            PoleWyszukiwania.Items.Add("ilość");
            PoleWyszukiwania.Items.Add("jednostka");
            PoleWyszukiwania.Items.Add("Preferowana Marka");
            PoleWyszukiwania.Items.Add("Cena Maksymalna");
            PoleWyszukiwania.Items.Add("Wszystkie");

            PoleWyszukiwania.SelectedIndex = 0;
        }

        private void GreatLettersButton_Click(object sender, RoutedEventArgs e)
        {
 
            if (PoleWyszukiwania.SelectedIndex == 0)
            {
                var namesList = (from zakup in zakupy
                    select zakup.Nazwa.ToUpper()).ToList();

                ChangeNames(namesList);

                ZakupyDoEdycji.ItemsSource = null;
                ZakupyDoEdycji.ItemsSource = zakupy;
            }
            else if (PoleWyszukiwania.SelectedIndex == 1)
            {
                ShowSpecialMessage();
            }
            else if (PoleWyszukiwania.SelectedIndex == 2)
            {
                var namesList = (from zakup in zakupy
                                 select zakup.Jednostka.ToUpper()).ToList();

                ChangeUnit(namesList);

                ZakupyDoEdycji.ItemsSource = null;
                ZakupyDoEdycji.ItemsSource = zakupy;
            }
            else if (PoleWyszukiwania.SelectedIndex == 3)
            {
                var namesList = (from zakup in zakupy
                                 select zakup.PrefMarak.ToUpper()).ToList();

                ChangePrefMark(namesList);

                ZakupyDoEdycji.ItemsSource = null;
                ZakupyDoEdycji.ItemsSource = zakupy;
            }
            else if (PoleWyszukiwania.SelectedIndex == 4)
            {
                ShowSpecialMessage();
            }
            else if (PoleWyszukiwania.SelectedIndex == 5)
            {
                var namesList = (from zakup in zakupy
                                 select zakup.Nazwa.ToUpper()).ToList();

                ChangeNames(namesList);

                namesList = (from zakup in zakupy
                                 select zakup.Jednostka.ToUpper()).ToList();

                ChangeUnit(namesList);

                namesList = (from zakup in zakupy
                                 select zakup.PrefMarak.ToUpper()).ToList();

                ChangePrefMark(namesList);


            }
        }

        private void SmallerLettersButton_Click(object sender, RoutedEventArgs e)
        {
            var namesList = (from zakup in zakupy
                             select zakup.Nazwa.ToLower()).ToList();

            ChangeNames(namesList);

            ZakupyDoEdycji.ItemsSource = null;
            ZakupyDoEdycji.ItemsSource = zakupy;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChangeNames(List<string> listNames)
        {
            for (int i = 0; i < zakupy.Count; i++)
            {
                zakupy[i].Nazwa = listNames[i];
            }      
        }

        private void ChangePrefMark(List<string> listPrefMark)
        {
            for (int i = 0; i < zakupy.Count; i++)
            {
                zakupy[i].PrefMarak = listPrefMark[i];
            }
        }

        private void ChangeUnit(List<String> listUnit)
        {
             for (int i = 0; i < zakupy.Count; i++)
            {
                zakupy[i].Jednostka = listUnit[i];
            }
        }


        private async void ShowSpecialMessage()
        {
            MessageDialog mg = new MessageDialog("Niedozwolona operacja");
            await mg.ShowAsync();
        }
    }
}
