using SecurityTestsUI.Helpers;
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

namespace SecurityTestsUI
{
    /// <summary>
    /// Логика взаимодействия для Tests.xaml
    /// </summary>
    public partial class TestsView : UserControl
    {
        private User _currentUser;
        private List<Questions> _allQuestions;
        private List<Questions> _usedQuestions;
        private List<Answers> _answersToQuestion;
        private List<Answers> _usedAnswers;
        private List<Answers> _correctAnswers;
        private List<Answers> _allCorrectAnswers;
        private List<Answers> _userUsedAnswers;
        private int _currentTypeOfQuestion;

        private CultureInfo _currentCulture;

        private ResourceManager resourseManager = new ResourceManager("SecurityTestsUI.Languages.Messages", typeof(MainView).Assembly);

        public Questions CurrentQuestion { get; set; }

        public static readonly DependencyProperty QuestionContentProperty =
        DependencyProperty.Register("QuestionContent", typeof(Questions), typeof(UserControl), new PropertyMetadata(null));

        public Questions QuestionContent
        { 
            get { return (Questions)GetValue(QuestionContentProperty); }
            set { SetValue(QuestionContentProperty, value); }
        }

        public static readonly DependencyProperty Answer1Property =
       DependencyProperty.Register("CurrentAnswer1", typeof(Answers), typeof(UserControl), new PropertyMetadata(null));

        public Answers CurrentAnswer1
        {
            get { return (Answers)GetValue(Answer1Property); }
            set { SetValue(Answer1Property, value); }
        }

        public static readonly DependencyProperty Answer2Property =
       DependencyProperty.Register("CurrentAnswer2", typeof(Answers), typeof(UserControl), new PropertyMetadata(null));

        public Answers CurrentAnswer2
        {
            get { return (Answers)GetValue(Answer2Property); }
            set { SetValue(Answer2Property, value); }
        }
        public static readonly DependencyProperty Answer3Property =
       DependencyProperty.Register("CurrentAnswer3", typeof(Answers), typeof(UserControl), new PropertyMetadata(null));

        public Answers CurrentAnswer3
        {
            get { return (Answers)GetValue(Answer3Property); }
            set { SetValue(Answer3Property, value); }
        }
        public static readonly DependencyProperty Answer4Property =
       DependencyProperty.Register("CurrentAnswer4", typeof(Answers), typeof(UserControl), new PropertyMetadata(null));

        public Answers CurrentAnswer4
        {
            get { return (Answers)GetValue(Answer4Property); }
            set { SetValue(Answer4Property, value); }
        }

        public TestsView()
        {
            InitializeComponent();
        }

        public TestsView(User user, CultureInfo culture)
        {
            InitializeComponent();

            _currentUser = user;

            _currentCulture = culture;

            _usedQuestions = new List<Questions>();
            _allQuestions = new List<Questions>();
            _answersToQuestion = new List<Answers>();
            _usedAnswers = new List<Answers>();
            _correctAnswers = new List<Answers>();
            _allCorrectAnswers = new List<Answers>();
            _userUsedAnswers = new List<Answers>();

            FillAllFields(_currentCulture);

            CanUserTryTests();

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


        private void InitializeQuestions(int typeQuestions)
        {
            DataAccess db = new DataAccess();

            var rnd = new Random();

            try
            {
                //загружаем ответы исходя из роли пользователя

                _allQuestions = db.LoadQuestionsByRole(_currentUser, typeQuestions);

                FillQuestionAndAnswerAreas(db, rnd);

                SwitchShowedNumbersOfQuestions();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            
        }

        private void SwitchShowedNumbersOfQuestions()
        {
            NumberOfQuestion.Content = _usedQuestions.Count;
            QuestionsCount.Content = _allQuestions.Count;
        }

        private void CanUserTryTests()
        {
            DataAccess db = new DataAccess();
            if (db.CanTryTestByFireSafety(_currentUser))
            {
                FireSafetyTestButton.IsEnabled = true;
            }
            else
            {
                FireSafetyTestButton.IsEnabled = false;
            }
            if (db.CanTryTestByIndustrialSafety(_currentUser))
            {
                IndustrialSafetyTestButton.IsEnabled = true;
            }
            else
            {
                IndustrialSafetyTestButton.IsEnabled = false;
            }


        }

        private void FillQuestionAndAnswerAreas(DataAccess db, Random rnd)
        {
            if(_usedQuestions.Count == _allQuestions.Count)
            {
                throw new QuestionsAreEndedException();
            }

            //Очищаем ответы к вопросу и использованные ответы
            _answersToQuestion.Clear();

            _usedAnswers.Clear();

            while (_usedQuestions.Count != _allQuestions.Count)
            {
                //Выбираем один из вопросов рандомом
                var newQuestion = _allQuestions[rnd.Next(0, _allQuestions.Count)];

                //Проверяем не содержится ли он в использованных вопросах
                if (!_usedQuestions.Contains(newQuestion))
                {
                    //добавляем новый вопрос в использованные
                    _usedQuestions.Add(newQuestion);

                    //Заполняем поле вопроса
                    QuestionContent = newQuestion;

                    //Загружаем ответы к текущему вопросу
                    _answersToQuestion = db.LoadAnswersForQuestion(newQuestion);

                    //Заполняем поля ответов
                    CheckAnswer(1, rnd);
                    CheckAnswer(2, rnd);
                    CheckAnswer(3, rnd);
                    CheckAnswer(4, rnd);

                    break;
                }
            }
        }

        private void CheckAnswer(int numberOfAnswer, Random rnd)
        {
            while (true)
            {
                var answer = _answersToQuestion[rnd.Next(0, 4)];

                if (!_usedAnswers.Contains(answer))
                {
                    _usedAnswers.Add(answer);

                    if(answer.IsCorrect == true)
                    {
                        _allCorrectAnswers.Add(answer);
                    }

                    switch (numberOfAnswer)
                    {
                        case 1:
                            CurrentAnswer1 = answer;
                            break;
                        case 2:
                            CurrentAnswer2 = answer;
                            break;
                        case 3:
                            CurrentAnswer3 = answer;
                            break;
                        case 4:
                            CurrentAnswer4 = answer;
                            break;
                    }

                    break;
                }
            }
            
        }

        private void FirstType_Click(object sender, RoutedEventArgs e)
        {
            InitializeByType(1);
        }

        private void InitializeByType(int typeNumber)
        {
            _currentTypeOfQuestion = typeNumber;
            InitializeQuestions(_currentTypeOfQuestion);
            HideTypesOfQuestionButtons();
        }

        private void SecondType_Click(object sender, RoutedEventArgs e)
        {
            InitializeByType(2);
        }

        private void HideTypesOfQuestionButtons()
        {
            TypesOfQuestionButtons.Visibility = Visibility.Hidden;
            TestArea.Visibility = Visibility.Visible;
            NumberOfQuestions.Visibility = Visibility.Visible;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckCorrectAnswers();

                DataAccess db = new DataAccess();

                var rnd = new Random();


                FillQuestionAndAnswerAreas(db, rnd);

                SwitchShowedNumbersOfQuestions();

                OffCheckBoxes();

            }
            catch (QuestionsAreEndedException)
            {
                CalculationResults();

                ResultsAreaShow();


            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Истекло"))
                {
                    Console.WriteLine(resourseManager.GetString("LongTime", _currentCulture));
                }
                Console.WriteLine(ex.Message);

            }
        }

        private void OffCheckBoxes()
        {
            FirstAnswerCheckBox.IsChecked = false;
            SecondAnswerCheckBox.IsChecked = false;
            ThirdAnswerCheckBox.IsChecked = false;
            FourthAnswerCheckBox.IsChecked = false;
        }

        private void CalculationResults()
        {
            AllQuestoinsResultsArea.Text = _allQuestions.Count.ToString();

            CorrectAnswersResultsArea.Text = _correctAnswers.Count.ToString();

            var percent = ((double)_correctAnswers.Count / _userUsedAnswers.Count) * 100.0;

            CorrectAnswersPercentsResultsArea.Text = (Math.Round(percent,2)).ToString() + "%";
            DataAccess db = new DataAccess();

            

            switch (_currentTypeOfQuestion)
            {
                case 1:
                    db.UserTryFireSafetyTest(_currentUser);
                    if (percent < 85)
                    {
                        VereficationStatusByFireSafetyResultsArea.Text = resourseManager.GetString("NonVereficated", _currentCulture); ;
                        VereficationStatusByFireSafetyResultsArea.Foreground = Brushes.Red;
                    }
                    else
                    {
                        db.VereficateUserByFireSafety(_currentUser);

                        VereficationStatusByFireSafetyResultsArea.Text = resourseManager.GetString("Vereficated", _currentCulture); ;
                        VereficationStatusByFireSafetyResultsArea.Foreground = Brushes.LimeGreen;
                    }
                    break;

                case 2:

                    if (percent < 85)
                    {
                        VereficationStatusByIndustrialSafetyResultsArea.Text = resourseManager.GetString("NonVereficated", _currentCulture); ;
                        VereficationStatusByIndustrialSafetyResultsArea.Foreground = Brushes.Red;
                    }
                    else
                    {
                        db.VereficateUserByindustrialSafety(_currentUser);

                        VereficationStatusByIndustrialSafetyResultsArea.Text = resourseManager.GetString("Vereficated", _currentCulture); ;
                        VereficationStatusByIndustrialSafetyResultsArea.Foreground = Brushes.LimeGreen;
                    }
                    break;

            }
        }
        private void ResultsAreaShow()
        {
            TestArea.Visibility = Visibility.Hidden;
            NumberOfQuestions.Visibility = Visibility.Hidden;
            ResultsArea.Visibility = Visibility.Visible;

            switch (_currentTypeOfQuestion)
            {
                case 1:
                    VereficationStatusByFireSafetyArea.Visibility = Visibility.Visible;
                    VereficationStatusByIndustrialSafetyArea.Visibility = Visibility.Hidden;
                    break;

                case 2:
                    VereficationStatusByFireSafetyArea.Visibility = Visibility.Hidden;
                    VereficationStatusByIndustrialSafetyArea.Visibility = Visibility.Visible;
                    break;

            }
            
        }
        private void AnswerCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            NextButtonIsEnabledChange();
        }

        private void CheckCorrectAnswers()
        {
            if (FirstAnswerCheckBox.IsChecked == true)
            {
                _userUsedAnswers.Add(CurrentAnswer1);

                if(CurrentAnswer1.IsCorrect)
                {
                    _correctAnswers.Add(CurrentAnswer1);
                }
            }

            if (SecondAnswerCheckBox.IsChecked == true)
            {

                _userUsedAnswers.Add(CurrentAnswer2);

                if (CurrentAnswer2.IsCorrect)
                {
                    _correctAnswers.Add(CurrentAnswer2);
                }
            }

            if (ThirdAnswerCheckBox.IsChecked == true)
            {

                _userUsedAnswers.Add(CurrentAnswer3);

                if (CurrentAnswer3.IsCorrect)
                {
                    _correctAnswers.Add(CurrentAnswer3);
                }
            }

            if (FourthAnswerCheckBox.IsChecked == true)
            {
                _userUsedAnswers.Add(CurrentAnswer4);

                if (CurrentAnswer4.IsCorrect)
                {
                    _correctAnswers.Add(CurrentAnswer4);
                }
            }
        }

        private void NextButtonIsEnabledChange()
        {
            if(FirstAnswerCheckBox.IsChecked == true || SecondAnswerCheckBox.IsChecked == true || ThirdAnswerCheckBox.IsChecked == true || FourthAnswerCheckBox.IsChecked == true)
            {
                NextButton.IsEnabled = true;
            }
            else
            {
                NextButton.IsEnabled = false;
            }
        }
        private void FillAllFields(CultureInfo culture)
        {

            FireSafetyTestButton.Content = resourseManager.GetString("FireSafetyTestButton", culture);
            IndustrialSafetyTestButton.Content = resourseManager.GetString("IndustrialSafetyTestButton", culture);

            OutOfLabel.Content = resourseManager.GetString("OutOf", culture);
            NextButtonText.Text = resourseManager.GetString("NextButtonText", culture);

            TestResultsLabel.Text = resourseManager.GetString("TestResultsLabel", culture);
            AllQuestoinsLabel.Text = resourseManager.GetString("AllQuestoinsLabel", culture);

            CorrectAnswersLabel.Text = resourseManager.GetString("CorrectAnswersLabel", culture);
            CorrectAnswersPercentsLabel.Text = resourseManager.GetString("CorrectAnswersPercentsLabel", culture);

            VereficationStatusByFireSafetyResultsAreaLabel.Text = resourseManager.GetString("VereficationStatusByFireSafety", culture);
            VereficationStatusByIndustrialSafetyResultsAreaLabel.Text = resourseManager.GetString("VereficationStatusByIndustrialSafety", culture);

        }
    }
}
