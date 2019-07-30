using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Delete 使用类似与POST
    /// </summary>
    [RoutePrefix("api/delete")]
    public class DeleteRequestController : ApiController
    {
        [Route("DeleteWithEntityParamInput")]
        [HttpDelete]
        public string DeleteWithEntityParamInput(EntityInfo info)
        {
            return $"Delete实体参数请求：{info.id}  {info.msg}";
        }

        [Route("DeleteWithTwoParamInput")]
        [HttpDelete]
        public string DeleteWithTwoParamInput(dynamic info)
        {
            return $"Delete两个参数请求：{info.id}  {info.msg}";
        }
    }
}
