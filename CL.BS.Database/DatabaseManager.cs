
using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace CL.BS.Database
{ 
    public class DatabaseManager
    {
        private const int _ApplicationVersion = 1234567890;
        private const int _Institution = 1234567;
        private const int _Class = 12345;
        private const string _SystemSoftware = "He";
        public static DatabaseManager Inline = new DatabaseManager();
        private User[] _users = new User[5];
        private List<User> UsersList = new List<User>();
        private List<Exercise> _activity = new List<Exercise>();
        private bool _isStudentsIn = false;
        private const string FileUserName = @"C:\bs\User.xls";
        private const string FileActivity = @"C:\bs\Activity.xls";

        private DatabaseManager()
        {
            new Thread(new ThreadStart(() =>
            {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            for (int i = 0; i < _users.Length; i++)
                _users[i] = new User();
            if (File.Exists(FileUserName)) {
                var fill = ExcelFile.Load(FileUserName);
                ExcelWorksheetCollection ef = fill.Worksheets;
                for (int i = 1; i < ef[0].Rows.Count; i++)
                {

                    if (ef[0].Columns[0].Cells[i].Value == null)
                        continue;
                    if (ef[0].Columns[3].Cells[i].Value.ToString() == "0")
                        continue;
                    User user = new User()
                    {
                        UserType =  ef[0].Columns[1].Cells[i].Value.ToString(),
                        _User =ef[0].Columns[0].Cells[i].Value.ToString(),
                        Gender = ef[0].Columns[2].Cells[i].Value.ToString() == "0",
                        Teacher = ef[0].Columns[3].Cells[i].Value.ToString(),
                        Birthday = DateTime.Now.AddYears(-4),//.Parse(ef[0].Columns[4].Cells[i].Value.ToString()),
                        Limitations = ef[0].Columns[4].Cells[i].Value.ToString(),
                        Voice = @"C:\bs\Voice\" + ef[0].Columns[5].Cells[i].Value.ToString(),
                        Image = @"C:\bs\Pic\" + ef[0].Columns[6].Cells[i].Value.ToString(),
                        Name = ef[0].Columns[8].Cells[i].Value.ToString()
                    };
                    UsersList.Add(user);
                } 
            }
            else
                UsersList = new List<User>();
            if (File.Exists(FileActivity))
            {
                //streamReader = new StreamReader(FileActivity, System.Text.Encoding.UTF8);
                ExcelWorksheetCollection ef = ExcelFile.Load(FileActivity).Worksheets;
                for (int i = 1; i < ef[0].Rows.Count; i++)
                {
                    if (ef[0].Columns[0].Cells[i].Value == null)
                        continue;

                    _activity.Add(new Exercise
                    {
                        ApplicationVersion = int.Parse(ef[0].Columns[0].Cells[i].Value.ToString()),
                        TableID = ef[0].Columns[1].Cells[i].Value.ToString(),
                        scoolID = int.Parse(ef[0].Columns[2].Cells[i].Value.ToString()),
                        Class = int.Parse(ef[0].Columns[3].Cells[i].Value.ToString()),
                        // Usear = ef[0].Columns[4].Cells[i].Value.ToString(),
                        Edge = ef[0].Columns[5].Cells[i].Value.ToString()[0],
                        StartTime = DateTime.Parse(ef[0].Columns[6].Cells[i].Value.ToString()),
                        EndTime = DateTime.Parse(ef[0].Columns[7].Cells[i].Value.ToString()),
                        Type = ef[0].Columns[8].Cells[i].Value.ToString(),
                        Activity = ef[0].Columns[9].Cells[i].Value.ToString(),
                        Task = ef[0].Columns[10].Cells[i].Value.ToString(),
                        SubTask = ef[0].Columns[11].Cells[i].Value.ToString(),
                        Success = ef[0].Columns[12].Cells[i].Value.ToString()[0]
                    });
                }
            }
            WebConect();
            })).Start();
        }

        private void WebConect()
        {//C:\Brain_Station\WinFormsAppDataBase\WinFormsAppDataBase\bin\Debug\net6.0-windows\Nancy.dll
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("users");
            var connectionString = "Host=brainyz.c7e6ckoseogt.eu-north-1.rds.amazonaws.com;Username=dovrotshtain;Password=ZeAfb6MOQeAD9tMDynbr;Database=brainyz;";

            var dataSource = Npgsql.NpgsqlDataSource.Create(connectionString);

            string t = string.Empty;
            int i = 0;                                                                                                                           //cmd.ExecuteNonQuery();
            try
            {

                using (var cmd = dataSource.CreateCommand("SELECT * FROM \"public\".\"users\" LIMIT 1000"))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(8).ToString() == "0")
                        {
                            i++;
                            break;
                        }

                        for (int j = 0; j < 12; j++)
                            worksheet.Rows[i].Cells[j].Value = reader.GetValue(j).ToString();
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                if(UsersList==null)
                    UsersList = new List<User>();
                return;
            }
            workbook.Save(FileUserName);
        }

        public void SaveLesson(int classCode)
        {
        }
        public void SetUsers(int usearIndex,int edgeIndex)
        {
            _isStudentsIn = true;
            if (edgeIndex < UsersList.Count<User>())
                _users[usearIndex] = UsersList[edgeIndex];
        }
        public  void SaveActivity(int usearIndex,DateTime startTime, DateTime endTime, string type, 
            string activity, string task1, string task2, int success)
        {
            if (!_isStudentsIn) 
                return;
            if(usearIndex!=4)
                if(_users[usearIndex]._User==null)
                    return;
            new Thread(new ThreadStart(() =>
            {
               type = type.Remove(type.Length - 2, 2);
            _activity.Add(new Exercise
            {
                ApplicationVersion = _ApplicationVersion,
                TableID = _SystemSoftware,
                scoolID = _Institution,
                Class = _Class,
                User = _users[usearIndex]._User,
                Edge = "ABCDE"[usearIndex],
                StartTime = startTime,
                EndTime = endTime,
                Type = type,
                Activity = activity,
                Task = task1,
                SubTask = task2,
                Success = success
            });
            var connectionString = "Host=brainyz.c7e6ckoseogt.eu-north-1.rds.amazonaws.com;Username=dovrotshtain;Password=ZeAfb6MOQeAD9tMDynbr;Database=brainyz;";

            var dataSource = Npgsql.NpgsqlDataSource.Create(connectionString); 
            string comand = String.Format(
 "INSERT INTO activity_log (TableID, user_id, Edge, StartTime, EndTime, Type, Activity, Task, SubTask, Success)" + 
 " VALUES ('{0}','{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}') ;"
, _Institution, usearIndex==4?"46": _users[usearIndex]._User, "ABCDE"[usearIndex],TimeFormat( startTime),TimeFormat( endTime), type, activity,task1, task2, success);
            using (var cmd = dataSource.CreateCommand(comand)) //activity_id, "insert into public.schools (name, style, country) values('תימן', '777', 'שדה')")
            {
                cmd.ExecuteReader();//\"activity_id\",DateTime.Now.Millisecond,
            }
            })).Start();
        }

        private object TimeFormat(DateTime time)
        {//.ToString().Replace('/','-')
            string t = time.ToString();
            string[] ct = t.Split(' ');
            string[] y = ct[0].Split('/'); 
            return string.Format("{0}-{1}-{2} {3}",y[2],y[1],y[0], ct[1]);
        }

        public  void SaveGame(DateTime startTime, DateTime endTime, string type, string activity, string task1, string task2)
        {
            if (!_isStudentsIn)
                return;
            _activity.Add(new Exercise
            {
                ApplicationVersion = _ApplicationVersion,
                TableID = _SystemSoftware,
               // Institution = _Institution,
                Class = _Class,
                User = "0",
                Edge = 'E',
                StartTime = startTime,
                EndTime = endTime,
                Type = type,
                Activity = activity,
                Task = task1,
                SubTask = task2,
                Success = 'N'
            });
        }
    
        public List<User> GetAllUser()
        {
            return UsersList;
        }
        public void Save()
        {
            /*INSERT INTO "public"."activity_log" ("tableid", "user_id", "edge", "starttime", "endtime", "type", "activity", "task", "subtask", "success") VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?);*/
        }
        private int GetUniqueLessonCode()
        {
          return 0;
        }
        public void AddExercise(DateTime startTime,int studentCode,bool isCorrectAnswer)
        {
        }
    }
}
