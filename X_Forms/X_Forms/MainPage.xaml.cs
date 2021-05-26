using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass"},
            new Person(){Vorname="Rainer", Nachname="Zufall"}
        };

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this;
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            Btn_KlickMich.Text = "Wurde geklickt";

            (sender as Button).Text = "Wurde geklickt";
        }

        private void IBtn_Beispiel_Clicked(object sender, EventArgs e)
        {
            Lbl_Main.Text = Pkr_Monkeys.SelectedItem?.ToString();
        }

        private void Btn_Aendern_Clicked(object sender, EventArgs e)
        {
            (StL_DataBinding.BindingContext as Person).Vorname = "Hannes";
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
           bool result = await DisplayAlert("Löschen", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if(result)
            {
                Person person = (sender as MenuItem).CommandParameter as Person;
                Personenliste.Remove(person);
            }
        }
    }
}
