using SecurityTestsUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecurityTestsUI
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private User _currentUser;
        private CultureInfo _currentCulture;
        public MainView()
        {
            InitializeComponent();

        }

        public MainView(User currentUser, CultureInfo culture)
        {
            InitializeComponent();

            _currentUser = currentUser;

            _currentCulture = culture;

            UserNameShowed.Text = _currentUser.UserName;

            DataAccess db = new DataAccess();

            if (db.IsAdmin(_currentUser))
            {
                AdminMenuShow();
            }


            FillAllFields(_currentCulture);
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView(_currentCulture);
            login.Show();
            this.Close();
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu.Visibility = Visibility.Visible;
            CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu.Visibility = Visibility.Collapsed;
            CloseMenu.Visibility = Visibility.Visible;
        }

        private void AdminMenuShow()
        {
            AdminListItem.Visibility = Visibility.Visible;
            Tests.Visibility = Visibility.Collapsed;
            Account.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

            if (sender is ListViewItem listViewItem)
            {
                listViewItem.Background = new SolidColorBrush(Color.FromRgb(66, 71, 77));
            }
        }

        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is ListViewItem listViewItem)
            {
                listViewItem.Background = new SolidColorBrush(Color.FromRgb(46, 51, 58));
            }
        }

        private void ListView_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                    if (item == NavigationList.Items[0])
                    {
                        DataContext = new AdminView(_currentCulture);
                    }
                    if (item == NavigationList.Items[1])
                    {
                        DataContext = new TestsView(_currentUser, _currentCulture);
                    }
                    if (item == NavigationList.Items[2])
                    {
                        DataContext = new AccountView(_currentUser, _currentCulture);
                    }
                    if (item == NavigationList.Items[3])
                    {
                        CloseApp();
                    }
                
            }
            
        }
        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void UpdateWindow_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            var user = db.GetUser(_currentUser.Id);

            MainView mainView = new MainView(user, _currentCulture);
            mainView.Show();
            this.Close();
        }

        private void FillAllFields(CultureInfo culture)
        {

            var resourseManager = new ResourceManager("SecurityTestsUI.Languages.Messages", typeof(MainView).Assembly);

            MainViewDescriptionLabel.Text = resourseManager.GetString("MainViewDescriptionLabel", culture);
            TestsLabel.Text = resourseManager.GetString("Tests", culture);
            AccountLabel.Text = resourseManager.GetString("Account", culture);
            ExitAppLabel.Text = resourseManager.GetString("Exit", culture);
            AdminLabel.Text = resourseManager.GetString("Admin", culture);
            CurrentLanguage.Text = resourseManager.GetString("CurrentLanguage", culture);
            Help.Text = resourseManager.GetString("Help", culture);
            UpdateWindow.Text = resourseManager.GetString("UpdateWindow", culture);
            LogoutLabel.Text = resourseManager.GetString("Logout", culture);

        }

        private void EnglishLanguage_Click(object sender, RoutedEventArgs e)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            _currentCulture = culture;
            UpdateWindow_Click(sender, e);
        }

        private void RussianLanguage_Click(object sender, RoutedEventArgs e)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            _currentCulture = culture;
            UpdateWindow_Click(sender, e);
        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => System.Diagnostics.Process.Start("Support.chm"));
        }
    }
}
