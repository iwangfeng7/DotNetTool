using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class MVCJumpController : Controller
    {
        #region 无参跳转

        public ActionResult Index()
        {
            return View();
        }

        public void TransitbyResponse()
        {
            Response.Redirect($"/MVCJump/Index");
        }

        public ActionResult TransitbyRedirect()
        {
            return Redirect("/MVCJump/Index");
        }

        public ActionResult TransitbyRedirectToAction()
        {
            return RedirectToAction("Index", "MVCJump");
        }

        public ActionResult TransitbyView()
        {
            return View("Index");
        }

        #endregion

        #region 有参跳转

        public ActionResult IndexWithParam(int id, string msg)
        {
            ViewBag.viewbagtest = $"ViewBag返回值为返回值{id}+{msg}";
            return View("IndexWithParam", new EntityInfo() { id = id, msg = msg });
        }
        #endregion
    }
}