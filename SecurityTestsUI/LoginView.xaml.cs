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

namespace SecurityTestsUI
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        private CultureInfo _currentCulture = CultureInfo.CreateSpecificCulture("en-us");

        private ResourceManager resourseManager = new ResourceManager("SecurityTestsUI.Languages.Messages", typeof(LoginView).Assembly);
        public LoginView()
        {
            InitializeComponent();

            FillAllFields(_currentCulture);
        }

        public LoginView(CultureInfo culture)
        {
            InitializeComponent();

            _currentCulture = culture;

            FillAllFields(_currentCulture);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
       
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            RegisterView registerWiew = new RegisterView(_currentCulture);
            this.Close();
            registerWiew.Show();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();


            try
            {
                var user = db.GetUser(UserName.Text, UserPassword.Password);

                if (user != null)
                {
                    MainView mainView = new MainView(user, _currentCulture);
                    mainView.Show();
                    this.Close();
                }
                else
                {
                    ErrorMessage.Text = resourseManager.GetString("LoginViewErrorMessage", _currentCulture);
                    ErrorMessage.Visibility = Visibility.Visible;
                }
            }catch(Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                if (ex.Message.StartsWith("Истекло"))
                {
                    ErrorMessage.Text = resourseManager.GetString("LongTime", _currentCulture);
                }
                ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private void FillAllFields(CultureInfo culture)
        {

            LoginViewDescriptionLabel.Text = resourseManager.GetString("LoginViewDescriptionLabel", culture);
            LogIn.Content = resourseManager.GetString("LogInButton", culture);
            SignUp.Content = resourseManager.GetString("SignUpButton", culture);
            MaterialDesignThemes.Wpf.HintAssist.SetHint(UserName, resourseManager.GetString("TextBoxUserName", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(UserPassword, resourseManager.GetString("PasswordBoxText", culture));
            Exit.ToolTip = resourseManager.GetString("ExitButton", culture);


            if (culture.Name.EndsWith("RU"))
            {
                CurrentLanguage.Text = "РУ";
            }
            else
            {
                CurrentLanguage.Text = "EN";
            }
        }

        private void EnglishLanguage_Click(object sender, RoutedEventArgs e)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            _currentCulture = culture;
            FillAllFields(culture);
            CurrentLanguage.Text = "EN";
        }

        private void RussianLanguage_Click(object sender, RoutedEventArgs e)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            _currentCulture = culture;
            FillAllFields(culture);
            CurrentLanguage.Text = "РУ";
        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            try { 
            await Task.Run(() => System.Diagnostics.Process.Start("Support.chm"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
