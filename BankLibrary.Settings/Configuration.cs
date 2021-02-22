using System;
using SimpleInjector;
using BankLibrary.DI;
using BankLibrary.FutureDatabase;
using BankLibrary.DI.BankAccounts;
using BankLibrary.Logger;
using BankLibrary.JSONSaveLoader;
using BankLibrary.DI.Operations;
using BankLibrary.Departments;
using BankLibrary.DI.Department;
using BankLibrary.Accounts;
using BankLibrary.DI.FutureDatabase;
using BankLibrary.BankAccountsObjects;
using BankLibrary.DI.Client;
using BankLibrary.Client;
using BankLibrary.DI.Logger;

namespace BankLibrary.Settings
{
    public class Configuration
    {
		public Container Container { get; }

		public Configuration()
		{
			Container = new Container();

			Setup();
		}

		public virtual void Setup()
		{
			//Container.Register<IClient, ClientAbstract>(Lifestyle.Transient);
			/*Container.Register<IHumanAccount, BankAccountHuman>(Lifestyle.Transient);
			Container.Register<IOrganizationAccount, BankAccountOrganization>(Lifestyle.Transient);*/
			/*Container.Register<ICard, BankCard>(Lifestyle.Transient);
			Container.Register<IDeposit, BankDeposit>(Lifestyle.Transient);
			Container.Register<ILoan, BankLoan>(Lifestyle.Transient);*/
			///TODO Убрать?
			Container.Register<IHumanAccountCreator, BankAccountHumanCreator>(Lifestyle.Singleton);
			Container.Register<IOrganizationAccountCreator, BankAccountOrganizationCreator>(Lifestyle.Singleton);
			///TODO Убрать?

			Container.Register<ICardCreator, BankCardCreator>(Lifestyle.Singleton);
			Container.Register<IDepositCreator, BankDepositCreator>(Lifestyle.Singleton);
			Container.Register<ILoanCreator, BankLoanCreator>(Lifestyle.Singleton);

			Container.Register<ILogger, Logger.Logger>(Lifestyle.Singleton);///TODO fix that
			Container.Register<IFileController<IRecord>, JSONSaveLoader<IRecord>>(Lifestyle.Singleton);///TODO fix that
			Container.Register<ILegalDepartment, LegalDepartment>(Lifestyle.Transient);
			Container.Register<IStandartDepartment, StandartDepartment>(Lifestyle.Transient);
			Container.Register<IVipDepartment, VipDepartment>(Lifestyle.Transient);
			Container.Register<IOrganizationClient, LegalClient>(Lifestyle.Transient);
			Container.Register<IStandartClient, StandartClient>(Lifestyle.Transient);
			Container.Register<IVipClient, VIPClient>(Lifestyle.Transient);
			//Container.Register<IHumanDepartment>(Lifestyle.Transient);
		}
	}
}
