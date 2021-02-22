using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StaffBankTerminalWPF.Model;
using StaffBankTerminalWPF.ViewModel;
using BankLibrary;
using BankLibrary.DI;//TODO IBank не должен быть там

namespace StaffBankTerminalWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBank bank;

        public MainWindow()
        {
            InitializeComponent();
            bank = new Bank("");
            DataContext = new BankViewModel(bank);
            
        }

        private void Load_Logs_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Logs_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Logger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Make_Operation_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Main_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rand_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_Data_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Data_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
