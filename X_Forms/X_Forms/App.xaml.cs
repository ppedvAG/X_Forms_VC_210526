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
            MainPage = new Layouts.RelativeLayoutBsp();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
