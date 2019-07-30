using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/post")]
    public class PostRequestController : ApiController
    {
        [Route("PostWithNullParamInput")]
        [HttpPost]
        public string PostWithNullParamInput()
        {
            return "Post 无参数请求";
        }

        [Route("PostWithOneParamInput")]
        [HttpPost]
        public string PostWithOneParamInput([FromBody]string msg)
        {
            return $"Post 一个参数请求 {msg}";
        }

        [Route("PostWithTwoParamInput")]
        [HttpPost]
        public string PostWithTwoParamInput(dynamic param)
        {
            return $"Post 两个参数请求 {param.id} {param.msg}";
        }

        [Route("PostWithEntityInput")]
        [HttpPost]
        public string PostWithEntityInput(EntityInfo info)
        {
            return $"Post 实体参数请求 {info.id} {info.msg}";
        }

        [Route("PostWithMultiParamInput")]
        [HttpPost]
        public string PostWithMultiParamInput(dynamic param)
        {
            var Guid = param.Guid.ToString();
            var entityinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<EntityInfo>(param.EntityInfo.ToString());

            return $@"Post 基本数据+实体参数请求 {Guid}   
                        {entityinfo.id}
                        {entityinfo.msg}";
        }
        [Route("PostWithListParamInput")]
        [HttpPost]
        public string PostWithListParamInput(List<EntityInfo> list)
        {
            return $"Post List参数请求 {list.Count()}";
        }

        [Route("PostWithArrayParamInput")]
        [HttpPost]
        public string PostWithArrayParamInput(EntityInfo[] list)
        {
            return $"Post List参数请求 {list.Count()} {list[0].msg} {list[0].id}";
        }
    }
}
