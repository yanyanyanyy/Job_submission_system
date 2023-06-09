using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Datas;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LogInController : ControllerBase
    {

        [HttpPost]
        public User? PostUser(string username,string password)
        {
            int userId = DB.getUserId(username);
            User user = new User();
            user.UserType = -1;
            if (userId == -1)
            {
                return user;
            }
            string real_password = DB.getUserPassword(userId);
            if (real_password != password) {
                return user;
            }
            int userType = DB.getUserType(userId);
            user.UserType = userType;
            user.Username = username;
            user.UserId = userId;
            return user;
        }
    }
}
