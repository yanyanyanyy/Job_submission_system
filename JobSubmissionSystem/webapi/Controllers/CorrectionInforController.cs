using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrectionInforController : ControllerBase
    {
        [HttpGet(Name = "[action]")]
        public CorrectionInfor Get()
        {
            return (new CorrectionInfor());
        }
    }
}
