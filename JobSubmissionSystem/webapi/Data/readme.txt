This database operating source file is designed for MySQL. Before compiling it, please make sure to install MySQL properly and add MySqlConnector NuGet package to th projct correctly.


	#Before using
Please make sure that:
-MySQL server is configured at localhost.
-Port is 3306.
-Username is root.
-Password is 123456.

It would be better that:
-No database named ASSIGNMENThas beeen created before.
-No tables named User, Class, Homework, HomeworkSubmission and ClassStudent has been created in database ASSIGNMENT.


	#While using
Use namespace Db and class Db.
The functions of the 43 methods are as follows:
	1.1 createDb
		A private void method  to create a database named ASSIGNMENT at localhost:3306, user root, password 123456.
	1.2 createTb
		A private void method  to create tables named User, Class, Homework, HomeworkSubmission and ClassStudent on database ASSIGNMENT.
			User: UserId(main key), Username(unique), Password, UserType(0 for students and 1 for teachers)
			Class: ClassId(main key), ClassName, Description, CrateTime
			Homework: HomworkId(main key), HomeworkName, Description, PublishTim, Deadline, Status(0 for unsubmitted, 1 for submitted and 2 for corrected)
			HomeworkSubmission: SubmissionId(main key), StudentId(foreign key -> User.UserId), HomeworkId(foreign key -> Homwork.HomeworkId), SubmissionTime, Content
			ClassStudent: ClassId(foreign key -> Class.ClassId), StudentId(foreign key -> User.UserId)(composite main key (ClassId, StudentId))
	1.dbInit
		A public void method containing createDb and createTb.
	2.1 addUser
		A public int method to create a user and return UserId.
	2.2 addClass
		A public int mthod to create a class and return ClassId.
	2.3 addHomework
		A public int method to create a homework and return HomeworkId.
	2.4 addHomeworkSubmission
		A public int method to create a submission and return SubmissionId.
	2.5 addClassStudent
		A public void method to create a submission.
	3.1 delUser
		A public void method to delete a user.
		Only used for teeachers because students have forign key constraints.
	3.2 delClass
		A private void method to delete a class.
		Not for directly using because classes have forign key constraints.
	3.3 delHomework
		A private void method to delete a homework.
		Not for directly using because homeworks have forign key constraints.
	3.4 delHomeworkSubmission
		A public void method to delete a submission.
	3.5 delClassStudent
		A public void method to delete a class-student.
	3.6 delStudent
		A public void method to delete a student by removing forign key constraints first.
	3.7 delCs
		A public void method to delete a class by removing forign key constraints first.
	3.8 delHw
		A public void method to delete a homeework by removing forign key constraints first.
	4.1 getUserId
		A public int method to get UserId through Username.
	4.2 getUsername
		A public string method to get Username through UserId.
	4.3 getClassName
		A public string method to get ClassName through ClassId.
	4.4 getClassDescription
		A public string method to get Class Description through ClassId.
	4.5 getClassCTime
		A public string method to get Class CreatedTime through ClassId.
	4.6 getHomeworkName
		A public string method to get HomeworkName through HomeworkId.
	4.7 getHomeworkDescription
		A public string method to get Homework Description through HomeworkId.
	4.8 getHomeworkPTime
		A public string method to get Homework PublishTime through HomeworkId.
	4.9 getHomeworkDdl
		A public string method to get Homework Deadline through HomeworkId.
	4.10 getHomeworkStatus
		A public int method to get Homework Status through HomeworkId.
	4.11 getSubmissionStudentId
		A public int method to get StudentId from HomeworkSubmission through SubmissionId.
	4.12 getSubmissionHomeworkId
		A public int method to get HomeworkId from HomeworkSubmission through SubmissionId.
	4.13 getSubmissionTime
		A public string method to get SubmissionTime through SubmissionId.
	4.14 getSubmissionContent
		A public string method to get Submission Content through SubmissionId.
	4.15 getClassStudentId
		A public int array method to get StudentId from ClassStudent through ClassId.
		Each class can hold at most 100 students.
	4.16 getStudentClassId
		A public int array method to get ClassIdfrom ClassStudent through StudentId.
		Each student can join in at most 100 classes.
	4.17 getClassStudent
		A public int array method to get Username from ClassStudent through ClassId.
		Each class can hold at most 100 students.
	4.18 getStudentClass
		A public int array method to get ClassName from ClassStudent through StudentId.
		Each student can join in at most 100 classes.
	5.1 altPassword
		A public void method to edit Password through UserId.
	5.2 altClassName
		A public void method to edit ClassName through ClassId.
	5.3 altClassDescription
		A public void method to edit Class Description through ClassId.
	5.4 altHomeworkName
		A public void method to edit HomeworkName through HomeworkId.
	5.5 altHomeworkDescription
		A public void method to edit Homework Description through HomeworkId.
	5.6 altHomeworkDdl
		A public void method to edit Homework Deadline through HomeworkId.
	5.7 altHomeworkStatus
		A public void method to edit Homework Status through HomeworkId.
	5.8 altSubmissionTime
		A public void method to edit SubmissionTime through SubmissionId.
	5.9 altSubmissionContent
		A public void method to edit Submission Content through SubmissionId.