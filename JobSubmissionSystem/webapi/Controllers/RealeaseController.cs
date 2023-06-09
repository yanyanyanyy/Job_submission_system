using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.Datas;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/release")]
    [ApiController]
    public class RealeaseController : ControllerBase
    {
        [HttpPost]
        public int PostUser(int courseId,string desc,DateTime startTime,DateTime endTime)
        {
            int userId = DB.addHomework(courseId,desc,startTime,endTime);
            return userId;
        }
    }
}
