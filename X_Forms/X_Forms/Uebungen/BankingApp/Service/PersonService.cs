using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace X_Forms.Uebungen.BankingApp.Service
{
    public static class PersonService
    {
        public static ObservableCollection<Model.Person> PersonList { get; set; }
        public static Model.Person SelectedPerson { get; set; }

        internal static void LoadPeople()
        {
            DatabaseService dbService = new DatabaseService();
            PersonList = dbService.GetAll<Model.Person>();
        }

        internal static bool AreCredentialsCorrect(string fullname, string password)
        {
            try
            {
                if (PersonList.First(x => x.Fullname == fullname && x.Password == password) != null)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        internal static void Login(string fullname, string password)
        {
            try
            {
                SelectedPerson = PersonList.First(x => x.Fullname == fullname && x.Password == password);
            }
            catch (Exception)
            {

            }
        }

        internal static bool Insert(Model.Person newPerson)
        {

            if (PersonList.Any(x => x.Fullname == newPerson.Fullname))
                return false;
            else
            {
                DatabaseService dbService = new DatabaseService();

                PersonList.Add(newPerson);
                dbService.Insert(newPerson);

                return true;
            }
        }

        internal static int GetNewId()
        {
            DatabaseService dbService = new DatabaseService();
            try
            {
                return dbService.GetAll<Model.Person>().OrderBy(x => x.Id).Last().Id + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }
    }
}