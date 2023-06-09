using Microsoft.AspNetCore.Mvc;
using webapi.Datas;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherWorkController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet("getClass")]
        public List<Course> Get(int id)
        {
            return DB.getTeacherClassInfo(id);
        }
        [HttpGet("getTask")]
        public List<Models.Task> GetCourse(int id)
        {
            return DB.getTaskInfo(id);
        }
        [HttpGet("getStudent")]
        public List<Student> GetStudent(int id)
        {
            return DB.getClassStudent(id);
        }
        [HttpGet("getSubmit")]
        public List<CR> GetSubmit(int studentId,int classId)
        {
            string url = DB.getStudentUrl(studentId, classId);
            if (url == "")
            { 
                return new List<CR>();
            }
            var (info,_) = GitTools.GetAssignments(url, "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");
            return info;
        }
        [HttpGet("getCorrect")]
        public List<int> getCorrect(int studentId, int classId)
        {
            return DB.getCorrect(studentId, classId);
        }
        [HttpGet("getAllSubmission")]
        public List<CommitRecord> getAllSubmission(int classId,int index)
        {
            List<Student> urls = DB.getClassStudent(classId);
            List<CommitRecord> result = new List<CommitRecord>();
            foreach (Student stu in urls)
            {
                var (info, t) = GitTools.GetAssignments(stu.url, "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");
                CommitRecord c = new CommitRecord();
                if (info.Exists(t => t.index == index+1))
                {
                    c.created = info[index].created;
                    c.updated = info[index].updated;
                    c.isCorrected = true;
                }
                c.index = index;
                c.studentId = stu.id;
                c.userName = stu.userName;
                result.Add(c);
            }
            return result;
        }
    }
}
