using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        //Property zum Zwischenspeichern der Personenliste (ObservableCollection ist eine generische Liste, welche die GUI
        //automatisch über Veränderungen innerhalb der Liste informiert)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass"},
            new Person(){Vorname="Rainer", Nachname="Zufall"}
        };

        //Konstruktor
        public MainPage()
        {
            //Setzten der Ressourcensprache -> Bestimmt, welche resx-Bibliothek für die Lokalisierung verwendet wird
            Loc.Resource.Culture = new System.Globalization.CultureInfo("de");

            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Main.Text = "Hallo Xamarin";

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;

            //Zugriff auf Xamarin.Essentials.Battery zur Anzeige des Batteriestandes (benötigt BatteryState-Permission)
            Lbl_Battery.Text = Battery.State.ToString() + " | Level: " + Battery.ChargeLevel * 100 + "%";
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            (sender as Button).Text = "Wurde geklickt";

            //Hinzufügen einer neuen Person zur Liste
            Personenliste.Add(new Person() { Vorname = Ent_Vorname?.Text, Nachname = Ent_Nachname?.Text });
        }

        private void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung der Textproperty des Labels mit dem Ausgewählten Element des Pickers
            Lbl_Main.Text = Pkr_Monkeys.SelectedItem?.ToString();
        }

        private void Btn_Aendern_Clicked(object sender, EventArgs e)
        {
            //Änderung einer Property des BindingContexts des StackLayouts (INotifyPropertyChanged informiert GUI über Veränderung (vgl. Person.cs))
            (StL_DataBinding.BindingContext as Person).Vorname = "Hannes";
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                Person person = (sender as MenuItem).CommandParameter as Person;
                Personenliste.Remove(person);
            }
        }

        //Navigationsbeispiele
        private void Push_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Layouts.GridLayoutBsp());
        }

        private void PushModal_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keine Navigationsleiste anzeigt
            Navigation.PushModalAsync(new Layouts.StackLayoutBsp());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsps.TabbedPageBsp());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsps.CarouselPageBsp());
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Personenliste.Clear();
        }

        //Aufruf der Shell-Navigation
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Layouts/Beispiele/Relative");
        }

        private async void Btn_Youtube_Clicked(object sender, EventArgs e)
        {
            //Öffnen der Youtube-App über die Xamarin-Essentials mit Übergabe des Package-Namens
            if (await Launcher.CanOpenAsync("vnd.youtube://"))
                await Launcher.OpenAsync("vnd.youtube://rLKnqR9Oqh8");
        }

        //Bsp für Verwendung des MessagingCenters
        private void Btn_MCSender_Clicked(object sender, EventArgs e)
        {
            //Instanzieren des Empängerobjekts
            Page subscriber = new Pg_MCSubscriber();
            //Senden der Nachricht mit Angabe des Senders, des Titels und des Inhalts
            MessagingCenter.Send(this, "Gesendeter Text", Pkr_Monkeys.SelectedItem?.ToString());
            //Öffnen der Bsp-Seite
            Navigation.PushAsync(subscriber);
        }
    }
}
