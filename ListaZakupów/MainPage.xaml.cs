using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ListaZakupów
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Zakup> zakupy = new ObservableCollection<Zakup>();

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            Zakupy.ItemsSource = zakupy;
            zakupy.CollectionChanged += ZmianaKonentuZakupow;

            inicjujJednostkeComboBox();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void DodajZakupButton_Click(object sender, RoutedEventArgs e)
        {
            dodajZakup();
        }

        private void dodajZakup()
        {
            Zakup zakup = new Zakup();
            zakup.Nazwa = ZakupNazwa.Text;
            zakup.Ilosc = Int32.Parse(ZakupIlosc.Text);
            zakup.Jednostka = ZakupJednostka.SelectedItem.ToString();
            zakup.PrefMarak = ZakupPrefMarka.Text;
            zakup.CenaMax = Int32.Parse(ZakupCenaMax.Text);

            zakupy.Add(zakup);
        }
        
        private void ZmianaKonentuZakupow(object sender, NotifyCollectionChangedEventArgs e)
        {
            Zakupy.ItemsSource = zakupy.OrderBy(n => n.Nazwa);
        }

        private void inicjujJednostkeComboBox()
        {
            ZakupJednostka.Items.Add("kg");
            ZakupJednostka.Items.Add("g");
            ZakupJednostka.Items.Add("dg");
            ZakupJednostka.Items.Add("szt");
            ZakupJednostka.Items.Add("l");
            ZakupJednostka.Items.Add("m");

            ZakupJednostka.SelectedIndex = 0;
        }
    }
}
