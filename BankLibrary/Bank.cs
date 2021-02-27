using System;
using BankLibrary.DI;
using BankLibrary.Settings;
//using BankLibrary.Departments;
using BankLibrary.DI.Department;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Client;
using BankLibrary.DI.FutureDatabase;
using System.Collections.Generic;


//using BankLibrary.BankAccountsObjects;//Нарушает DI паттерн temp
using BankLibrary.DI.Logger;
using BankLibrary.DI.Operations;
using System.Linq;
using System.Collections;

namespace BankLibrary
{
    public class Bank : IBank
    {
		#region DI - Внедрение зависимости
		private static Configuration _configuration;

		//CreateDepartments
		private static ILegalDepartment CreateLegalDepartment(string nameDepartment = "")
		{
			var legalDepartment = _configuration.Container.GetInstance<ILegalDepartment>();
			legalDepartment.Name = nameDepartment;///TODO Реализовать фабрику 

			return legalDepartment;
		}

		private static IStandartDepartment CreateStandartDepartment(string nameDepartment = "")
		{
			var standartDepartment = _configuration.Container.GetInstance<IStandartDepartment>();
			standartDepartment.Name = nameDepartment;///TODO Реализовать фабрику 

			return standartDepartment;
		}

		private static IVipDepartment CreateVipDepartment(string nameDepartment = "")
		{
			var vipDepartment = _configuration.Container.GetInstance<IVipDepartment>();
			vipDepartment.Name = nameDepartment;///TODO Реализовать фабрику 

			return vipDepartment;
		}
		//CreateDepartments


		//CreateClients
		private static IOrganizationClient CreateLegalClient(string name, DateTime foundationDate, decimal income, string nameOwner)
		{
			var organizationClient = _configuration.Container.GetInstance<IOrganizationClient>();
			organizationClient.Name = name;///TODO Реализовать фабрику 
			organizationClient.FoundationDate = foundationDate;
			organizationClient.Income = income;
			organizationClient.NameOwner = nameOwner;

			return organizationClient;
		}

		private static IStandartClient CreateStandartClient(string name, DateTime dateBirth, string[] jobTitles, decimal monthlyIncome)
		{
			var standartClient = _configuration.Container.GetInstance<IStandartClient>();
			standartClient.Name = name;///TODO Реализовать фабрику 
			standartClient.DateBirth = dateBirth;
			standartClient.JobTitles = jobTitles;
			standartClient.MonthlyIncome = monthlyIncome;

			return standartClient;
		}

		private static IVipClient CreateVIPClient(string name, DateTime dateBirth, string[] jobTitles, decimal monthlyIncome)
		{
			var vipClient = _configuration.Container.GetInstance<IVipClient>();
			vipClient.Name = name;///TODO Реализовать фабрику 
			vipClient.DateBirth = dateBirth;
			vipClient.JobTitles = jobTitles;
			vipClient.MonthlyIncome = monthlyIncome;

			return vipClient;
		}
		//CreateClients


		//CreateBankAccountObjects
		private static ICard CreateBankCard(string cardholderName, uint bim, int secretNumber, DateTime validDate = default(DateTime))
		{
			var cardCreator = _configuration.Container.GetInstance<ICardCreator>();
			
			return cardCreator.CreateCard(cardholderName, bim, secretNumber, validDate);
		}

		private static IDeposit CreateBankDeposit(string ownerName, decimal procentDeposit, DateTime closingDate, DateTime openingDate = default(DateTime))
		{
			var depositCreator = _configuration.Container.GetInstance<IDepositCreator>();

			return depositCreator.CreateDeposit(ownerName, procentDeposit, closingDate, openingDate);
		}

		private static ILoan CreateBankLoan(string ownerName, decimal procentLoan, DateTime closingDate, DateTime openingDate = default(DateTime))
		{
			var loanCreator = _configuration.Container.GetInstance<ILoanCreator>();

			return loanCreator.CreateLoan(ownerName, procentLoan, closingDate, openingDate);
		}
		//CreateBankAccountObjects

		//CreateLogger
		private static ILogger CreateLogger(string pathToFolderLogs)
		{
			var logger = _configuration.Container.GetInstance<ILogger>();
			logger.FileController = CreateFileControllerLogger();
			logger.PathToFolder = pathToFolderLogs;
			return logger;
		}
		//CreateLogger

		//CreateFileController
		private static IFileController<IRecord> CreateFileControllerLogger()
		{
			var fileController = _configuration.Container.GetInstance<IFileController<IRecord>>();
			return fileController;
		}
		//CreateFileController
		//CreateBankAccountObjects
		#endregion

		public IClient GetClient(uint id)
        {
            throw new NotImplementedException();
        }

        public bool GetAccount(IClient client, out IBankAccount bankAccount)
		{
			return DepartmentForClient(client).FindClientAccount(client, out bankAccount);
        }

		private IDepartment DepartmentForClient(IClient client)
        {
			if (client is IStandartClient)
			{
				return standartDepartment;
			}
			else if (client is IVipClient)
			{
				return vipDepartment;
			}
			else if (client is IOrganizationClient)
            {
				return legalDepartment;
            }
			else
			{
				throw new Exception("Client не соответствует ни одному департаменту");
			}
		}

        public bool AddCardToClientInDepartment(ICard card, IClient client)
        {
			IAddCard addCardOperation;
			if((addCardOperation = DepartmentForClient(client) as IAddCard) != null)
			{
				return addCardOperation.AddCard(card, client);
			}

			return false;
        }

        public bool AddLoanToClientInDepartment(ILoan loan, IClient client)
        {
			IAddLoan addLoanOperation;
			if ((addLoanOperation = DepartmentForClient(client) as IAddLoan) != null)
			{
				return addLoanOperation.AddLoan(loan, client);
			}

			return false;
		}

        public bool AddDepositToClientInDepartment(IDeposit deposit, IClient client)
        {
			IAddDeposit addDepositOperation;
			if ((addDepositOperation = DepartmentForClient(client) as IAddDeposit) != null)
			{
				return addDepositOperation.AddDeposit(deposit, client);
			}

			return false;
		}

        public bool AddNewClientInDepartment(IClient client)
        {
			return DepartmentForClient(client).AddClientAccount(client);
		}

        public bool AddNewBankAccount(IBankAccount bankAccount)
        {
			return DepartmentForClient(bankAccount.Client).AddClientAccount(bankAccount);
		}

        ILegalDepartment legalDepartment;
		IStandartDepartment standartDepartment;
		IVipDepartment vipDepartment;

        public ICollection<IClient> Clients => throw new NotImplementedException();


        public ICollection<IBankAccount> Accounts 
		{ 
			get
            {
				return (ICollection<IBankAccount>)legalDepartment.Accounts.Concat(standartDepartment.Accounts).Concat(vipDepartment.Accounts);
			}
		}

		ICollection<ILoan> loans;
        public ICollection<ILoan> Loans
        {
			get
            {

				return loans /*legalDepartment.Accounts.ElementAt(0).Debt*/;
            }
		}


        public ICollection<IDeposit> Deposits => throw new NotImplementedException();

        public ICollection<ICard> Cards => throw new NotImplementedException();

        public ILogger Logger { get; set; }/// TODO Добавить сохранение при смене 
        //public IFileController FileController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Bank(string pathToSaveLogs)
        {
			
			//Accounts = new List<IBankAccount>();///
			_configuration = new Configuration();
			legalDepartment = CreateLegalDepartment();
			standartDepartment = CreateStandartDepartment();
			vipDepartment = CreateVipDepartment();
			Logger = CreateLogger(pathToSaveLogs);
		}


	}
}
