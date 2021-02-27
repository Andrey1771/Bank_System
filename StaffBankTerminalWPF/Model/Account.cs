using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Prism.Mvvm;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.FutureDatabase;
using BankLibrary.DI.Client;
using System.Collections.ObjectModel;


namespace StaffBankTerminalWPF.Model
{
    class Account : INotifyPropertyChanged, IBankAccount
    {
        private object cellData;
        public object CellData
        {
            get
            {
                return cellData;
            }
            set
            {
                cellData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CellData)));

            }
        }

        private IClient client;
        public IClient Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Client)));
            }
        }


        public string Name { 
            get
            {
                return Client.Name;
            }
            set
            {
                if (Client == null)
                {
                    Console.WriteLine("Попытка установить значение Name у Client = null");
                }
                else
                    Client.Name = value;///TODO Оставить так?

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }


        private decimal money;
        public decimal Money 
        { 
            get
            {
                return money;
            }
            set
            {
                money = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
            }
        }

        private decimal debt;
        public decimal Debt 
        { 
            get
            {
                return debt;
            }
            set
            {
                debt = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Debt)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Account()
        {
        }


        public static Account ToAccount(IBankAccount bankAccount)
        {
            var newAccount = new Account() { Client = bankAccount.Client,
                                             Debt = bankAccount.Debt,
                                             Money = bankAccount.Money,
                                             Name = bankAccount.Name };
            return newAccount;
        }

        public static List<Account> ToAccounts(ICollection<IBankAccount> bankAccountCollection)
        {
            var newAccountList = new List<Account>();
            foreach (var bankAccount in bankAccountCollection)
            {
                newAccountList.Add(ToAccount(bankAccount));
            }

            return newAccountList;
        }
    }
}
