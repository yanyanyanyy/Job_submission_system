using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Datas;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectionInforController : ControllerBase
    {
        [HttpGet(Name = "[action]")]
        public GitTools.Node Get(int courseId,int studentId,int assignmentIndex)
        {
            string url = DB.getStudentUrl(studentId, courseId);
            if (url == "")
            {
                return null;
            }
            var (info, files) = GitTools.GetAssignments(url, "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");

            return GitTools.work(files.FindAll(f => f.idx == assignmentIndex));
        }
    }
}
