using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using X_Forms.Uebungen.BankingApp.Model;

namespace X_Forms.Uebungen.BankingApp.Service
{
    public static class AccountService
    {
        public static ObservableCollection<Account> AccountList { get; set; }
        static DatabaseService dbService = new DatabaseService();
            
        internal static void LoadAccounts()
        {
            AccountList = dbService.GetAll<Account>();
        }
        internal static ObservableCollection<Account> GetAccounts(int ownerId)
        {
            try
            {
                LoadAccounts();
                return new ObservableCollection<Account>(AccountList.Where(x => x.OwnerId == ownerId));
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static void Insert(Account account)
        {
            AccountList.Add(account);
            dbService.Insert(account);
        }

        public static void Deposit(Account account, double sum)
        {
            account.Balance += sum;
            dbService.Update(account);
        }

        public static void Withdraw(Account account, double sum)
        {
            account.Balance -= sum;
            dbService.Update(account);
        }
    }
}
