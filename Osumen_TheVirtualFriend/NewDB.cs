using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Storage;

namespace Osumen_TheVirtualFriend
{
    class NewDB : ReminderUISec2
    {

        private static SqliteConnection con;
        public NewDB()
        {
            initializeDB();
        }
        public async static void initializeDB()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("taskData2.db", CreationCollisionOption.OpenIfExists);
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "taskData2.db");


            using (con = new SqliteConnection($"Filename={pathToDB}"))
            {
                con.Open();
                string initCMD =
                    "CREATE TABLE IF NOT EXISTS " +
                    "task2(TaskName VARCHAR(1000) PRIMARY KEY," +
                         "TaskDate TEXT NOT NULL," +
                         "TaskTime TEXT NOT NULL," +
                         "Taskpriority VARCHAR(100) NOT NULL)";

                SqliteCommand CMDcreateTable = new SqliteCommand(initCMD, con);
                CMDcreateTable.ExecuteReader();
            }

        }



        public static void addRecord(String Name, String Date, String Time, String Priority)
        {

            if (!(Name == null && Date == null && Time == null && Priority == null))
            {
              
                using (con)
                {
                    try
                    {
                        con.Open();
                        SqliteCommand CMD_Insert = new SqliteCommand();
                        CMD_Insert.Connection = con;

                        

                        CMD_Insert.CommandText = "INSERT INTO task2(TaskName,TaskDate,TaskTime,Taskpriority) VALUES('" + Name + "', '" + Date + "', '" + Time + "', '" + Priority + "')";

                        CMD_Insert.ExecuteReader();


                        

                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
            }
        }
        public static void updateRecord(checkdetails checkdetails)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    SqliteCommand CMD_Update = new SqliteCommand();
                    CMD_Update.Connection = con;



                    CMD_Update.CommandText = "UPDATE task2 SET  TaskDate='"+checkdetails.getDate()+"',TaskTime='"+checkdetails.getTime()+"',Taskpriority='"+checkdetails.getPriority()+"' WHERE TaskName='"+checkdetails.getName()+"'";

                    CMD_Update.ExecuteReader();

                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

            public static List<TaskData> sendData1(String value)
            {
            con.Open();
            List<TaskData> list = new List<TaskData>();
            SqliteCommand CMD_Select = new SqliteCommand();
            CMD_Select.Connection = con;

            CMD_Select.CommandText = "SELECT TaskName,TaskDate,TaskTime,Taskpriority from task2 where TaskName='"+value+"'";
            TaskData td = new TaskData();
            SqliteDataReader reader = CMD_Select.ExecuteReader();
          
            while(reader.Read())
            {

               
                td.setName(reader.GetString(0));
               
                td.setDate(reader.GetString(1));
               
                td.setTime(reader.GetString(2));
                
                td.setPriority(reader.GetString(3));
                list.Add(td);

            }

            return list;
    }

           


        public class TaskDetails
        {
            public String name;
            
            public void setName(String name)
            {
                this.name = name;
            }
            public String getName()
            {
                return name;
            }
            public String date { get; set; }
            public String time { get; set; }
            public String priority { get; set; }


            public TaskDetails( String TaskName, String TaskDate, String TaskTime, String Taskpriority)
            {
                
                name = TaskName;
                date = TaskDate;
                time = TaskTime;
                priority = Taskpriority;
            }

        }

        public static List<TaskDetails> GetAllRecords(String value)
        {
            List<TaskDetails> TasksList = new List<TaskDetails>();
            string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "teskData.db");
            using (SqliteConnection con = new SqliteConnection($"FileName={pathToDB}"))
            {
                con.Open();
                String selectCMD = "SELECT TaskId,TaskName,TaskDate,TaskTime,Taskpriority from task2 WHERE TaskName= value";
                SqliteCommand CMD_GetRec = new SqliteCommand(selectCMD, con);

                SqliteDataReader reader = CMD_GetRec.ExecuteReader();

                while (reader.Read())
                {
                    TasksList.Add(new TaskDetails(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
                con.Close();

            }
            return TasksList;
        }


    }
}
