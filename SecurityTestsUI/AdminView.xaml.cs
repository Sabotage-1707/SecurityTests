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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using SecurityTestsUI.Reports;
using System.Threading;
using System.Text.RegularExpressions;

namespace SecurityTestsUI
{
    /// <summary>
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        CultureInfo _currentCulture;
        private ObservableCollection<User> Users { get; set; }
        private ObservableCollection<Answers> Answers { get; set; }

        private ObservableCollection<Questions> Questions { get; set; }

        private ObservableCollection<Role> RolesCollection { get; set; }

        private ObservableCollection<TypesOfQuestion> TypesOfQuestionCollection { get; set; }

        private ResourceManager resourseManager = new ResourceManager("SecurityTestsUI.Languages.Messages", typeof(MainView).Assembly);
        public AdminView()
        {
            InitializeComponent();

        }

        public AdminView(CultureInfo culture)
        {
            InitializeComponent();

            _currentCulture = culture;

            LoadRoles();

            LoadTypesOfQuestion();

            InitializeDataGrids();

            FillAllFields(_currentCulture);
        }

        private void InitializeDataGrids()
        {
            DataAccess db = new DataAccess();
            
            Users = new ObservableCollection<User>(db.GetUsers());
            Answers = new ObservableCollection<Answers>(db.GetAnswers());
            RolesCollection = new ObservableCollection<Role>(db.GetRoles());
            Questions = new ObservableCollection<Questions>(db.GetQuestions());
            TypesOfQuestionCollection = new ObservableCollection<TypesOfQuestion>(db.GetTypes());

            UsersDataGrid.ItemsSource = Users;
            AnswersDataGrid.ItemsSource = Answers;
            QuestionsDataGrid.ItemsSource = Questions;
            RolesDataGrid.ItemsSource = RolesCollection;
            TypesDataGrid.ItemsSource = TypesOfQuestionCollection;
        }
        //public List<Answers> GetAnswersRus()
        //{
        //    using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
        //    {
        //        var output = db.Query<Answers>($"select id as N'Ид', Answer as N'Ответ',IsCorrect as 'Верность', QuestionId as 'Ид Вопроса' from Answers").ToList();
        //        return output;
        //    }
        //}
        //public List<Questions> GetQuestionsRus()
        //{
        //    using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
        //    {
        //        var output = db.Query<Questions>($"select id as N'Ид',Question as N'Вопрос', RoleId as N'Ид Роли',RoleId as N'Ид Роли', TypeOfQuestionId as N'Ид Типа Вопроса' from Questions").ToList();
        //        return output;
        //    }
        //}
        //public List<TypesOfQuestion> GetTypesRus()
        //{
        //    using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
        //    {
        //        var output = db.Query<TypesOfQuestion>($"select id as N'Ид',Type as N'Тип' from TypesOfQuestion").ToList();
        //        return output;
        //    }
        //}
        //public List<Role> GetRolesRus()
        //{
        //    using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
        //    {
        //        var output = db.Query<Role>($"select id as N'Ид',RoleName as N'Название Роли' from Roles").ToList();
        //        return output;
        //    }
        //}
        //public List<User> GetUsersRus()
        //{
        //    using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
        //    {

        //        var output = db.Query<User>($"select id as N'Ид',UserName as N'Никнейм Пользователя',UserPassword as N'Пароль', RoleId as N'Ид Роли', Name as N'Имя Пользователя', EmailAddress as N'Почта', Birthday as N'Дата Рождения'," +
        //            $"VereficationStatusByFireSafety as N'Статус верифицирования по пожарной бзопасности',VereficationStatusByIndustrialSafety as N'Статус верифицирования по промышленной бзопасности', CounterOfUsedTries as N'Количество Попыток Прохождения', DateTimeOfLastTryByFireSafety as N'Дата последнего прохождения верификации по пожарной безопасности', DateTimeOfLastTryByIndustrialSafety as N'Дата последнего прохождения верификации по промышленной безопасности' from Users").ToList();
        //        return output;
        //    }
        //}
        private void ComboBoxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckFields();
        }
        private void Question_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckFields();
        }
        private void LoadRoles()
        {
            DataAccess db = new DataAccess();
            var roles = new List<Role>();
            
            try
            {
                roles = db.LoadRoles();
                Roles.ItemsSource = roles;
                RoleUser.ItemsSource = roles;
            }
            catch (Exception ex)
            {
                ShowError(ex, ErrorMessage, ErrorSeparator);
            }

        }
        private void LoadTypesOfQuestion()
        {
            DataAccess db = new DataAccess();
            var types = new List<TypesOfQuestion>();
            try
            {
                types = db.LoadTypesOfQuestion();
                TypeOfQuestion.ItemsSource = types;
            }
            catch (Exception ex)
            {
                ShowError(ex, ErrorMessage, ErrorSeparator);
            }

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.CreateQuestion(Question.Text,TypeOfQuestion.SelectedIndex + 1, Roles.SelectedIndex + 1);

                db.CreateAnswer(Answer1.Text, IsAnswer1Correct.IsEnabled, db.GetQuestionId(Question.Text));
                db.CreateAnswer(Answer2.Text, IsAnswer2Correct.IsEnabled, db.GetQuestionId(Question.Text));
                db.CreateAnswer(Answer3.Text, IsAnswer3Correct.IsEnabled, db.GetQuestionId(Question.Text));
                db.CreateAnswer(Answer4.Text, IsAnswer4Correct.IsEnabled, db.GetQuestionId(Question.Text));
                ShowSuccess(ErrorMessage, ErrorSeparator, "QuestionAddSuccess");
                
            }
            catch (Exception ex)
            {
                ShowError(ex, ErrorMessage, ErrorSeparator);
            }
        }
        private void CheckFields()
        {
            if(Question.Text.Equals("") || Roles.SelectedItem == null || TypeOfQuestion.SelectedItem == null 
                || Answer1.Text.Equals("") || Answer2.Text.Equals("") || Answer3.Text.Equals("") || Answer4.Text.Equals(""))
            {
                AddQuestionButton.IsEnabled = false;
            }
            else
            {
                if (IsAnswer1Correct.IsChecked == true || IsAnswer2Correct.IsChecked == true || IsAnswer3Correct.IsChecked == true || IsAnswer4Correct.IsChecked == true)
                {
                    AddQuestionButton.IsEnabled = true;
                }
                else
                {
                    AddQuestionButton.IsEnabled = false;
                }
            }
        }
        private void FillAllFields(CultureInfo culture)
        {
            AddQuestionTab.Header =  resourseManager.GetString("AddQuestionTab", culture);
            ReportsTab.Header = resourseManager.GetString("ReportsTab", culture);
            UsersTab.Header = resourseManager.GetString("UsersTab", culture);
            AnswersTab.Header = resourseManager.GetString("AnswersTab", culture);
            QuestionsTab.Header = resourseManager.GetString("QuestionsTab", culture);
            RolesTab.Header = resourseManager.GetString("RolesTab", culture);
            TypesOfQuestionsTab.Header = resourseManager.GetString("TypesTab", culture);

            MaterialDesignThemes.Wpf.HintAssist.SetHint(Question, resourseManager.GetString("TextBoxQuestion", culture));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(TypeOfQuestion, resourseManager.GetString("TypesOfQuestion", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Roles, resourseManager.GetString("AdminRoles", culture));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(UserName, resourseManager.GetString("TextBoxUserName", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(UserPassword, resourseManager.GetString("TextBoxUserPassword", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Email, resourseManager.GetString("TextBoxEmail", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(NameUser, resourseManager.GetString("TextBoxName", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(CounterOfUsedTries, resourseManager.GetString("CounterOfUsedTries", culture));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(RoleUser, resourseManager.GetString("Roles", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Birthday, resourseManager.GetString("DatePicker", culture));

            FireSafety.Content = resourseManager.GetString("VereficatedByFireSafety", culture);
            IndustrialSafety.Content = resourseManager.GetString("VereficatedByIndustrialSafety", culture);

            MaterialDesignThemes.Wpf.HintAssist.SetHint(RoleName, resourseManager.GetString("EnterRoleName", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(TypeName, resourseManager.GetString("EnterType", culture));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(Answer1, resourseManager.GetString("FirstAnswerTextBox", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Answer2, resourseManager.GetString("SecondAnswerTextBox", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Answer3, resourseManager.GetString("ThirdAnswerTextBox", culture));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(Answer4, resourseManager.GetString("FourthAnswerTextBox", culture));

            IsAnswer1Correct.Content = resourseManager.GetString("IsCorrectAnswer", culture);
            IsAnswer2Correct.Content = resourseManager.GetString("IsCorrectAnswer", culture);
            IsAnswer3Correct.Content = resourseManager.GetString("IsCorrectAnswer", culture);
            IsAnswer4Correct.Content = resourseManager.GetString("IsCorrectAnswer", culture);

            AddQuestionButtonText.Text = resourseManager.GetString("AddQuestionButtonText", culture);
            AddUserButton.Text = resourseManager.GetString("AddButton", culture);
            UpdateUserButton.Text = resourseManager.GetString("UpdateButton", culture);
            DeleteUserButton.Text = resourseManager.GetString("DeleteButton", culture);

            UpdateAnswerButton.Text = resourseManager.GetString("UpdateButton", culture);
            DeleteAnswerButton.Text = resourseManager.GetString("DeleteButton", culture);

            AddRoleButton.Text = resourseManager.GetString("AddButton", culture);
            UpdateRoleButton.Text = resourseManager.GetString("UpdateButton", culture);
            DeleteRoleButton.Text = resourseManager.GetString("DeleteButton", culture);

            UpdateQuestionButton.Text = resourseManager.GetString("UpdateButton", culture);
            DeleteQuestionButton.Text = resourseManager.GetString("DeleteButton", culture);

            AddTypeButton.Text = resourseManager.GetString("AddButton", culture);
            UpdateTypeButton.Text = resourseManager.GetString("UpdateButton", culture);
            DeleteTypeButton.Text = resourseManager.GetString("DeleteButton", culture);

            ReportByEmployees.Content = resourseManager.GetString("EmployeesReport", culture);
            ReportByManagers.Content = resourseManager.GetString("ManagersReport", culture);
            ReportByWorkers.Content = resourseManager.GetString("WorkersReport", culture);

            UsersDataGridId.Header = resourseManager.GetString("Id", _currentCulture);
            UsersDataGridUserName.Header = resourseManager.GetString("UserName", _currentCulture);
            UsersDataGridUserPassword.Header = resourseManager.GetString("UserPassword", _currentCulture);
            UsersDataGridRoleId.Header = resourseManager.GetString("RoleId", _currentCulture);
            UsersDataGridName.Header = resourseManager.GetString("Name", _currentCulture);
            UsersDataGridEmail.Header = resourseManager.GetString("EmailAddress", _currentCulture);
            UsersDataGridBirthday.Header = resourseManager.GetString("Birhday", _currentCulture);
            UsersDataGridFireSafety.Header = resourseManager.GetString("VereficationStatusByFireSafetyAdmin", _currentCulture);
            UsersDataGridIndustrialSafety.Header = resourseManager.GetString("VereficationStatusByIndustrialSafetyAdmin", _currentCulture);
            UsersDataGridFireSafetyTry.Header = resourseManager.GetString("DateTimeOfLastTryByFireSafety", _currentCulture);
            UsersDataGridIndustrialSafetyTry.Header = resourseManager.GetString("DateTimeOfLastTryByIndustrialSafety", _currentCulture);
            UsersDataGridCounterTries.Header = resourseManager.GetString("CounterOfUsedTries", _currentCulture);

            AnswersDataGridId.Header = resourseManager.GetString("Id", _currentCulture);
            AnswersDataGridAnswer.Header = resourseManager.GetString("Answer", _currentCulture);
            AnswersDataGridQuestionId.Header = resourseManager.GetString("QuestionId", _currentCulture);
            AnswersDataGridIsCorrect.Header = resourseManager.GetString("IsCorrectAnswer", _currentCulture);

            QuestionsDataGridId.Header = resourseManager.GetString("Id", _currentCulture);
            QuestionsDataGridQuestion.Header = resourseManager.GetString("Question", _currentCulture);
            QuestionsDataGridRoleId.Header = resourseManager.GetString("RoleId", _currentCulture);
            QuestionsDataGridTypeOfQuestionId.Header = resourseManager.GetString("TypeOfQuestionId", _currentCulture);

            RolesDataGridId.Header = resourseManager.GetString("Id", _currentCulture);
            RolesDataGridRoleName.Header = resourseManager.GetString("RoleName", _currentCulture);

            TypesDataGridId.Header = resourseManager.GetString("Id", _currentCulture);
            TypesDataGridType.Header = resourseManager.GetString("Type", _currentCulture);

        }

        private void ReportByEmployees_Click(object sender, RoutedEventArgs e)
        {
            ReportsView reportView;
            if (_currentCulture.Name.EndsWith("RU"))
            {
                var report = new ReportByEmployeesRu();
                reportView = new ReportsView(report);
            }
            else
            {
               var report = new ReportByEmployees();
               reportView = new ReportsView(report);
            } 
            reportView.Show();
        }
        
        private void ReportByManagers_Click(object sender, RoutedEventArgs e)
        {
            ReportsView reportView;
            if (_currentCulture.Name.EndsWith("RU"))
            {
                var report = new ReportByManagersRu();
                reportView = new ReportsView(report);
            }
            else
            {
                var report = new ReportByManagers();
                reportView = new ReportsView(report);
            }
            reportView.Show();
        }

        private  void ReportByWorkers_Click(object sender, RoutedEventArgs e)
        {
            ReportsView reportView;
            if (_currentCulture.Name.EndsWith("RU"))
            {
                var report = new ReportByWorkersRu();
                reportView = new ReportsView(report);
            }
            else
            {
                var report = new ReportByWorkers();
                reportView = new ReportsView(report);
            }
            reportView.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e){}
        private void FireSafety_Checked(object sender, RoutedEventArgs e){}

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if(UsersDataGrid.SelectedItem != null)
            {
                try
                {
                    var user = UsersDataGrid.SelectedItem as User;
                    DataAccess db = new DataAccess();
                    CheckEmail();
                    db.UpdateUser(user.Id, user.UserName, user.UserPassword, user.RoleId, user.Name, user.EmailAddress,
                        user.Birthday, user.CounterOfUsedTries,user.DateTimeOfLastTryByFireSafety, user.DateTimeOfLastTryByIndustrialSafety);
                    ShowSuccess(UserErrorMessage, UserErrorSeparator, "UpdateUserSuccess");
               
                }
                catch (ArgumentException)
                {
                    ShowArgumentNullError("IncorrectData", UserErrorMessage, UserErrorSeparator);
                }
                catch (Exception ex)
                {
                    ShowError(ex, UserErrorMessage, UserErrorSeparator);
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
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();
                db.CreateUser( UserName.Text, UserPassword.Text, RoleUser.SelectedIndex + 1, NameUser.Text, Email.Text, DateTime.Parse(Birthday.Text), FireSafety.IsChecked, IndustrialSafety.IsChecked, Int32.Parse(CounterOfUsedTries.Text));
                ShowSuccess(UserErrorMessage, UserErrorSeparator, "UserAddSuccess");
            }
            catch (ArgumentNullException)
            {
                ShowArgumentNullError("FieldsAreNotFilled", UserErrorMessage, UserErrorSeparator);
            }
            catch (Exception ex)
            {
                ShowError(ex, UserErrorMessage, UserErrorSeparator);
            }
        }

        private void ShowArgumentNullError(string message, TextBlock textBlock, Separator separator)
        {
            textBlock.Text = resourseManager.GetString(message, _currentCulture);
            separator.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Visible;
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem != null)
            {
                try
                {
                    var user = UsersDataGrid.SelectedItem as User;
                    DataAccess db = new DataAccess();
                    db.DeleteUser(user.Id);
                    ShowSuccess(UserErrorMessage, UserErrorSeparator, "UserDeletedSuccess");
                }
                catch (Exception ex)
                {
                    ShowError(ex, UserErrorMessage, UserErrorSeparator);
                }
            }
        }

        private void UpdateAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (AnswersDataGrid.SelectedItem != null)
            {
                try
                {

                    var answer = AnswersDataGrid.SelectedItem as Answers;
                    DataAccess db = new DataAccess();
                    db.UpdateAnswer(answer.Id, answer.Answer, answer.IsCorrect, answer.QuestionId);
                    ShowSuccess(AnswersErrorMessage, AnswersErrorSeparator, "UpdateAnswerSuccess");
                }
                catch (Exception ex)
                {
                    ShowError(ex,AnswersErrorMessage,AnswersErrorSeparator);
                }
            }
        }

        private void ShowSuccess(TextBlock textBlock, Separator separator, string variable)
        {
            textBlock.Text = resourseManager.GetString(variable, _currentCulture);
            textBlock.Foreground = Brushes.LimeGreen;
            separator.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Visible;
        }

        private void ShowError(Exception ex, TextBlock textBlock, Separator separator)
        {
            textBlock.Text = ex.Message;
            if (ex.Message.StartsWith("Истекло"))
            {
                textBlock.Text = resourseManager.GetString("LongTime", _currentCulture);
            }
            separator.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Visible;
        }

        private void DeleteAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (AnswersDataGrid.SelectedItem != null)
            {
                try
                {
                    var answer = AnswersDataGrid.SelectedItem as Answers;
                    DataAccess db = new DataAccess();
                    db.DeleteAnswer(answer.Id);
                    ShowSuccess(AnswersErrorMessage, AnswersErrorSeparator, "AnswerDeletedSuccess");
                   
                }
                catch (Exception ex)
                {
                    ShowError(ex, AnswersErrorMessage, AnswersErrorSeparator);
                }
            }
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem != null)
            {
                try
                {
                    var question = QuestionsDataGrid.SelectedItem as Questions;
                    DataAccess db = new DataAccess();
                    db.DeleteQuestion(question.Id);
                    ShowSuccess(QuestionsErrorMessage, QuestionsErrorSeparator, "QuestionDeletedSuccess");

                }
                catch (Exception ex)
                {
                    ShowError(ex, QuestionsErrorMessage, QuestionsErrorSeparator);
                }
            }
        }

        private void UpdateQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem != null)
            {
                try
                {

                    var question = QuestionsDataGrid.SelectedItem as Questions;
                    DataAccess db = new DataAccess();
                    db.UpdateQuestion(question.Id, question.Question, question.RoleId, question.TypeOfQuestionId);
                    ShowSuccess(QuestionsErrorMessage, QuestionsErrorSeparator, "UpdateQuestionSuccess");
                }
                catch (Exception ex)
                {
                    ShowError(ex, QuestionsErrorMessage, QuestionsErrorSeparator);
                }
            }
        }

        private void AddRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();
                db.CreateRole(RoleName.Text);
                ShowSuccess(RolesErrorMessage, RolesErrorSeparator, "RoleAddSuccess");
            }
            catch (ArgumentNullException)
            {
                ShowArgumentNullError("RoleNameAreNotFilled", RolesErrorMessage, RolesErrorSeparator);
               //"Поле Role не было заполнено";
            }
            catch (Exception ex)
            {
                ShowError(ex, RolesErrorMessage, RolesErrorSeparator);
            }
        }

        private void DeleteRole_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem != null)
            {
                try
                {
                    var role = RolesDataGrid.SelectedItem as Role;
                    DataAccess db = new DataAccess();
                    db.DeleteRole(role.Id);
                    ShowSuccess(RolesErrorMessage, RolesErrorSeparator, "RoleDeletedSuccess");

                }
                catch (Exception ex)
                {
                    ShowError(ex, RolesErrorMessage, RolesErrorSeparator);
                }
            }
        }

        private void UpdateRole_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem != null)
            {
                try
                {

                    var role = RolesDataGrid.SelectedItem as Role;
                    DataAccess db = new DataAccess();
                    db.UpdateRole(role.Id, role.RoleName);
                    ShowSuccess(RolesErrorMessage, RolesErrorSeparator, "UpdateRoleSuccess");
                }
                catch (Exception ex)
                {
                    ShowError(ex, RolesErrorMessage, RolesErrorSeparator);
                }
            }
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();
                db.CreateType(TypeName.Text);
                ShowSuccess(TypesErrorMessage, TypesErrorSeparator, "TypeAddSuccess");
            }
            catch (ArgumentNullException)
            {
                ShowArgumentNullError("TypeAreNotFilled", TypesErrorMessage, TypesErrorSeparator);
               //Поле Type не было заполнено";
            }
            catch (Exception ex)
            {
                ShowError(ex, TypesErrorMessage, TypesErrorSeparator);
            }
        }

        private void DeleteType_Click(object sender, RoutedEventArgs e)
        {
            if (TypesDataGrid.SelectedItem != null)
            {
                try
                {
                    var type = TypesDataGrid.SelectedItem as TypesOfQuestion;
                    DataAccess db = new DataAccess();
                    db.DeleteType(type.Id);
                    ShowSuccess(TypesErrorMessage, TypesErrorSeparator, "TypeDeletedSuccess");

                }
                catch (Exception ex)
                {
                    ShowError(ex, TypesErrorMessage, TypesErrorSeparator);
                }
            }
        }

        private void UpdateType_Click(object sender, RoutedEventArgs e)
        {
            if (TypesDataGrid.SelectedItem != null)
            {
                try
                {

                    var type = TypesDataGrid.SelectedItem as TypesOfQuestion;
                    DataAccess db = new DataAccess();
                    db.UpdateType(type.Id, type.Type);
                    ShowSuccess(TypesErrorMessage, TypesErrorSeparator, "UpdateTypeSuccess");
                }
                catch (Exception ex)
                {
                    ShowError(ex, TypesErrorMessage, TypesErrorSeparator);
                }
            }
        }
    }
}
