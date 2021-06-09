using SecurityTestsUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class RegisterView : Window
    {

        private CultureInfo _currentCulture;
        private ResourceManager resourseManager = new ResourceManager("SecurityTestsUI.Languages.Messages", typeof(RegisterView).Assembly);

        public RegisterView()
        {
            InitializeComponent();

        }
        public RegisterView(CultureInfo culture)
        { 
            InitializeComponent();

            _currentCulture = culture;

            FillAllFields(_currentCulture);

            SetDateRange();

            LoadRoles();
        }

        private void SetDateRange()
        {
            Birthday.DisplayDateStart = new DateTime(1900, 1, 1);
            Birthday.DisplayDateEnd = DateTime.UtcNow;

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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            UserName.Text = "";
            Password.Text = "";
            Name.Text = "";
            Email.Text = "";
            Role.SelectedItem = null;
            Birthday.Text = "";
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();

            try
            {
                CheckEmail();

                CheckExistingUser(db);

                Check18YearsOld();

                db.CreateUser(UserName.Text, Password.Text, Role.SelectedIndex + 1, Name.Text, Email.Text, DateTime.Parse(Birthday.Text));

                ResetFields();

                HideError();

                ShowSuccessMessage();

            }
            catch (Exception ex)
            {

                HideSuccessMessage();

                ShowError(ex);

            }

        }
        private void CheckExistingUser(DataAccess db)
        {
            var users = db.GetUsers();
            foreach(var item in users)
            {
                if(UserName.Text.Equals(item.UserName))
                {
                    throw new Exception("Username is already taken");
                }
            }
        }
        private void CheckEmail()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email.Text);
            if (!match.Success)
            {
                throw new Exception("incorrect email");
            }
        }

        private void Check18YearsOld()
        {
            if(!(DateTime.Parse(Birthday.Text) < DateTime.UtcNow.AddYears(-18)))
            {
                throw new Exception("18 years");
            }
        }

        private void ShowError(Exception ex)
        {

            if (ex.Message.StartsWith("Истекло"))
            {
                ErrorMessage.Text = resourseManager.GetString("LongTime", _currentCulture);
            }
            else
            {
                ErrorMessage.Text = resourseManager.GetString("RegisterViewErrorMessage", _currentCulture);
            }
            if (ex.Message == "incorrect email")
            {
                ErrorMessage.Text = resourseManager.GetString("IncorrectEmail", _currentCulture);
            }
            if (ex.Message == "Username is already taken")
            {
                ErrorMessage.Text = resourseManager.GetString("UsernameTaken", _currentCulture);
            }
            if(ex.Message == "18 years")
            {
                ErrorMessage.Text = resourseManager.GetString("User18YearsOld", _currentCulture);
            }
            ErrorMessage.Visibility = Visibility.Visible;
        }

        private void ShowSuccessMessage()
        {

            SuccessMessage.Text = resourseManager.GetString("SuccessMessage",_currentCulture);
            SuccessMessage.Visibility = Visibility.Visible;
        }
        private void HideError()
        {
            ErrorMessage.Text = "";
            ErrorMessage.Visibility = Visibility.Collapsed;
        }

        private void HideSuccessMessage()
        {
            SuccessMessage.Text = "";
            ErrorMessage.Visibility = Visibility.Collapsed;
        }
        private void LoadRoles()
        {
            DataAccess db = new DataAccess();
            var roles = new List<Role>();
            try
            {
                roles = db.LoadRoles();
                Role.ItemsSource = roles;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
                ErrorMessage.Visibility = Visibility.Visible;
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginView login = new LoginView(_currentCulture);
            login.Show();
            this.Close();

        }

        private void FillAllFields(CultureInfo culture)
        { 

            RegisterViewDescriptionLabel.Text = resourseManager.GetString("RegisterViewDescriptionLabel", culture);

            MaterialDesignThemes.Wpf.HintAssist.SetHint(UserName, resourseManager.GetString("TextBoxUserName", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Password, resourseManager.GetString("TextBoxUserPassword", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Email, resourseManager.GetString("TextBoxEmail", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Name, resourseManager.GetString("TextBoxName", culture));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(Role, resourseManager.GetString("Roles", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Birthday, resourseManager.GetString("DatePicker", culture));

            Exit.ToolTip = resourseManager.GetString("ExitButton", culture);
            Back.ToolTip = resourseManager.GetString("BackButton", culture);

            Reset.Content = resourseManager.GetString("ResetButton", culture);
            Reset.ToolTip = resourseManager.GetString("ResetTooltip", culture);

            Register.Content = resourseManager.GetString("RegisterButton", culture);
            Register.ToolTip = resourseManager.GetString("RegisterTooltip", culture);

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
            await Task.Run(() => System.Diagnostics.Process.Start("Support.chm"));
        }
    }
}
