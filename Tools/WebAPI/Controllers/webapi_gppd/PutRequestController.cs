using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// PUT使用类似与POST
    /// </summary>
    [RoutePrefix("api/put")]
    public class PutRequestController : ApiController
    {
        [Route("PutWithNOParamInput")]
        [HttpPut]
        public string PutWithNOParamInput()
        {
            return "Put 无参数请求";
        }

        [Route("PutWithEntityParamInput")]
        [HttpPut]
        public string PutWithEntityParamInput(EntityInfo info)
        {
            return $@"Put 实体参数请求
                    {info.msg}
                    {info.id}";
        }

        [Route("PutWithJSONParamInput")]
        [HttpPut]
        public string PutWithJSONParamInput(dynamic jsoninfo)
        {
            var info = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityInfo>(jsoninfo.ToString());
            return $@"Put JSON参数请求
                    {info.msg}
                    {info.id}";
        }
    }
}
