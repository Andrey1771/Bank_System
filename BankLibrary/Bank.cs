using System;
using BankLibrary.DI;
using BankLibrary.Settings;
//using BankLibrary.Departments;
using BankLibrary.DI.Department;
using BankLibrary.DI.BankAccounts;
using BankLibrary.DI.Client;
using BankLibrary.DI.FutureDatabase;
using System.Collections.Generic;


using BankLibrary.BankAccountsObjects;//Нарушает паттерн temp


namespace BankLibrary
{
    public class Bank
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

		private static IVIPClient CreateVIPClient(string name, DateTime dateBirth, string[] jobTitles, decimal monthlyIncome)
		{
			var vIPClient = _configuration.Container.GetInstance<IVIPClient>();
			vIPClient.Name = name;///TODO Реализовать фабрику 
			vIPClient.DateBirth = dateBirth;
			vIPClient.JobTitles = jobTitles;
			vIPClient.MonthlyIncome = monthlyIncome;

			return vIPClient;
		}
		//CreateClients


		//CreateBankAccountObjects temp
		private static ICard CreateBankCard(string cardholderName, uint bim, int secretNumber, DateTime validDate = default(DateTime))
		{
			return new BankCard(cardholderName, bim, secretNumber, validDate);
		}

		private static IDeposit CreateBankDeposit(string ownerName, decimal procentDeposit, DateTime closingDate, DateTime openingDate = default(DateTime))
		{
			return new BankDeposit(ownerName, procentDeposit, closingDate, openingDate);
		}

		private static ILoan CreateBankLoan(string ownerName, decimal procentLoan, DateTime closingDate, DateTime openingDate = default(DateTime))
		{
			return new BankLoan(ownerName, procentLoan, closingDate, openingDate);
		}
		//CreateBankAccountObjects
		#endregion

		ILegalDepartment legalDepartment;
		IStandartDepartment standartDepartment;
		IVipDepartment vipDepartment;

		public Bank()
        {
			legalDepartment = CreateLegalDepartment();
			standartDepartment = CreateStandartDepartment();
			vipDepartment = CreateVipDepartment();
		}
	}
}
