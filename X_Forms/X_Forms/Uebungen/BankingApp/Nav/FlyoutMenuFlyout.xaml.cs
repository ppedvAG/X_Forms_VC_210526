using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.Uebungen.BankingApp.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutMenuFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutMenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMenuFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMenuFlyoutMenuItem>(new[]
                {
                    new FlyoutMenuFlyoutMenuItem { Id = 0, Title = "Startseite", TargetType = typeof(View.BankingView) },
                    new FlyoutMenuFlyoutMenuItem { Id = 1, Title = "Konto anlegen", TargetType=typeof(View.AddAccountView)},
                    new FlyoutMenuFlyoutMenuItem { Id = 2, Title = "Einzahlen/Auszahlen", TargetType=typeof(View.DepositWithdrawView) },
                    new FlyoutMenuFlyoutMenuItem { Id = 4, Title = "Logout"},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}