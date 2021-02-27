using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using BankLibrary.DI;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.FutureDatabase;
using BankLibrary.DI.Client;
using StaffBankTerminalWPF.Model;


using BankLibrary.Client;//Надо будет потом убрать ссылку

namespace StaffBankTerminalWPF.ViewModel
{
    enum TypeColumns
    {
        Accounts, Cards, Deposits, Loans, Clients
    }
    class BankViewModel : BindableBase
    {
        public Dictionary<TypeColumns, string> TablesNames
        { 
            get
            { 
                return new Dictionary<TypeColumns, string> { { TypeColumns.Accounts, nameof(BankAccounts) },
                                                             { TypeColumns.Cards, nameof(BankCards) } }; 
            } 
        }

        ObservableCollection<Account> bankAccounts;
        public ObservableCollection<Account> BankAccounts
        { 
            get
            {
                return new ObservableCollection<Account>() { new Account() { Client = (new StandartClient()),  Name = "NAMEME" } };
            }
            set
            {
                bankAccounts = value;
            }
        }

        ObservableCollection<Card> bankCards;
        public ObservableCollection<Card> BankCards
        { 
            get
            {
                return bankCards;
            }
            set
            {
                bankCards = value;
            }
        }

        ObservableCollection<Card> bankClients;
        public ObservableCollection<Card> BankClients
        {
            get
            {
                return bankClients;
            }
            set
            {
                bankClients = value;
            }
        }
        ObservableCollection<Card> bankDeposits;
        public ObservableCollection<Card> BankDeposits
        {
            get
            {
                return bankDeposits;
            }
            set
            {
                bankDeposits = value;
            }
        }
        ObservableCollection<Card> bankLoans;
        public ObservableCollection<Card> BankLoans
        {
            get
            {
                return bankLoans;
            }
            set
            {
                bankLoans = value;
            }
        }

        IBank bank;
        public IBank Bank 
        {
            get
            {
                return bank;
            }
            set
            {
                bank = value;
                BankAccounts = new ObservableCollection<Account>(Account.ToAccounts(Bank.Accounts));
            }
        }
        //private static Dictionary<TypeColumns, List<string>> nameColumns;

        public BankViewModel(/*IBank abank*/)
        {
            //Bank = abank;
            //bankAccounts = new ObservableCollection<Account>(Account.ToAccounts(Bank.Accounts));//Temp
        }




        /*ObservableCollection<IBankAccount> Accounts { get { return (ObservableCollection<IBankAccount>)bank.Accounts;*//*Нужно оптимизировать*//* } }
        ObservableCollection<ICard> Cards { get { return (ObservableCollection<ICard>)bank.Cards; }*//*Нужно оптимизировать*//*  }
        ObservableCollection<IDeposit> Deposits { get { return (ObservableCollection<IDeposit>)bank.Deposits; }*//*Нужно оптимизировать*//*  }
        ObservableCollection<ILoan> Loans { get { return (ObservableCollection<ILoan>)bank.Loans; }*//*Нужно оптимизировать*//*  }
        ObservableCollection<IClient> Clients { get { return (ObservableCollection<IClient>)bank.Clients; }*//*Нужно оптимизировать*//*  }*/

        
        

        /*public static List<string> NameColumns
        {
            get
            {
                return nameColumns[CurrentTypeColumns];
            }
        }
        private static TypeColumns currentTypeColumns;
        public static TypeColumns CurrentTypeColumns
        {
            get
            {
                return currentTypeColumns;
            }
            set
            {
                currentTypeColumns = value;
            }
        }

        public List<object> CellsData { get; private set; }*/

    }
}
