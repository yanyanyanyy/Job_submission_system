using JobSubmissionSystem.Data;
using JobSubmissionSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSubmissionSystem.Controllers
{

    [Route("api/")]
    [ApiController]

    public class ParameterController : ControllerBase
    {
        ParameterContext ParameterContext;

        public ParameterController(ParameterContext ParameterContext)
        {
            this.ParameterContext = ParameterContext;
        }


        //查找表中所有数据
        [HttpGet("parameter/getall")]
        public IActionResult GetAll()
        {
            List<Parameter> ParameterTable = ParameterContext.Parameter.ToList();  //查出所有
            return Ok(ParameterTable);
        }


        //添加一个数据，传入一个不带ID的
        [HttpPost("parameter/postone")]
        public IActionResult PostOne(Parameter parameter)
        {
            var Parameter = ParameterContext.Parameter.FirstOrDefault(a => a.Id == parameter.Id);
            if (Parameter != null)
            {
                return BadRequest(new { conut = -1, msg = "添加失败，id重复" });
            }
            ParameterContext.Parameter.Add(parameter);  //添加一个
            ParameterContext.SaveChanges();
            return Ok();
        }

        //修改数据,传入对象，找到对应id的数据实现更新
        [HttpPost("parameter/modifyone")]
        public IActionResult Modify(Parameter parameter)
        {
            var Parameter = ParameterContext.Parameter.FirstOrDefault(a => a.Id == parameter.Id);
            if (Parameter == null)
            {
                return BadRequest(new { conut = -1, msg = "修改失败，未找到数据" });
            }
            //修改数据
            // ParameterTable.Id = parameter.Id;
            Parameter.Ceiling = parameter.Ceiling;
            Parameter.Swith = parameter.Swith;
            Parameter.Limit = parameter.Limit;
            Parameter.Auto = parameter.Auto;
            Parameter.Type = parameter.Type;
            Parameter.Plcaddress = parameter.Plcaddress;

            ParameterContext.Parameter.Update(Parameter);
            ParameterContext.SaveChanges();
            return Ok(parameter);
        }

        //移除一个对象，根据id移除
        [HttpPost("parameter/Removeone")]
        public IActionResult Remove(Parameter parameter)
        {
            var Parameter = ParameterContext.Parameter.FirstOrDefault(a => a.Id == parameter.Id);
            //修改数据

            if (Parameter == null)
            {
                return NotFound();
            }
            ParameterContext.Parameter.Remove(Parameter);
            ParameterContext.SaveChanges();
            return Ok(Parameter);
        }
    }





}
