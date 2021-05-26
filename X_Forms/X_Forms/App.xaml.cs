using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    //Die App-Klasse beinhaltet eine grundlegen Initialisierung der App sowie die MainPage-Property, welche defniert,
    //welche Page gerade in der App angezeigt wird. Diese Property wird auch als Einstiegspunkt verwendet.
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Zuweisung der MainPage-Property zu einer Page
            //MainPage = new MainPage();

            //Zuweisung der MainPage - Property zu einer NavigationPage(ermöglicht Stack - Navigation) mit Angabe der Startpage.
            MainPage = new NavigationPage(new MainPage());
        }

        public DateTime timestamp { get; set; }

        //Methoden, welche zu bestimmten globalen Events ausgeführt werden (Start, Unterbrechen der App [Sleep], Wiederaktivierung der App [Resume])
        protected override void OnStart()
        {
            MainPage.DisplayAlert("Aktuelle Zeit", DateTime.Now.ToString(), "Weiter");
        }

        protected override void OnSleep()
        {
            timestamp = DateTime.Now;
        }

        protected override void OnResume()
        {
            MainPage.DisplayAlert("Geschlafene Zeit:", DateTime.Now.Subtract(timestamp).ToString(), "ok");
        }
    }
}
