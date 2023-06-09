using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Web;
using webapi.Datas;
using webapi.Models;

namespace webapi.Controllers
{

    public class T
    {
        public string code { get; set; }
        public string correct_info { get; set; }
        public bool flag { get; set; }
        public string path { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGertCorrection : ControllerBase
    {
        [HttpGet]
        public List<T>? PostSubmit(int courseId, int studentId, int workIndex)
        {
            DB.getCorrectInf(courseId, studentId, workIndex);
            return DB.getCorrectInf(courseId, studentId, workIndex); 
        }

        [HttpGet("getClass")]
        public List<Course> Get(int id)
        {
            return DB.getStudentClass(id);
        }
        [HttpGet("addClass")]
        public int Add(int classId, int studentId,string url)
        {
            DB.addClassStudent(classId,studentId,url);
            return 0;
        }
    }
}
