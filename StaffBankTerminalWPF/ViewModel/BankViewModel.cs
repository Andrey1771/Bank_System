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


namespace StaffBankTerminalWPF.ViewModel
{
    enum TypeColumns
    {
        Accounts, Cards, Deposits, Loans, Clients
    }
    class BankViewModel : BindableBase
    {
        ObservableCollection<Account> bankAccounts;

        public static IBank Bank { get; set; }
        //private static Dictionary<TypeColumns, List<string>> nameColumns;

        public BankViewModel(IBank abank)
        {
            Bank = abank;
            bankAccounts = new ObservableCollection<Account>((List<Account>)Bank.Accounts);//Temp
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
