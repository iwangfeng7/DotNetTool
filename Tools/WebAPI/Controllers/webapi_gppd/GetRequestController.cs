using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// webapi 使用汇总
    /// </summary>
    /// 
    [RoutePrefix("api/get")]
    public class GetRequestController : ApiController
    {
        [Route("GetWithNoParamInput")]
        [HttpGet]
        public string GetWithNoParamInput()
        {
            return "webapi Get请求 无参数请求";
        }

        [Route("GetWithTwoParamInput")]
        [HttpGet]
        public string GetWithTwoParamInput(int id, string msg)
        {
            return $"webapi Get请求 两个输入参数{id}  {msg}";
        }

        [Route("GetWithEntityInput")]
        [HttpGet]
        public string GetWithEntityInput([FromUri]EntityInfo info)
        {
            return $"webapi Get请求 实体输入参数{info.id}  {info.msg}";
        }

        [Route("GetWithJsonParamInput")]
        [HttpGet]
        public string GetWithJsonParamInput(string jsonmsg)
        {
            //json反序列化 
            EntityInfo info = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityInfo>(jsonmsg);

            return $@"webapi Get请求 json输入参数 
                    json格式:{jsonmsg}  
                    反序列后json {info.id} {info.msg}
                   ";
        }

        [Route("GetWithListOutput")]
        [HttpGet]
        public List<EntityInfo> GetWithListOutput(string msg)
        {
            return new List<EntityInfo>()
            {
                new EntityInfo(){id = 1001,msg = "返回信息1"},
                new EntityInfo(){id = 1002,msg = "返回信息2"},
                new EntityInfo(){id = 1003,msg = "返回信息4"}
            };
        }
    }
    /// <summary>
    /// 测试实体
    /// </summary>
    public class EntityInfo
    {
        public int id { get; set; }
        public string msg { get; set; }
    }
}
