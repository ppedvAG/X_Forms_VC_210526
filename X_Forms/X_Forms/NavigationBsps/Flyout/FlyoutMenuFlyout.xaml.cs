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

namespace X_Forms.NavigationBsps.Flyout
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

        //Genestete ViewModel-Klasse mit Itemliste, welche die Einträge im Flyout definiert
        class FlyoutMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMenuFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMenuFlyoutMenuItem>(new[]
                {
                    new FlyoutMenuFlyoutMenuItem { Id = 0, Title = "MainPage", TargetType=typeof(MainPage) },
                    new FlyoutMenuFlyoutMenuItem { Id = 1, Title = "Tabbed", TargetType=typeof(TabbedPageBsp) },
                    new FlyoutMenuFlyoutMenuItem { Id = 2, Title = "GridLayout", TargetType=typeof(Layouts.GridLayoutBsp) },
                    new FlyoutMenuFlyoutMenuItem { Id = 3, Title = "PersonenDB", TargetType=typeof(PersonenDb.Nav.PDBFlyoutMenu) },
                    new FlyoutMenuFlyoutMenuItem { Id = 4, Title = "MVVM", TargetType=typeof(MVVMBsp.View.MainView) },
                    new FlyoutMenuFlyoutMenuItem { Id = 5, Title = "GoogleBooks", TargetType=typeof(Uebungen.GoogleBooks.View.MainView) },
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