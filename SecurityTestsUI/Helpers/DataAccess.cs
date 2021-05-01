using SecurityTestsUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SecurityTestsUI
{
    public class DataAccess
    {

        public User GetUser(string userName, string userPassword)
        {
            if (userName == "" || userPassword == "")
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                
                var output = db.Query<User>($"select * from Users where UserName = N'{userName}' and UserPassword = N'{userPassword}'").First();
                return output;
            }
        }

        public void DeleteUser(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Delete From Users where Id = {id}";
                db.Execute(sqlQuery);
            }
        }
        public void DeleteRole(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Delete From Roles where Id = {id}";
                db.Execute(sqlQuery);
            }
        }
        public void DeleteType(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Delete From TypesOfQuestion where Id = {id}";
                db.Execute(sqlQuery);
            }
        }
        public void DeleteQuestion(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Delete From Questions where Id = {id}";
                db.Execute(sqlQuery);
            }
        }
        public void DeleteAnswer(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Delete From Answers where Id = {id}";
                db.Execute(sqlQuery);
            }
        }
        public List<User> GetUsers()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {

                var output = db.Query<User>($"select * from Users").ToList();
                return output;
            }
        }
        public User GetUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {

                var output = db.Query<User>($"select * from Users where Id = {id}").First();
                return output;
            }
        }

        public void CreateUser(string userName, string userPassword, int roleId, string name, string emailAddress, DateTime birthday)
        {
            if (userName == "" || userPassword == "" || roleId == 0 || name == "" || emailAddress == "" || birthday == null)
            {
                throw new ArgumentNullException();
            }
            string format = "dd-MM-yyyy";
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                db.Query($"Insert into Users(UserName,UserPassword, RoleId, VereficationStatusByFireSafety, VereficationStatusByIndustrialSafety, Name, EmailAddress, Birthday,CounterOfUsedTries, DateTimeOfLastTryByFireSafety, DateTimeOfLastTryByIndustrialSafety) values (N'{userName}',N'{userPassword}', {roleId}, 0, 0, N'{name}', N'{emailAddress}', '{birthday.ToString(format)}',0,null,null)");
            }
        }
        public void CreateUser(string userName, string userPassword, int roleId, string name, string emailAddress, DateTime birthday, bool? VereficationStatusByFireSafety, bool? VereficationStatusByIndustrialSafety , int counterOfUsedTries)
        {
            if (userName == "" || userPassword == "" || roleId == 0 || name == "" || emailAddress == "" || birthday == null || VereficationStatusByFireSafety == null || VereficationStatusByIndustrialSafety == null || counterOfUsedTries < 0)
            {
                throw new ArgumentNullException();
            }
            var st1 = VereficationStatusByFireSafety == true ? 1 : 0;
        
            var st2 = VereficationStatusByIndustrialSafety == true ? 1 : 0;

            string format = "dd-MM-yyyy";

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                db.Query($"Insert into Users(UserName,UserPassword, RoleId, VereficationStatusByFireSafety, VereficationStatusByIndustrialSafety, Name, EmailAddress, Birthday, CounterOfUsedTries, DateTimeOfLastTryByFireSafety, DateTimeOfLastTryByIndustrialSafety) values (N'{userName}',N'{userPassword}', {roleId}, {st1}, {st2}, N'{name}', N'{emailAddress}', '{birthday.ToString(format)}', {counterOfUsedTries}, null,null)");
            }
        }
        public void UpdateRole(int roleId, string RoleName)
        {
            if (roleId == 0 || string.IsNullOrEmpty(RoleName))
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Update Roles Set RoleName = N'{RoleName}' where Id = {roleId}";
                db.Execute(sqlQuery);
            }
        }
        public void UpdateType(int typeId, string type)
        {
            if (typeId == 0 || string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Update TypesOfQuestion Type = N'{type}' where Id = {typeId}";
                db.Execute(sqlQuery);
            }
        }
        public void UpdateQuestion(int questionId, string question, int roleId, int typeId)
        {
            if (typeId == 0 || string.IsNullOrEmpty(question) || roleId == 0 || questionId == 0 )
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Update Questions Set Question = N'{question}', RoleId = {roleId}, TypeOfQuestionId={typeId} where Id = {questionId}";
                db.Execute(sqlQuery);
            }
        }
        public void UpdateAnswer(int answerId, string asnwer, bool isCorrect, int questionId)
        {
            if (answerId == 0 || string.IsNullOrEmpty(asnwer) || questionId == 0)
            {
                throw new ArgumentNullException();
            }
            var st1 = isCorrect == true ? 1 : 0;

            
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Update Answers Set Answer = N'{asnwer}', QuestionId = {questionId}, IsCorrect={st1} where Id = {answerId}";
                db.Execute(sqlQuery);
            }
        }
        public void UpdateUser(int userId, string userName, string userPassword, int roleId, string name, string emailAddress, DateTime birthday)
        {
            if (userName == "" || userPassword == "" || roleId == 0 || name == "" || emailAddress == "" || birthday == null)
            {
                throw new ArgumentNullException();
            }
            string format = "dd-MM-yyyy";
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var sqlQuery = $"Update Users Set UserName = N'{userName}',UserPassword = N'{userPassword}', RoleId = {roleId}, Name = N'{name}', EmailAddress = N'{emailAddress}', Birthday = '{birthday.ToString(format)}' where Id = {userId}";
                db.Execute(sqlQuery);
            }
        }
        public void UpdateUser(int userId, string userName, string userPassword, int roleId, string name, string emailAddress, DateTime birthday, bool VereficationStatusByFireSafety, bool VereficationStatusByIndustrialSafety, int counterOfUsedTries, DateTime DateTimeOfLastTryByFireSafety, DateTime DateTimeOfLastTryByIndustrialSafety)
        {
            if (userName == "" || userPassword == "" || roleId == 0 || name == "" || emailAddress == "" || birthday == null)
            {
                throw new ArgumentNullException();
            }
            var date1 = "";

            var date2 = "";


            string formatDateTime = "dd-MM-yyyy hh:mm:ss";

            var sqlQuery = "";

            if (DateTimeOfLastTryByFireSafety.ToString().StartsWith("01.01.0001"))
            {
                date1 = "null";
            }
            else
            {
                date1 = $"'{DateTimeOfLastTryByFireSafety.ToString(formatDateTime)}'";
            }
            if (DateTimeOfLastTryByIndustrialSafety.ToString().StartsWith("01.01.0001"))
            {
                date2 = "null";
            }
            else
            {
                date2 = $"'{DateTimeOfLastTryByIndustrialSafety.ToString(formatDateTime)}'";
            }
            var st1 = VereficationStatusByFireSafety == true ? 1 : 0;

            var st2 = VereficationStatusByIndustrialSafety == true ? 1 : 0;

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                 sqlQuery = $"Update Users Set UserName = N'{userName}',UserPassword = N'{userPassword}', RoleId = {roleId}, Name = N'{name}', EmailAddress = N'{emailAddress}', Birthday = '{birthday.ToString(formatDateTime)}'," +
                    $"VereficationStatusByFireSafety = {st1},VereficationStatusByIndustrialSafety = {st2}, CounterOfUsedTries = {counterOfUsedTries}, DateTimeOfLastTryByFireSafety ={date1}, DateTimeOfLastTryByIndustrialSafety ={date2} where Id = {userId}";
                db.Execute(sqlQuery);
            }
        }
        public List<Role> GetRoles()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<Role>($"select * from Roles").ToList();
                return output;
            }
        }
        public List<TypesOfQuestion> GetTypes()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<TypesOfQuestion>($"select * from TypesOfQuestion").ToList();
                return output;
            }
        }
        public List<Answers> GetAnswers()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<Answers>($"select * from Answers").ToList();
                return output;
            }
        }
        public List<Questions> GetQuestions()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<Questions>($"select * from Questions").ToList();
                return output;
            }
        }
        public List<Role> LoadRoles()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var admin = db.Query<User>($"select * from Users Join Roles On(Users.RoleId = Roles.Id) where RoleName = 'admin'").First();
                var output = new List<Role>();
                if (admin.Equals(null) || admin == null)
                {
                    output = db.Query<Role>($"select * from Roles").ToList();
                }
                else
                {
                    output = db.Query<Role>($"select * from Roles where RoleName <> 'admin'").ToList();
                }
               
                return output;
            }
        }

        public bool IsAdmin(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<string>($"select RoleName from Users Join Roles On(Users.RoleId = Roles.Id) where Users.Id = {user.Id}").First();
                return output=="admin";
            }
        }

        public List<TypesOfQuestion> LoadTypesOfQuestion()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<TypesOfQuestion>($"select * from TypesOfQuestion").ToList();
                return output;
            }
        }

        public List<Questions> LoadQuestionsByRole(User user, int typeOfQuestion)
        {
            if (user == null || typeOfQuestion == 0)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<Questions>($"select * from Questions where RoleId = {user.RoleId} And TypeOfQuestionId = {typeOfQuestion}").ToList();
                return output;
            }
        }

        public List<Answers> LoadAnswersForQuestion(Questions question)
        {
            if (question == null)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<Answers>($"select * from Answers where QuestionId = {question.Id}").ToList();
                return output;
            }
        }

        public void VereficateUserByFireSafety(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            if (user.VereficationStatusByFireSafety == false)
            {
                using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
                {
                    var sqlQuery = $"Update Users Set VereficationStatusByFireSafety = 1 where Id = {user.Id}";
                    db.Execute(sqlQuery);
                }
            }
        }

        public void VereficateUserByindustrialSafety(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            if (user.VereficationStatusByIndustrialSafety == false)
            {
                using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
                {
                    var sqlQuery = $"Update Users Set VereficationStatusByIndustrialSafety = 1 where Id = {user.Id}";
                    db.Execute(sqlQuery);
                }
            }
        }

        public void CreateQuestion(string question, int typeOfQuestionId, int roleId)
        {
            if (question == "" || roleId == 0 || typeOfQuestionId == 0)
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                db.Query($"Insert into Questions(Question,TypeOfQuestionId, RoleId) values (N'{question}',{typeOfQuestionId}, {roleId})");
            }
        }

        public int GetQuestionId(string question)
        {
            if (question == "")
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<int>($"select Id from Questions where Question = N'{question}'").First();
                return output;
            }
        }

        public void CreateAnswer(string answer, bool isCorrect, int questionId)
        {
            if (answer == "" || questionId == 0 )
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                db.Query($"Insert into Answers(Answer,IsCorrect, QuestionId) values (N'{answer}',{isCorrect}, {questionId})");
            }
        }
        public void CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                db.Query($"Insert into Roles(RoleName) values (N'{roleName}')");
            }
        }
        public void CreateType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException();
            }

            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                db.Query($"Insert into TypesOfQuestion(Type) values (N'{type}')");
            }
        }
        //public int GetCounterOfUsersTries(string RoleId)
        //{
        //    using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
        //    {
        //        var output = db.Query<int>($"Select Count(Select * From Users where RoleId={RoleId} and ) from Users ");
        //    }
        //}
        public void UserTryFireSafetyTest(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                DateTime time = DateTime.Now;
                string format = "dd-MM-yyyy hh:mm:ss";
                var sqlQuery = $"Update Users Set CounterOfUsedTries = {user.CounterOfUsedTries+1},DateTimeOfLastTryByFireSafety='{ time.ToString(format) }'  where Id = {user.Id}";
                db.Execute(sqlQuery);
            }
        }
        public void UserTryIndustrialSafetyTest(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                DateTime time = DateTime.Now;
                string format = "dd-MM-yyyy hh:mm:ss";
                var sqlQuery = $"Update Users Set CounterOfUsedTries = {user.CounterOfUsedTries + 1}, DateTimeOfLastTryByIndustrialSafety ='{time.ToString(format)}'  where Id = {user.Id}";
                db.Execute(sqlQuery);
            }
        }
        public bool CanTryTestByFireSafety(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<DateTime?>($"Select DateTimeOfLastTryByFireSafety from Users where Id = {user.Id}").First();
                if(output == null || output.ToString().StartsWith("01.01.0001"))
                {
                    return true;
                }
                var date = DateTime.UtcNow.AddDays(-1);
                var result = DateTime.Compare(date, DateTime.Parse(output.ToString()));
                return  result >= 0;
            }
        }
        public bool CanTryTestByIndustrialSafety(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                var output = db.Query<DateTime?>($"Select DateTimeOfLastTryByIndustrialSafety from Users where Id = {user.Id}").First();
                if (output == null || output.ToString().StartsWith("01.01.0001"))
                {
                    return true;
                }
                var date = DateTime.UtcNow.AddDays(-1);
                var result = DateTime.Compare(date, DateTime.Parse(output.ToString()));
                return result >= 0;
            }
        }

        public List<User> GetAllManagers(DateTime from, DateTime To)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                string format = "dd-MM-yyyy hh:mm:ss";
                var output = db.Query<User>($"set dateformat dmy " +
                                        $"exec GetAllManagers '{from.ToString(format)}','{To.ToString(format)}'").ToList();
                
                return output;
            }
        }

        public List<User> GetAllEmployees(DateTime from, DateTime To)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(DataBaseHelper.Connection("SecurityTestsDB")))
            {
                string format = "dd-MM-yyyy hh:mm:ss";
                var output = db.Query<User>($"set dateformat dmy " +
                                        $"exec GetAllEmployees '{from.ToString(format)}','{To.ToString(format)}'").ToList();

                return output;
            }
        }

    }
}
