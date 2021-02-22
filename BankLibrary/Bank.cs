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

		public IClient GetClient(uint id)
        {
            throw new NotImplementedException();
        }

        public IBankAccount GetAccount(IClient client)
        {
            throw new NotImplementedException();
        }

        public bool AddCardToClientInDepartment(ICard card, IClient client)
        {
            throw new NotImplementedException();
        }

        public bool AddLoanToClientInDepartment(ILoan loan, IClient client)
        {
            throw new NotImplementedException();
        }

        public bool AddDepositToClientInDepartment(IDeposit deposit, IClient client)
        {
            throw new NotImplementedException();
        }

        //CreateBankAccountObjects
        #endregion

        ILegalDepartment legalDepartment;
		IStandartDepartment standartDepartment;
		IVipDepartment vipDepartment;

        public ICollection<IClient> Clients => throw new NotImplementedException();

        public ICollection<IBankAccount> Accounts => throw new NotImplementedException();

        public ICollection<ILoan> Loans => throw new NotImplementedException();

        public ICollection<IDeposit> Deposits => throw new NotImplementedException();

        public ICollection<ICard> Cards => throw new NotImplementedException();

        public ILogger Logger { get; set; }/// TODO Добавить сохранение при смене 
        //public IFileController FileController { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Bank(string pathToSaveLogs)
        {
			_configuration = new Configuration();
			legalDepartment = CreateLegalDepartment();
			standartDepartment = CreateStandartDepartment();
			vipDepartment = CreateVipDepartment();
			Logger = CreateLogger(pathToSaveLogs);
		}
	}
}
