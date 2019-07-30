using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/postresult")]

    public class WebApiResultController : ApiController
    {
        [Route("NoResult")]
        [HttpPost]
        public void NoResult()
        {

        }

        [Route("JsonResult")]
        [HttpPost]
        public IHttpActionResult JsonResult()
        {
            return Json(new List<EntityInfo>()
            {
                new EntityInfo(){id = 1001,msg = "实体参数1"},
                new EntityInfo(){id = 1002,msg = "实体参数2"},
                new EntityInfo(){id = 1003,msg = "实体参数3"},
                new EntityInfo(){id = 1004,msg = "实体参数4"},
            });
        }

        [Route("AnonymousResult")]
        [HttpPost]
        public IHttpActionResult AnonymousResult()
        {
            return Json<dynamic>(new List<dynamic>()
            {
               new{id = 1001,msg = "实体参数1"},
               new{id = 1002,msg = "实体参数2"},
               new{id = 1003,msg = "实体参数3"},
               new{id = 1004,msg = "实体参数4"},
            });
        }

        [Route("OKResult")]
        [HttpPost]
        public IHttpActionResult OKResult()
        {
            return Ok();
        }

        [Route("OKOverLoadResult")]
        [HttpPost]
        public IHttpActionResult OKOverLoadResult()
        {
            return Ok(1001);
        }
    }
}
