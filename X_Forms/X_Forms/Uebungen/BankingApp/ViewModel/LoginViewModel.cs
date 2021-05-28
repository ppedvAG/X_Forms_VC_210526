using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using X_Forms.Uebungen.BankingApp.Nav;
using X_Forms.Uebungen.BankingApp.Service;
using X_Forms.Uebungen.BankingApp.View;
using Xamarin.Forms;

namespace X_Forms.Uebungen.BankingApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            InitApp();

            //LoginView

            this.LoginCmd = new Command(() =>
            {
                if (PersonService.AreCredentialsCorrect(Fullname, Password))
                {
                    PersonService.Login(Fullname, Password);

                    if (PersonService.SelectedPerson != null)
                        Application.Current.MainPage = new FlyoutMenu();
                    else
                        ContextPage.DisplayAlert("DbError", "Something went wrong.", "OK");
                }
                else
                {
                    ContextPage.DisplayAlert("Wrong Credentials", "Name or password ist wrong", "OK");
                    Password = string.Empty;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            });

            this.RegisterOpenCmd = new Command(() => ContextPage.Navigation.PushModalAsync(new RegisterView()));

            //RegisterView

            this.RegisterCmd = new Command(() =>
            {
                Model.Person newPerson = new Model.Person()
                {
                    Vorname = Fullname.Substring(0, Fullname.LastIndexOf(" ")),
                    Nachname = Fullname.Substring(Fullname.LastIndexOf(" ") + 1, Fullname.Length - (Fullname.LastIndexOf(" ") + 1)),
                    Password = Password,
                    Id = PersonService.GetNewId()
                };

                if (PersonService.Insert(newPerson))
                    ContextPage.DisplayAlert("Success", $"{Fullname} is registered.", "OK");
                else
                    ContextPage.DisplayAlert("Failure", $"{Fullname} couldn't been registered, cause the name allready exists.", "OK");

                Fullname = string.Empty;
                Password = string.Empty;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fullname)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            });

            this.RegisterCloseCmd = new Command(() => ContextPage.Navigation.PopModalAsync());

        }

        private void InitApp()
        {
            PersonService.PersonList = new System.Collections.ObjectModel.ObservableCollection<Model.Person>();
            AccountService.AccountList = new System.Collections.ObjectModel.ObservableCollection<Model.Account>();

            PersonService.LoadPeople();
            AccountService.LoadAccounts();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Page ContextPage { get; set; }

        public string Fullname { get; set; }
        public string Password { get; set; }

        //LoginView
        public Command LoginCmd { get; set; }
        public Command RegisterOpenCmd { get; set; }

        //RegisterView
        public Command RegisterCmd { get; set; }
        public Command RegisterCloseCmd { get; set; }

    }
}
