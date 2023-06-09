/*
 Navicat Premium Data Transfer

 Source Server         : JobSubmissionSystem
 Source Server Type    : MySQL
 Source Server Version : 80033 (8.0.33)
 Source Host           : localhost:3306
 Source Schema         : assignment

 Target Server Type    : MySQL
 Target Server Version : 80033 (8.0.33)
 File Encoding         : 65001

 Date: 09/06/2023 16:33:48
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for class
-- ----------------------------
DROP TABLE IF EXISTS `class`;
CREATE TABLE `class`  (
  `ClassId` int NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Description` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `CreateTime` date NULL DEFAULT NULL,
  `TeacherId` int NOT NULL,
  PRIMARY KEY (`ClassId`, `TeacherId`) USING BTREE,
  INDEX `TeacherId`(`TeacherId` ASC) USING BTREE,
  INDEX `ClassId`(`ClassId` ASC) USING BTREE,
  CONSTRAINT `class_ibfk_1` FOREIGN KEY (`TeacherId`) REFERENCES `user` (`UserId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of class
-- ----------------------------
INSERT INTO `class` VALUES (1, '周三软构', '无', '2023-04-04', 1);
INSERT INTO `class` VALUES (2, '周五软构', '无', '2023-06-05', 1);

-- ----------------------------
-- Table structure for classstudent
-- ----------------------------
DROP TABLE IF EXISTS `classstudent`;
CREATE TABLE `classstudent`  (
  `ClassId` int NOT NULL,
  `StudentId` int NOT NULL,
  `url` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`ClassId`, `StudentId`) USING BTREE,
  INDEX `fk_cs_sti`(`StudentId` ASC) USING BTREE,
  CONSTRAINT `fk_cs_ci` FOREIGN KEY (`ClassId`) REFERENCES `class` (`ClassId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_cs_sti` FOREIGN KEY (`StudentId`) REFERENCES `user` (`UserId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of classstudent
-- ----------------------------
INSERT INTO `classstudent` VALUES (1, 2, 'https://github.com/yanyanyanyy/DotNetHomeWork.git');
INSERT INTO `classstudent` VALUES (1, 3, 'https://github.com/yanyanyanyy/DotNetHomeWork.git');
INSERT INTO `classstudent` VALUES (1, 4, 'https://github.com/yanyanyanyy/DotNetHomeWork.git');

-- ----------------------------
-- Table structure for correctinf
-- ----------------------------
DROP TABLE IF EXISTS `correctinf`;
CREATE TABLE `correctinf`  (
  `studentId` int NOT NULL,
  `courseId` int NOT NULL,
  `assignmentIndex` int NULL DEFAULT NULL,
  `correctInf` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
  `Id` int NOT NULL AUTO_INCREMENT,
  `codeInf` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
  `flagged` tinyint(1) NULL DEFAULT NULL,
  `filepath` text CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `courseId`(`courseId` ASC) USING BTREE,
  INDEX `studentId`(`studentId` ASC) USING BTREE,
  CONSTRAINT `correctinf_ibfk_1` FOREIGN KEY (`studentId`) REFERENCES `user` (`UserId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `correctinf_ibfk_2` FOREIGN KEY (`courseId`) REFERENCES `class` (`ClassId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 32 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of correctinf
-- ----------------------------
INSERT INTO `correctinf` VALUES (2, 1, 1, '', 20, 'using System;\n\nnamespace project1\n{\n    internal class Program\n    {\n        static void Main(string[] args)\n        {\n            Console.Writ', 0, 'assignment1/project1/Program.cs');
INSERT INTO `correctinf` VALUES (2, 1, 1, '测试修改', 21, 'eLine(\"请输入第一个操作数:\");\n            double num1 = double.Parse(Console.ReadLine());\n            Console.WriteLine(\"请输入第二个操作数:\");\n            double num2 = double.P', 0, 'assignment1/project1/Program.cs');
INSERT INTO `correctinf` VALUES (2, 1, 1, '', 22, 'arse(Console.ReadLine());\n            Console.WriteLine(\"请输入操作符:\");\n            int op = Console.Read();\n\n            if (op == \'+\')\n            {\n                Console.WriteLine(num1 + num2);\n            }\n            else if (op == \'-\')\n            {\n                Console.WriteLine(num1 - num2);\n            }\n            else if (op == \'*\')\n            {\n                Console.WriteLine(num1 * num2);\n            }\n            else if (op == \'/\') \n            { \n                Console.WriteLine(num1 / num2);\n            }\n            Console.ReadKey();\n        }\n    }\n}\n', 0, 'assignment1/project1/Program.cs');
INSERT INTO `correctinf` VALUES (3, 1, 1, '', 23, 'using System.Reflection;\nusing System.Runtime.CompilerServices;\nusing System.Runtime.InteropServices;\n\n// 有关程序集的一般信息由以下\n// 控制。更改这些特性值可修改\n// 与程序集关', 0, 'assignment1/project1/Properties/AssemblyInfo.cs');
INSERT INTO `correctinf` VALUES (3, 1, 1, '归并测试', 24, '联的信息。\n[assembly: AssemblyTitle(\"project1\")]\n[assembly: AssemblyDescription(\"\")]\n[assembly: AssemblyConfiguration(\"\")]\n[assembly: AssemblyCompany(\"\")]\n[assembly: AssemblyProduct(\"project1\")]\n[assembly: AssemblyCopyright(\"Copyright ©  2023\")]\n[assembly: Assembly', 0, 'assignment1/project1/Properties/AssemblyInfo.cs');
INSERT INTO `correctinf` VALUES (3, 1, 1, '', 25, 'Trademark(\"\")]\n[assembly: AssemblyCulture(\"\")]\n\n// 将 ComVisible 设置为 false 会使此程序集中的类型\n//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型\n//请将此类型的 ComVisible 特性设置为 true。\n[assembly: ComVisible(false)]\n\n// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID\n[assembly: Guid(\"5bcf49ba-b3fa-4eb9-bf87-ad7c2f087910\")]\n\n// 程序集的版本信息由下列四个值组成: \n//\n//      主版本\n//      次版本\n//      生成号\n//      修订号\n//\n//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值\n//通过使用 \"*\"，如下所示:\n// [assembly: AssemblyVersion(\"1.0.*\")]\n[assembly: AssemblyVersion(\"1.0.0.0\")]\n[assembly: AssemblyFileVersion(\"1.0.0.0\")]\n', 0, 'assignment1/project1/Properties/AssemblyInfo.cs');
INSERT INTO `correctinf` VALUES (2, 1, 1, '', 26, '<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<configuration>\n    <start', 0, 'assignment1/project1/App.config');
INSERT INTO `correctinf` VALUES (2, 1, 1, '又一提交', 27, 'up> \n        <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.7.2\" />\n    </startup>\n</configuratio', 0, 'assignment1/project1/App.config');
INSERT INTO `correctinf` VALUES (2, 1, 1, '', 28, 'n>', 0, 'assignment1/project1/App.config');
INSERT INTO `correctinf` VALUES (2, 1, 3, '', 29, 'using System;\nusing System.CodeDom;\nusing System.Collections.Generic;\nusing Sys', 0, 'assignment3/project1/Program.cs');
INSERT INTO `correctinf` VALUES (2, 1, 3, '？', 30, 'tem.Linq;\nusing System.Text;\nusing System.Thre', 0, 'assignment3/project1/Program.cs');
INSERT INTO `correctinf` VALUES (2, 1, 3, '', 31, 'ading.Tasks;\n\nnamespace project1\n{\n    public interface Shape\n    {\n        double getArea();\n        bool isVoliate();\n    }\n\n    public class Rectangle : Shape\n    {\n        private double height;\n        private double width;\n        \n        public Rectangle(double height, double width)\n        {\n            \n            this.height = height;\n            this.width = width;\n        }\n        public double getArea()\n        {\n            return height*width;\n        }\n        public bool isVoliate()\n        {\n            return height > 0 && width > 0;\n        }\n\n    }\n\n    public class Square : Rectangle\n    {\n        public Square(double size) : base(size, size) {}\n    }\n\n    public class Triangle : Shape\n    {\n        private double a;\n        private double b;\n        private double c;\n        public Triangle(double a, double b, double c)\n        {\n            this.a = a;\n            this.b = b;\n            this.c = c;\n        }\n\n        public double getArea()\n        {\n            double p = (a + b + c) / 2;\n            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));\n        }\n\n        public bool isVoliate()\n        {\n            return !(a < 0 || b < 0 || c < 0 || a + b <= c || a + c <= b || b + c <= a);\n        }\n    }\n    public class Project\n    {\n        public static void Main()\n        {\n            Shape shape = new Rectangle(5,5);\n            Console.WriteLine(\"5*5的矩形面积为：\"+shape.getArea());\n            shape = new Rectangle(-1, 5);\n            Console.WriteLine(\"-1*5的矩形是否合理：\" + shape.isVoliate());\n            shape = new Square(5);\n            Console.WriteLine(\"5的正方形面积为：\" + shape.getArea());\n            shape = new Square(-5);\n            Console.WriteLine(\"-5的正方形是否合理：\" + shape.isVoliate());\n            shape = new Triangle(5,5,5);\n            Console.WriteLine(\"5*5*5的三角形面积为：\" + shape.getArea());\n            shape = new Triangle(1,1,2);\n            Console.WriteLine(\"1*1*2的三角形是否合理：\" + shape.isVoliate());\n            Console.ReadKey();\n        }\n    }\n}\n', 0, 'assignment3/project1/Program.cs');

-- ----------------------------
-- Table structure for homework
-- ----------------------------
DROP TABLE IF EXISTS `homework`;
CREATE TABLE `homework`  (
  `HomeworkId` int NOT NULL AUTO_INCREMENT,
  `HomeworkName` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Description` varchar(300) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `PublishTime` datetime NULL DEFAULT NULL,
  `Deadline` datetime NULL DEFAULT NULL,
  `Status` int NULL DEFAULT NULL,
  `CourseId` int NOT NULL,
  PRIMARY KEY (`HomeworkId`, `CourseId`) USING BTREE,
  INDEX `CourseId`(`CourseId` ASC) USING BTREE,
  CONSTRAINT `homework_ibfk_1` FOREIGN KEY (`CourseId`) REFERENCES `class` (`ClassId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of homework
-- ----------------------------
INSERT INTO `homework` VALUES (13, '第一次作业', NULL, '2023-06-07 12:50:55', '2023-06-08 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (14, '第二次作业', NULL, '2023-06-07 12:51:04', '2023-06-11 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (15, '第三次作业', NULL, '2023-06-08 14:18:09', '2023-06-28 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (16, '第四次作业', NULL, '2023-06-08 14:18:17', '2023-06-30 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (17, '第五次作业', NULL, '2023-06-08 14:18:27', '2023-07-08 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (18, '第六次作业', NULL, '2023-06-08 14:18:34', '2023-07-16 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (19, '第七次作业', NULL, '2023-06-08 14:18:41', '2023-07-18 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (20, '第八次作业', NULL, '2023-06-08 14:18:48', '2023-07-20 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (21, '第九次作业', NULL, '2023-06-08 14:18:56', '2023-07-21 16:00:00', NULL, 1);
INSERT INTO `homework` VALUES (22, '第十次作业', NULL, '2023-06-08 14:19:06', '2023-07-25 16:00:00', NULL, 1);

-- ----------------------------
-- Table structure for homeworksubmission
-- ----------------------------
DROP TABLE IF EXISTS `homeworksubmission`;
CREATE TABLE `homeworksubmission`  (
  `SubmissionId` int NOT NULL AUTO_INCREMENT,
  `StudentId` int NULL DEFAULT NULL,
  `HomeworkId` int NULL DEFAULT NULL,
  `SubmissionTime` date NULL DEFAULT NULL,
  `Content` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`SubmissionId`) USING BTREE,
  INDEX `fk_hs_sti`(`StudentId` ASC) USING BTREE,
  INDEX `fk_hs_hi`(`HomeworkId` ASC) USING BTREE,
  CONSTRAINT `fk_hs_hi` FOREIGN KEY (`HomeworkId`) REFERENCES `homework` (`HomeworkId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_hs_sti` FOREIGN KEY (`StudentId`) REFERENCES `user` (`UserId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of homeworksubmission
-- ----------------------------

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Password` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `UserType` int NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`) USING BTREE,
  UNIQUE INDEX `Username`(`Username` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, '0', '7', 0);
INSERT INTO `user` VALUES (2, '6', '8', 1);
INSERT INTO `user` VALUES (3, '高岩', '111', 1);
INSERT INTO `user` VALUES (4, '付川恒', '123', 1);

SET FOREIGN_KEY_CHECKS = 1;
