using System;
using MySql.Data.MySqlClient;

namespace Db
{
    class DB
    {
        private void createDb()
        {
            //connector
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes; UserId=root;PWD=123456;");
            //database creating sentence
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EZXISTS ASSIGNMENT DEFAULT CHARSET UTF8;", conn);
            Console.WriteLine("Database created successfully.");
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void createTb()
        {
            //database connecting sentence
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            //User Table Creating Sentences
            string createUser = "CREAT TABLE User (" +
                "UserId int primary key auto_increment," +//primary key
                "Username varchar(50) unique," +
                "Password varchar(20)," +
                "UserType int" +//0 for students and 1 for teachers
                ");";
            //Class Table Creating Sentences
            string createClass = "CREAT TABLE Class (" +
                "ClassId int primary key auto_increment," +//primary key
                "ClassName varchar(50)," +
                "Description varchar(100)," +
                "CreateTime date" +
                ");";
            //Homework Table Creating Sentences
            string createHomework = "CREAT TABLE Homework (" +
                "HomeworkId int primary key auto_increment," +//primary key
                "HomeworkName varchar(50)," +
                "Description varchar(300)," +
                "PublishTime date" +
                "Deadline date" +
                "Status int" +//0 for unsubmitted, 1 for submitted and 2 for corrected
                ");";
            //Homework Submission Table Creating Sentences
            string createHomeworkSubmission = "CREAT TABLE HomeworkSubmission (" +
                "SubmissionId int primary key auto_increment," +//primary key
                "StudentId int," +
                "HomeworkId int," +
                "SubmissionTime date" +
                "Content varchar(200)" +
                ");" +
                "alter table HomeworkSubmission add constraint fk_hs_sti foreign key (StudentId) references User (UserId);" +
                "alter table HomeworkSubmission add constraint fk_hs_hi foreign key (HomeworkId) references Homework (HomeworkId);";
            //Class Student Table Creating Sentences
            string createClassStudent = "CREAT TABLE ClassStudent (" +
                "ClassId int not null," +
                "StudentId int not null," +
                "primary key (ClassId,StudentId)" +//composite primary key
                ");" +
                "alter table ClassStudent add constraint fk_cs_ci foreign key (ClassId) references Class (ClassId);" +
                "alter table ClassStudent add constraint fk_cs_sti foreign key (StudentId) references User (UserId);";
            //connect database
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //create tables
            try
            {
                MySqlCommand cmd = new MySqlCommand(createUser,conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(createClass, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(createHomework, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(createHomeworkSubmission, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(createClassStudent, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Tables created successfully.");
            }
            catch
            {
                Console.WriteLine("Tables already exists.");
            }
            conn.Close();
        }
        public void dbInit()
        {
            createDb();
            createTb();
        }
        public int addUser(string name,string password,int type)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public int addClass(string name, string desc, string time)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public int addHomework(string name, string desc, string ptime,string ddl, int sta)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            //homework adding sentences
            string addh = "INSERT INTO Homwork (" +
                "HomeworkName,Description,PublishTime,Deadline,Status)" +
                "VALUES (" +
                name + "," +
                desc + "," +
                ptime + "," +
                ddl + "," +
                sta + 
                ");";
            string getId = "MAX(HomworkId)";
            int hid = -1;//-1 for failed
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //adding a homeework
            try
            {
                MySqlCommand cmd = new MySqlCommand(addh, conn);
                cmd.ExecuteNonQuery();
                cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                hid = reader.GetInt32("HomeworkId");
                Console.WriteLine("Homework added successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return hid;
        }
        public int addHomeworkSubmission(int sid, int hid, string time, string cont)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void addClassStudent(int cid, int sid)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            //class joining sentences
            string addcs = "INSERT INTO ClassStudent (" +
                "ClassId,StudentId)" +
                "VALUES (" +
                cid + "," +
                sid +
                ");";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //joining a class
            try
            {
                MySqlCommand cmd = new MySqlCommand(addcs, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Class student added successfully.");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
        }
        public void delUser(int id)//only for teachers
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        private void delClass(int id)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        private void delHomework(int id)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void delHomeworkSubmission(int id)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void delClassStudent(int cid, int sid)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void delStudent(int id)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void delCs(int id)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void delHw(int id)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public int getUserId(string name)
        {
            int uid = -1;//-1 for unfound
            //id getting sentences
            string getId = "SELECT UserId FROM User WHERE Username = '" +
                name +
                "';";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting id
            try
            {
                MySqlCommand cmd = new MySqlCommand(getId, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                uid = reader.GetInt32("UserId");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return uid;
        }
        public string getUsername(int id)
        {
            string name = " Not found.";//for unfound
            //name getting sentences
            string getName = "SELECT Usernamee FROM User WHERE UserId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public string getClassName(int id)
        {
            string name = "Not found.";//for unfound
            //name getting sentencss
            string getName = "SELECT ClassName FROM Class WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting nam
            try
            {
                MySqlCommand cmd = new MySqlCommand(getName, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                name = reader.GetString("ClassName");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return name;
        }
        public string getClassDescription(int id)
        {
            string desc = "Not found.";//for unfound
            //description getting sentences
            string getDesc = "SELECT Description FROM Class WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting description
            try
            {
                MySqlCommand cmd = new MySqlCommand(getDesc, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                desc = reader.GetString("Description");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return desc;
        }
        public string getClassCTime(int id)
        {
            string time = "Not found.";//for unfound
            //time getting sentences
            string getTime = "SELECT CreatedTime FROM Class WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting time
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                time = reader.GetString("CreatedTime");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public string getHomeworkName(int id)
        {
            string name = "Not found.";//for unfound
            //name getting sentences
            string getName = "SELECT HomeworkName FROM Homework WHERE HomeworkId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting namee
            try
            {
                MySqlCommand cmd = new MySqlCommand(getName, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                name = reader.GetString("HomeworkName");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return name;
        }
        public string getHomeworkDescription(int id)
        {
            string desc = "Not found.";//for unfound
            //description getting sentences
            string getDesc = "SELECT Description FROM Honmework WHERE HomeworkId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting description
            try
            {
                MySqlCommand cmd = new MySqlCommand(getDesc, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                desc = reader.GetString("Description");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return desc;
        }
        public string getHomeworkPTime(int id)
        {
            string time = "Not found.";//for unfound
            //publish time getting sentences
            string getTime = "SELECT PublishTime FROM Homework WHERE HonmeworkId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting publish time
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                time = reader.GetString("PublishTime");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public string getHomeworkDdl(int id)
        {
            string time = "Not found.";//for unfound
            //dadline getting sentences
            string getTime = "SELECT Deadline FROM Homework WHERE HonmeworkId = " +
                id +
                ";";
            //connctor
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //gtting deadline
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                time = reader.GetString("Deadline");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public int getHomeworkStatus(int id)
        {
            int sta = -1;//-1 for unfound
            //status getting sentences
            string getSta = "SELECT Status FROM Homework WHERE HonmeworkId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting status
            try
            {
                MySqlCommand cmd = new MySqlCommand(getSta, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                sta = reader.GetInt32("Status");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return sta;
        }
        public int getSubmissionStudentId(int id)
        {
            int sid = -1;//-1 for unfound
            //student id getting sntnces
            string getSid = "SELECT StudentId FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting student id
            try
            {
                MySqlCommand cmd = new MySqlCommand(getSid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                sid = reader.GetInt32("StudentId");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return sid;
        }
        public int getSubmissionHomeeworkId(int id)
        {
            int hid = -1;//-1 for unfound
            //homework getting snteences
            string getHid = "SELECT HomeworkId FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting homework id
            try
            {
                MySqlCommand cmd = new MySqlCommand(getHid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                hid = reader.GetInt32("HomeworkId");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return hid;
        }
        public string getSubmissionTime(int id)
        {
            string time = "Not found.";//for unfound
            //time getting sentences
            string getTime = "SELECT SubmissionTime FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //conneector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting time
            try
            {
                MySqlCommand cmd = new MySqlCommand(getTime, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                time = reader.GetString("SubmissionTime");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return time;
        }
        public string getSubmissionContent(int id)
        {
            string cont = "Not found.";//for unfound
            //content gtting sentences
            string getCon = "SELECT Content FROM HomeworkSubmission WHERE SubmissionId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            //getting content
            try
            {
                MySqlCommand cmd = new MySqlCommand(getCon, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                cont = reader.GetString("Content");
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return cont;
        }
        public int[] getClassStudentId(int id)
        {
            int[] studentId = new int[100];//max size = 100
            //id gtting sentsncss
            string getSid = "SELECT StudentId FROM ClassStudent WHERE ClassId = " +
                id +
                ";";
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            int i = 0;//couter
            try
            {
                MySqlCommand cmd = new MySqlCommand(getSid, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //loop
                while (reader.Read())
                {
                    studentId[i] = reader.GetInt32("StudentId");
                    i++;//counter
                }
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return studentId;
        }
        public int[] getStudentClassId(int id)
        {
            int[] classId = new int[100];//max size = 100
            //id getting sentences
            string getCid = "SELECT ClassId FROM ClassStudent WHERE StudentId = " +
                id +
                ";";
            //connctor
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public string[] getClassStudent(int id)
        {
            string[] student = new string[100];//max size = 100
            int[] sid = getClassStudentId(id);//get studnt id
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            try
            {
                //loop
                for(int i = 0; i < 100; i++)
                {
                    //translate student id into name
                    student[i] = getUsername(sid[i]);
                }
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return student;
        }
        public string[] getStudentClass(int id)
        {
            string[] cls = new string[100];//max size = 100
            int[] cid = getStudentClassId(id);//get class id
            //connctor
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            Console.WriteLine("Database connected successfully.");
            try
            {
                //loop
                for (int i = 0; i < 100; i++)
                {
                    //translate class id into name
                    cls[i] = getClassName(cid[i]);
                }
            }
            catch
            {
                Console.WriteLine("Unexpected error.");
            }
            conn.Close();
            return cls;
        }
        public void altPassword(int id, string pwd)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altClassName(int id, string name)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altClassDescription(int id, string desc)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altHomeworkName(int id, string name)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altHomeworkDescription(int id, string desc)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altHomeworkDdl(int id, string ddl)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altHomeworkStatus(int id, int sta)
        {
            //connector
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altSubmissionTime(int id, string time)
        {
            //connctor
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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
        public void altSubmissionContent(int id, string cont)
        {
            //content
            string connStr = "server=localhost;port=3306;databse=ASSIGNMENT;user=root;password=123456;";
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