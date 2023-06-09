using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.DependencyResolver;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using webapi.Datas;
using webapi.Models;
namespace webapi.Controllers
{

    [Route("api/submitCorrect")]
    [ApiController]
    public class submitController : ControllerBase
    {
        [HttpPost]
        public int PostSubmit(int courseId,int studentId, int workIndex,string filepath, string jsonStr)
        {
            jsonStr = jsonStr.Replace("'", "\\'");
            //jsonStr = jsonStr.Replace("\"", "\\\"");
            List<T> result = JsonConvert.DeserializeObject<List<T>>(jsonStr);
            DB.addCorrectInf(studentId,courseId,workIndex,filepath, result);
            return 1;
        }
        [HttpPost("getFile")]
        public string getFile(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
