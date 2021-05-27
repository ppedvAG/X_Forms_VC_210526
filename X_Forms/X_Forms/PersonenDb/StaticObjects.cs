using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.PersonenDb
{
    //Statische Klasse mit globalen Objekten (kann auch Service- und Controllerobjekte beinhalten)
    public static class StaticObjects
    {
        private static ObservableCollection<Model.Person> personenListe;
        public static ObservableCollection<Model.Person> PersonenListe
        {
            get
            {
                if (personenListe == null)
                {
                    personenListe = new ObservableCollection<Model.Person>()
                    {
                        new Model.Person() { Vorname = "Rainer", Nachname = "Zufall" }
                    };
                }
                return personenListe;
            }
            set { personenListe = value; }
        }
    }
}