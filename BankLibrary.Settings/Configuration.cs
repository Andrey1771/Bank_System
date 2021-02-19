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
			Container.Register<IHumanAccount, BankAccountHuman>(Lifestyle.Transient);
			Container.Register<IOrganizationAccount, BankAccountOrganization>(Lifestyle.Transient);
			//Container.Register<IShop, Shop>(Lifestyle.Singleton);
			Container.Register<ICard, BankCard>(Lifestyle.Transient);
			Container.Register<IDeposit, BankDeposit>(Lifestyle.Transient);
			Container.Register<ILoan, BankLoan>(Lifestyle.Transient);
			Container.Register<ILogger, Logger.Logger>(Lifestyle.Singleton);///TODO fix that
			Container.Register<IFileController, JSONSaveLoader.JSONSaveLoader>(Lifestyle.Singleton);///TODO fix that
			Container.Register<ILegalDepartment, LegalDepartment>(Lifestyle.Transient);
			Container.Register<IStandartDepartment, StandartDepartment>(Lifestyle.Transient);
			Container.Register<IVipDepartment, VipDepartment>(Lifestyle.Transient);
			Container.Register<IOrganizationClient, LegalClient>(Lifestyle.Transient);
			Container.Register<IStandartClient, StandartClient>(Lifestyle.Transient);
			Container.Register<IVipClient, VIPClient>(Lifestyle.Transient);

			//Container.Register<IHumanDepartment>(Lifestyle.Transient);
			//Container.Register<>(Lifestyle.Transient);
			//Container.Register<IData<IBook>, BookSqlData>(Lifestyle.Singleton);
			//Container.Register<IData<ICheck>, CheckSqlData>(Lifestyle.Singleton);
		}
	}
}
