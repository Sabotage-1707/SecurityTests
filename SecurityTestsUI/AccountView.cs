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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SecurityTestsUI
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        private User _currentUser;

        private CultureInfo _currentCulture;

        private ResourceManager resourseManager = new ResourceManager("SecurityTestsUI.Languages.Messages", typeof(MainView).Assembly);
        public AccountView()
        {
            InitializeComponent();
        }
        public AccountView(User currentUser, CultureInfo culture)
        {
            InitializeComponent();

            try
            {
                _currentCulture = culture;

                FillAllFields(_currentCulture);

                LoadRoles();

                InitializeUserData(currentUser);

                CheckStatuses();

                SetDateRange();

                

            }
            catch
            {
                ErrorSeparator.Visibility = Visibility.Visible;
                ErrorMessage.Text = resourseManager.GetString("LoginViewErrorMessage", _currentCulture);

            }
        }

        private void SetDateRange()
        {
            Birthday.DisplayDateStart = new DateTime(1900, 1, 1);
            Birthday.DisplayDateEnd = DateTime.UtcNow;
            
        }
        private void InitializeUserData(User currentUser)
        {
            _currentUser = currentUser;

            UserName.Text = _currentUser.UserName;

            Password.Text = _currentUser.UserPassword;

            Email.Text = _currentUser.EmailAddress;

            Name.Text = _currentUser.Name;

            Role.SelectedIndex = _currentUser.RoleId - 1;

            Birthday.Text = _currentUser.Birthday.ToString();

            CounterOfUsedTriesText.Text = _currentUser.CounterOfUsedTries.ToString();

            if (_currentUser.DateTimeOfLastTryByFireSafety.ToString().StartsWith("01.01.0001")||_currentUser.DateTimeOfLastTryByFireSafety == null)
            {
                DateTimeOfLastTryByFireSafetyText.Text = resourseManager.GetString("UserHaventPassedYet", _currentCulture);
            }
            else
            {
                DateTimeOfLastTryByFireSafetyText.Text = _currentUser.DateTimeOfLastTryByFireSafety.ToString();

            }
            if(_currentUser.DateTimeOfLastTryByIndustrialSafety.ToString().StartsWith("01.01.0001") || _currentUser.DateTimeOfLastTryByIndustrialSafety == null)
            {
                DateTimeOfLastTryByIndustrialSafetyText.Text = resourseManager.GetString("UserHaventPassedYet", _currentCulture);
            }
            else
            {
                DateTimeOfLastTryByIndustrialSafetyText.Text = _currentUser.DateTimeOfLastTryByIndustrialSafety.ToString();

            }
        }

        private void CheckStatuses()
        {
            if (_currentUser.VereficationStatusByFireSafety == false)
            {
                VerificationStatusByFireSafetyText.Foreground = Brushes.Red;
                VerificationStatusByFireSafetyText.Text = resourseManager.GetString("NonVereficated", _currentCulture);
            }
            else
            {
                VerificationStatusByFireSafetyText.Foreground = Brushes.LimeGreen;
                VerificationStatusByFireSafetyText.Text = resourseManager.GetString("Vereficated", _currentCulture);
            }

            if (_currentUser.VereficationStatusByIndustrialSafety == false)
            {
                VerificationStatusByIndustrialSafetyText.Foreground = Brushes.Red;
                VerificationStatusByIndustrialSafetyText.Text = resourseManager.GetString("NonVereficated", _currentCulture);
            }
            else
            {
                VerificationStatusByIndustrialSafetyText.Foreground = Brushes.LimeGreen;
                VerificationStatusByIndustrialSafetyText.Text = resourseManager.GetString("Vereficated", _currentCulture);
            }
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
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            try
            {
                CheckEmail();
                db.UpdateUser(_currentUser.Id, UserName.Text, Password.Text, Role.SelectedIndex + 1, Name.Text, Email.Text, DateTime.Parse(Birthday.Text));
                ErrorMessage.Text = resourseManager.GetString("UpdateAccountSuccess", _currentCulture);
                ErrorMessage.Foreground = Brushes.LimeGreen;
                ErrorSeparator.Visibility = Visibility.Visible;
                ErrorMessage.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message; 
                if (ex.Message.StartsWith("Истекло"))
                {
                    ErrorMessage.Text = resourseManager.GetString("LongTime", _currentCulture);
                }
                ErrorSeparator.Visibility = Visibility.Visible;
                ErrorMessage.Visibility = Visibility.Visible;
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

        private void FillAllFields(CultureInfo culture)
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(UserName, resourseManager.GetString("TextBoxUserName", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Password, resourseManager.GetString("TextBoxUserPassword", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Email, resourseManager.GetString("TextBoxEmail", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Name, resourseManager.GetString("TextBoxName", culture));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(Role, resourseManager.GetString("Roles", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Birthday, resourseManager.GetString("DatePicker", culture));

            VereficationStatusByFireSafetyLabel.Content = resourseManager.GetString("VereficationStatusByFireSafety", culture);
            VereficationStatusByIndustrialSafetyLabel.Content = resourseManager.GetString("VereficationStatusByIndustrialSafety", culture);

            CounterOfUsedTriesLabel.Content = resourseManager.GetString("CounterOfUsedTries", culture);
            DateTimeOfLastTryByFireSafetyLabel.Content = resourseManager.GetString("DateTimeOfLastTryByFireSafetyLabel", culture);
            DateTimeOfLastTryByIndustrialSafetyLabel.Content = resourseManager.GetString("DateTimeOfLastTryByIndustrialSafetyLabel", culture);


            UpdateAccountButton.Text = resourseManager.GetString("UpdateAccountButton", culture);
        }
    }
}
