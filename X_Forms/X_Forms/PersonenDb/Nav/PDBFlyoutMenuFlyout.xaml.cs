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

namespace X_Forms.PersonenDb.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDBFlyoutMenuFlyout : ContentPage
    {
        public ListView ListView;

        public PDBFlyoutMenuFlyout()
        {
            InitializeComponent();

            BindingContext = new PDBFlyoutMenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class PDBFlyoutMenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PDBFlyoutMenuFlyoutMenuItem> MenuItems { get; set; }

            public PDBFlyoutMenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PDBFlyoutMenuFlyoutMenuItem>(new[]
                {
                    new PDBFlyoutMenuFlyoutMenuItem { Id = 0, Title = "Add to PDB" , TargetType=typeof(Pages.Pg_Add)},
                    new PDBFlyoutMenuFlyoutMenuItem { Id = 1, Title = "List of persons", TargetType=typeof(Pages.Pg_List)},
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