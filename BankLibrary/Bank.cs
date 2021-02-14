using System;
using BankLibrary.DI;
using BankLibrary.Settings;
using BankLibrary.Departments;
using BankLibrary.DI.Department;


namespace BankLibrary
{
    public class Bank
    {
		/*LegalDepartment legalDepartment;
		StandartDepartment standartDepartment;
		VipDepartment vipDepartment;
		#region DI - Внедрение зависимости
		private static Configuration _configuration;

		private static ILegalDepartment CreateLegalDepartment(string name, string author, int price)
		{
			var book = _configuration.Container.GetInstance<ILegalDepartment>();
			book.Author = author;
			book.Name = name;
			book.Price = price;

			var shop = _configuration.Container.GetInstance<IShop>();
			shop.Add(book);

			return book;
		}

		private static ICheck CreateStandartDepartment(IBook book)
		{
			var shop = _configuration.Container.GetInstance<IShop>();
			var check = shop.Sell(book);

			return check;
		}

		private static IShop CreateVipDepartment(string name, string address)
		{
			var shop = _configuration.Container.GetInstance<IShop>();
			shop.Name = name;
			shop.Address = address;

			return shop;
		}

		private static IEnumerable<IBook> GetAllBooks()
		{
			var shop = _configuration.Container.GetInstance<IShop>();
			var books = shop.GetAllBooks();

			return books;
		}
		#endregion*/
	}
}
