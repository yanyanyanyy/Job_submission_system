using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using MySql.Data.MySqlClient;
using System.Configuration;
using webapi.Controllers;
using webapi.Models;
using Task = webapi.Models.Task;

namespace webapi.Datas
{
    class DB
    {
        public static string connString = "server=localhost;port=3306;uid=root;pwd=147963;database=ASSIGNMENT;CharSet=utf8;";
        
        public static int addUser(string name, string password, int type)
        {
            //connector
            string connStr = connString;
            //user adding sentences
            string addu = "INSERT INTO User (" +
                "Username,Password,Usertype)" +
                "VALUES (" +
                name + "," +
                password + "," +
                type +
                ");";
            string getId = "MAX(UserId)";
            int uid = -1;//-1 for failed
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //add a useer
            try
            {
                MySqlCommand cmd = new MySqlCommand(addu, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                uid = reader.GetInt32("UserId");
                Console.WriteLine("User added successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return uid;
        }
        public static int addClass(string name, string desc, string time)
        {
            //connector
            string connStr = connString;
            //class adding sentences
            string addc = "INSERT INTO Class (" +
                "ClassName,Description,CreatedTime)" +
                "VALUES (" +
                name + "," +
                desc + "," +
                time +
                ");";
            string getId = "MAX(ClassId)";
            int cid = -1;//-1 for failed
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //adding a class
            try
            {
                MySqlCommand cmd = new MySqlCommand(addc, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                cid = reader.GetInt32("ClassId");
                Console.WriteLine("Class added successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return cid;
        }
        public static int addHomework(int courseId,string name, DateTime ptime, DateTime ddl)
        {
            //connector
            string connStr = connString;
            //homework adding sentences
            string addh = "INSERT INTO Homework (" +
                "HomeworkName,PublishTime,Deadline,CourseId) " +
                "VALUES ('" +
                name + "','" +
                ptime + "','" +
                ddl + "','" +
                courseId +
                "');";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //adding a homeework
            try
            {
                MySqlCommand cmd = new MySqlCommand(addh, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
            catch
            {
                return -1;
            }
            
           
        }
        public static int addHomeworkSubmission(int sid, int hid, string time, string cont)
        {
            //connector
            string connStr = connString;
            //submitting senteences
            string addhs = "INSERT INTO HomworkSubmission (" +
                "StudentId,HomeworkId,SubmissionTime,Content)" +
                "VALUES (" +
                sid + "," +
                hid + "," +
                time + "," +
                cont +
                ");";
            string getId = "MAX(SubmissionId)";
            int hsid = -1;//-1 for faild
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //submitting
            try
            {
                MySqlCommand cmd = new MySqlCommand(addhs, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                hsid = reader.GetInt32("SubmissionId");
                Console.WriteLine("Homework submitted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return hsid;
        }

        public static int addCorrectInf(int sid, int cid, int index,string filepath, List<T> cont)
        {
            //connector
            string connStr = connString;
            //submitting senteences
            string addhs = "INSERT INTO correctinf (" +
                "StudentId,courseId,assignmentIndex,filepath,correctinf,codeInf,flagged) Values";
                
            foreach (T t in cont)
            {
                addhs += " (" + sid + "," + cid + "," + index + ",'"+filepath + "','" + t.correct_info + "','" + t.code.Replace("'", "\\'") + "'," + t.flag + "),";
                
            }
            addhs += ";";
            addhs = addhs.Remove(addhs.LastIndexOf(","), 1);
            int hsid = -1;//-1 for faild
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //submitting
            
                MySqlCommand cmd = new MySqlCommand(addhs, conn);
                cmd.ExecuteNonQuery();
                
            
            conn.Close();
            return hsid;
        }
        public static void addClassStudent(int cid, int sid,string url)
        {
            //connector
            string connStr = connString;
            //class joining sentences
            string addcs = "INSERT INTO ClassStudent (" +
                "ClassId,StudentId,url)" +
                "VALUES (" +
                cid + "," +
                sid + ",'" +
                url+
                "');";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //joining a class
            
                MySqlCommand cmd = new MySqlCommand(addcs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Class student added successfully.");
           
               
            conn.Close();
        }
        public static void delUser(int id)//only for teachers
        {
            //connector
            string connStr = connString;
            //user deleting sentences
            string delu = "DEL FROM User WHERE UserId =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting a user
            try
            {
                MySqlCommand cmd = new MySqlCommand(delu, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("User deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        private static void delClass(int id)
        {
            //connector
            string connStr = connString;
            //class deleting sentences
            string delc = "DELETE FROM Class WHERE ClassId =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting a class
            try
            {
                MySqlCommand cmd = new MySqlCommand(delc, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Class deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        private static void delHomework(int id)
        {
            //connector
            string connStr = connString;
            //homework deleting sentences
            string delh = "DELETE FROM Homwork WHERE HomeworkId =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting a homework
            try
            {
                MySqlCommand cmd = new MySqlCommand(delh, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void delHomeworkSubmission(int id)
        {
            //connector
            string connStr = connString;
            //submission deleting sentences
            string delhs = "DELETE FROM HomworkSubmission WHERE SubmissionId =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting a submission
            try
            {
                MySqlCommand cmd = new MySqlCommand(delhs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework submission deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void delClassStudent(int cid, int sid)
        {
            //connector
            string connStr = connString;
            //class-student deleting sentences
            string delcs = "DELETE FROM ClassStudent WHERE ClassId =" +
                cid + "&& StudentId =" +
                sid +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting a class-student
            try
            {
                MySqlCommand cmd = new MySqlCommand(delcs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Class student deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void delStudent(int id)
        {
            //connector
            string connStr = connString;
            //delete foreign keys from class-student
            string delcs = "DELETE FROM ClassStudent WHERE StudentId =" +
                id +
                ";";
            //delete foreign keeys from submission
            string delhs = "DELETE FROM HomworkSubmission WHERE StudentId = =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting foreign keys
            try
            {
                MySqlCommand cmd = new MySqlCommand(delcs, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(delhs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            //delete the user
            delUser(id);
        }
        public static void delCs(int id)
        {
            //connector
            string connStr = connString;
            //delete foreign keys from class-student
            string delcs = "DELETE FROM ClassStudent WHERE ClassId = =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting foreign keys
            try
            {
                MySqlCommand cmd = new MySqlCommand(delcs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            //delete the class
            delClass(id);
        }
        public static void delHw(int id)
        {
            //connector
            string connStr = connString;
            //delete foreign keys from submission
            string delhs = "DELETE FROM HomworkSubmission WHERE HomeworkId = =" +
                id +
                ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //deleting foreign kys
            try
            {
                MySqlCommand cmd = new MySqlCommand(delhs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework deleted successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            //delete the homwork
            delHomework(id);
        }
        public static int getUserId(string name)
        {
            int uid = -1;//-1 for unfound
            //id getting sentences
            string getId = "SELECT UserId FROM User WHERE Username = '" +
                name +
                "';";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting id
            try
            {
                MySqlCommand cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                uid = reader.GetInt32("UserId");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return uid;
        }
        public static string getUsername(int id)
        {
            string name = " Not found.";//for unfound
            //name getting sentences
            string getName = "SELECT Username FROM User WHERE UserId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting name
            try
            {
                MySqlCommand cmd = new MySqlCommand(getName, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                name = reader.GetString("Username");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return name;
        }
        public static int getUserType(int id)
        {
            int type = -1;//-1 for unfound
            //id getting sentences
            string getId = "SELECT UserType FROM User WHERE UserId = '" +
                id +
                "';";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting type
            try
            {
                MySqlCommand cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                type = reader.GetInt32("UserType");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return type;
        }
        public static string getUserPassword(int id)
        {
            string password = " Not found.";//for unfound
            //name getting sentences
            string getName = "SELECT Password FROM User WHERE UserId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting name
            try
            {
                MySqlCommand cmd = new MySqlCommand(getName, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                password = reader.GetString("Password");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return password;
        }
        public static string getClassName(int id)
        {
            string name = "Not found.";//for unfound
            //name getting sentencss
            string getName = "SELECT ClassName FROM Class WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting nam
            try
            {
                MySqlCommand cmd = new MySqlCommand(getName, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                name = reader.GetString("ClassName");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return name;
        }
        public static string getClassDescription(int id)
        {
            string desc = "Not found.";//for unfound
            //description getting sentences
            string getDesc = "SELECT Description FROM Class WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting description
            try
            {
                MySqlCommand cmd = new MySqlCommand(getDesc, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                desc = reader.GetString("Description");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return desc;
        }
        public static string getClassCTime(int id)
        {
            string time = "Not found.";//for unfound
            //time getting sentences
            string getTime = "SELECT CreatedTime FROM Class WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting time
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                time = reader.GetString("CreatedTime");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }

        public static List<T> getCorrectInf(int courseId, int studentId, int workIndex)
        {
            List<T> list = new List<T>();
            //time getting sentences
            string getTime = "SELECT correctinf,codeInf,flagged,filepath FROM correctInf WHERE courseId = " +
                courseId + " and StudentId=" + studentId + " and assignmentIndex=" + workIndex +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");

            //getting time
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                T t = new T();
                t.flag = reader.GetBoolean("flagged");
                t.correct_info = reader.GetString("correctinf");
                t.code = reader.GetString("codeInf");
                t.path = reader.GetString("filepath");
                list.Add(t);
            }
            
            conn.Close();
            return list;
        }
        public static List<Course> getTeacherClassInfo(int id)
        {
            List<Course> courses = new List<Course>(); 
            //id getting sentences
            string getCid = "SELECT * FROM Class WHERE teacherId =" +
                id +
                ";";
            //connctor
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            int i = 0;//counter
            //try
            //{
                MySqlCommand cmd = new MySqlCommand(getCid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //loop
                while (reader.Read())
                {
                Course course = new Course();
                course.startTime = reader.GetDateTime("CreateTime");
                course.id = (int)reader.GetUInt32("ClassId");
                course.courseName = reader.GetString("ClassName");
                course.teacherId = id;
                courses.Add(course);
                }
            //}
            //catch
            //{
              //  Console.WriteLine("Unexpected error.");
            //}
            conn.Close();
            return courses;
        }
        public static List<Task> getTaskInfo(int id)
        {
            List<Task> tasks = new List<Task>();
            //id getting sentences
            string getCid = "SELECT * FROM HomeWork WHERE CourseId =" +
                id +
                " order by PublishTime;";
            //connctor
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            int i = 0;//counter
                      //try
                      //{
            MySqlCommand cmd = new MySqlCommand(getCid, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            //loop
            while (reader.Read())
            {
                Task task = new Task();
                task.startTime = reader.GetDateTime("PublishTime");
                task.endTime = reader.GetDateTime("DeadLine");
                task.Id = (int)reader.GetUInt32("HomeWorkId");
                task.desc = reader.GetString("HomeWorkName");
                task.courseId = id;
                tasks.Add(task);
            }
            //}
            //catch
            //{
            //  Console.WriteLine("Unexpected error.");
            //}
            conn.Close();
            return tasks;
        }
        public static string getHomeworkName(int id)
        {
            string name = "Not found.";//for unfound
            //name getting sentences
            string getName = "SELECT HomeworkName FROM Homework WHERE HomeworkId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting namee
            try
            {
                MySqlCommand cmd = new MySqlCommand(getName, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                name = reader.GetString("HomeworkName");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return name;
        }
        public static string getHomeworkDescription(int id)
        {
            string desc = "Not found.";//for unfound
            //description getting sentences
            string getDesc = "SELECT Description FROM Honmework WHERE HomeworkId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting description
            try
            {
                MySqlCommand cmd = new MySqlCommand(getDesc, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                desc = reader.GetString("Description");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return desc;
        }
        public static string getHomeworkPTime(int id)
        {
            string time = "Not found.";//for unfound
            //publish time getting sentences
            string getTime = "SELECT PublishTime FROM Homework WHERE HonmeworkId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting publish time
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                time = reader.GetString("PublishTime");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public static string getHomeworkDdl(int id)
        {
            string time = "Not found.";//for unfound
            //dadline getting sentences
            string getTime = "SELECT Deadline FROM Homework WHERE HonmeworkId = " +
                id +
                ";";
            //connctor
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //gtting deadline
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                time = reader.GetString("Deadline");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public static int getHomeworkStatus(int id)
        {
            int sta = -1;//-1 for unfound
            //status getting sentences
            string getSta = "SELECT Status FROM Homework WHERE HonmeworkId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting status
            try
            {
                MySqlCommand cmd = new MySqlCommand(getSta, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                sta = reader.GetInt32("Status");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return sta;
        }
        public static int getSubmissionStudentId(int id)
        {
            int sid = -1;//-1 for unfound
            //student id getting sntnces
            string getSid = "SELECT StudentId FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting student id
            try
            {
                MySqlCommand cmd = new MySqlCommand(getSid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                sid = reader.GetInt32("StudentId");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return sid;
        }
        public static int getSubmissionHomeworkId(int id)
        {
            int hid = -1;//-1 for unfound
            //homework getting snteences
            string getHid = "SELECT HomeworkId FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting homework id
            try
            {
                MySqlCommand cmd = new MySqlCommand(getHid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                hid = reader.GetInt32("HomeworkId");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return hid;
        }
        public static string getSubmissionTime(int id)
        {
            string time = "Not found.";//for unfound
            //time getting sentences
            string getTime = "SELECT SubmissionTime FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //conneector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting time
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                time = reader.GetString("SubmissionTime");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public static string getSubmissionContent(int id)
        {
            string cont = "Not found.";//for unfound
            //content gtting sentences
            string getCon = "SELECT Content FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting content
            try
            {
                MySqlCommand cmd = new MySqlCommand(getCon, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                cont = reader.GetString("Content");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return cont;
        }
        public static int[] getStudentClassId(int id)
        {
            int[] classId = new int[100];//max size = 100
            //id getting sentences
            string getCid = "SELECT ClassId FROM ClassStudent WHERE StudentId = " +
                id +
                ";";
            //connctor
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            int i = 0;//counter
            try
            {
                MySqlCommand cmd = new MySqlCommand(getCid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //loop
                while (reader.Read())
                {
                    classId[i] = reader.GetInt32("ClassId");
                    i++;//counter
                }
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return classId;
        }
        public static List<Student> getClassStudent(int id)
        {
            List<Student> student = new List<Student>();
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            string search_str = "Select * From User,classstudent Where User.UserId=StudentID and ClassId =" + id + ";";
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            MySqlCommand cmd = new MySqlCommand(search_str, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            //loop
            while (reader.Read())
            {
                Student stu = new Student();
                stu.userName = reader.GetString("username");
                stu.id = reader.GetInt32("UserId");
                stu.url = reader.GetString("url");
                student.Add(stu);
            }

            conn.Close();
            return student;
        }
        public static List<int> getCorrect(int studentId,int classId)
        {
            List<int> s = new List<int>();
            //connector
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            string search_str = "Select distinct assignmentIndex  From correctInf Where StudentID=" + studentId+" and courseId =" + classId + ";";
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            MySqlCommand cmd = new MySqlCommand(search_str, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            //loop
            while (reader.Read())
            {
                reader.GetInt32("assignmentIndex");
                s.Add(reader.GetInt32("assignmentIndex"));
            }

            conn.Close();
            return s;
        }
        public static List<Course> getStudentClass(int id)
        {
            List<Course> courses = new List<Course>();
            //id getting sentences
            string getCid = "SELECT CreateTime,classstudent.ClassId,ClassName,url  FROM classstudent,class WHERE studentid =" +
                id +
                " AND classstudent.classid=class.classid;";
            //connctor
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            int i = 0;//counter
                      //try
                      //{
            MySqlCommand cmd = new MySqlCommand(getCid, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            //loop
            while (reader.Read())
            {
                Course course = new Course();
                course.startTime = reader.GetDateTime("CreateTime");
                course.id = (int)reader.GetUInt32("ClassId");
                course.courseName = reader.GetString("ClassName");
                course.url = reader.GetString("url");
                courses.Add(course);
            }
            //}
            //catch
            //{
            //  Console.WriteLine("Unexpected error.");
            //}
            conn.Close();
            return courses;
        }
        public static string getStudentUrl(int studentId,int courseId)
        {
            string url = "";
            string sql = "SELECT url FROM ClassStudent WHERE StudentId = " +
                studentId +
                " and ClassId = " + courseId+";";
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                url = reader.GetString("url");
            }
            reader.Read();            
            conn.Close();
            return url;
        }
        
        public static List<string> getClassStudentUrl(int courseId)
        {
            List<string> urls = new List<string>();
            string url = "";
            string sql = "SELECT url FROM ClassStudent WHERE ClassId = " + courseId + ";";
            string connStr = connString;
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                urls.Add(reader.GetString("url"));
            }
            reader.Read();
            conn.Close();
            return urls;
        }
        public static void altPassword(int id, string pwd)
        {
            //connector
            string connStr = connString;
            //password editing sntences
            string aPwd = "UPDATE User SET Password = '" +
                pwd +
                "' WHERE UserId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing password
            try
            {
                MySqlCommand cmd = new MySqlCommand(aPwd, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Password edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altClassName(int id, string name)
        {
            //connector
            string connStr = connString;
            //nam editing sentencees
            string aName = "UPDATE Class SET ClassName = '" +
                name +
                "' WHERE ClassId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing name
            try
            {
                MySqlCommand cmd = new MySqlCommand(aName, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Class name edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altClassDescription(int id, string desc)
        {
            //connector
            string connStr = connString;
            //description editing sentences
            string aDesc = "UPDATE Class SET Description = '" +
                desc +
                "' WHERE ClassId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing description
            try
            {
                MySqlCommand cmd = new MySqlCommand(aDesc, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Class description edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altHomeworkName(int id, string name)
        {
            //connector
            string connStr = connString;
            //name editing sentences
            string aName = "UPDATE Homework SET HomworkName = '" +
                name +
                "' WHERE HomworkId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing name
            try
            {
                MySqlCommand cmd = new MySqlCommand(aName, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework name edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altHomeworkDescription(int id, string desc)
        {
            //connector
            string connStr = connString;
            //deescription editing sentences
            string aDesc = "UPDATE Homework SET Description = '" +
                desc +
                "' WHERE HomeworkId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing description
            try
            {
                MySqlCommand cmd = new MySqlCommand(aDesc, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework description edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altHomeworkDdl(int id, string ddl)
        {
            //connector
            string connStr = connString;
            //deadline editing sentences
            string aDdl = "UPDATE Homework SET Deeadline = '" +
                ddl +
                "' WHERE HomeworkId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing deadline
            try
            {
                MySqlCommand cmd = new MySqlCommand(aDdl, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework deadline edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altHomeworkStatus(int id, int sta)
        {
            //connector
            string connStr = connString;
            //status editing sentences
            string aSta = "UPDATE Homework SET Status = " +
                sta +
                " WHERE HomeworkId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing status
            try
            {
                MySqlCommand cmd = new MySqlCommand(aSta, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework status edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altSubmissionTime(int id, string time)
        {
            //connctor
            string connStr = connString;
            //time editing sentences
            string aTime = "UPDATE HomeworkSubmission SET SubmissionTime = '" +
                time +
                "' WHERE SubmissionId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //editing time
            try
            {
                MySqlCommand cmd = new MySqlCommand(aTime, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework submission time edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public static void altSubmissionContent(int id, string cont)
        {
            //content
            string connStr = connString;
            //content editing sentences
            string aCon = "UPDATE HomeworkSubmission SET Content = '" +
                cont +
                "' WHERE SubmissionId =" +
                id +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //eediting content
            try
            {
                MySqlCommand cmd = new MySqlCommand(aCon, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Homework content edited successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }

    }
}